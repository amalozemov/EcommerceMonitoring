using ECMonitoring.Core.Exceptions;
using ECMonitoring.Logger;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Devices
{
    // Сетевая карта

    internal class LanDevice : ILanDevice
    {
        public event PacketArrivalHandler PacketArrivalOn;
        public string Ip { get; private set; }
        public int Port { get; private set; }
        private int _readTimeoutMilliseconds;
        private string _deviceName;
        private ICaptureDevice _device;
        private IEcmLogger _logger;

        public LanDevice(string ip, int port, string deviceName)
        {
            Ip = ip;
            Port = port;
            _logger = new EcmLogger("Core-LanDevice");
            _readTimeoutMilliseconds = 300;
            _deviceName = deviceName;// "rpcap://\\Device\\NPF_{F4D18444-FF49-4876-8CC7-3782EC14FCBE}";// + "h";
        }

        public void Start()
        {
            try
            {
                if (_device != null)
                {
                    throw new DeviceAlreadyConnectedException($"Устройство {Ip}:{Port} уже подключено.");
                }

                _device = GetDivice(_deviceName);
                _device.OnPacketArrival += device_OnPacketArrival;
                _device.Open(DeviceMode.Promiscuous, _readTimeoutMilliseconds);

                //string filter = "(src 192.168.0.103 && dst 192.168.0.100 && port 1800) || (src 192.168.0.100 && port 1800 && dst 192.168.0.103) && tcp";
                //string filter = "(src 192.168.0.100 && port 1800 && dst 192.168.0.103) && tcp";
                //string filter = "(src 192.168.0.101 && port 1800) && tcp";
                string filter = $"(src {Ip} && port {Port}) && tcp";
                _device.Filter = filter;

                _device.StartCapture();

                //Console.WriteLine("-- Listening on {0}, hit 'Enter' to stop...",
                //    _device.Description);
                _logger.Trace($"Сетевое устройство {Ip}:{Port} включено");
            }
            catch (Exception ex)
            {
                _logger.Error($"При подключении сетевого устройства {Ip}:{Port} произошла ошибка:{Environment.NewLine}{ex}");
            }
        }

        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var ip = (IpPacket)packet.Extract(typeof(IpPacket));
            var tcp = (TcpPacket)ip.Extract(typeof(TcpPacket));
            var buffer = tcp.PayloadData;
            var httpHeader = GetHttpHeader(buffer, tcp.SequenceNumber);

            if (tcp != null)
            {
                var time = e.Packet.Timeval.Date;
                var len = e.Packet.Data.Length;
                var srcIp = ip.SourceAddress.ToString();
                var dstIp = ip.DestinationAddress.ToString();

                var proto =
                    httpHeader.IndexOf("http", StringComparison.CurrentCultureIgnoreCase) >= 0 || httpHeader.IndexOf("post", StringComparison.CurrentCultureIgnoreCase) >= 0 ? "HTTP" : ip.Protocol.ToString();
                var isHttpPresent = false;
                var httpAttributes = default(HttpHeaderAttributes);
                if (proto == "HTTP")
                {
                    isHttpPresent = true;
                    httpAttributes = new HttpHeaderAttributes(srcIp, httpHeader);
                }

                //Console.WriteLine("{0}:{1}:{2},{3} (Len={4});  SrcIp={5} -> DstIp={6}, {7}, Rst={8}",
                //        time.Hour, time.Minute, time.Second,
                //        string.Empty, len, srcIp, dstIp, proto, Convert.ToInt32(tcp.Rst));

                //var t = ip.SourceAddress;
                //if (tcp.SourcePort == 1800 && ip.SourceAddress.ToString() != "192.168.0.101")
                //{
                    //Console.WriteLine("SrcIp={0}:{1} -> DstIp={2}:{3}, {4}, Rst={5}",
                    //   //time.Hour, time.Minute, time.Second,
                    //   //string.Empty, len, 
                    //   srcIp, tcp.SourcePort, dstIp, tcp.DestinationPort, proto, Convert.ToInt32(tcp.Rst));

                _logger.Trace($"SrcIp={srcIp}:{tcp.SourcePort} -> DstIp={dstIp}:{tcp.DestinationPort}, {proto}, Rst={Convert.ToInt32(tcp.Rst)}");

                    var eventArgs =
                        new LanDeviceEventArgs(srcIp, dstIp, tcp.Rst, isHttpPresent, httpAttributes);
                

                    PacketArrivalOn?.BeginInvoke(this, eventArgs, null, null);
                //}
            }
        }

        public void Stop()
        {
            try
            {
                if (_device == null)
                {
                    throw new DeviceAlreadyConnectedException($"Устройство {Ip}:{Port} ещё не подключено.");
                }

                //try
                //{
                _device.OnPacketArrival -= device_OnPacketArrival;
                _device.StopCapture();
                //}
                //catch
                //{
                //    //Console.WriteLine("При отключении устройства произошла ошибка.");
                //    _logger.Error($"При отключении устройства {Ip}:{Port} произошла ошибка.");
                //}
                _device.Close();
                _device = null;
                _logger.Trace($"Сетевое устройство {Ip}:{Port} отключено");
            }
            catch (Exception ex)
            {
                _logger.Error($"При отключении сетевого устройства {Ip}:{Port} произошла ошибка:{Environment.NewLine}{ex}");
            }
        }

        ICaptureDevice GetDivice(string deviceName = null)
        {
            var device = default(ICaptureDevice); //

            if (string.IsNullOrWhiteSpace(deviceName))
            {
                device = CaptureDeviceList.Instance.FirstOrDefault();
            }
            else
            {
                device = CaptureDeviceList.Instance.Where(d => d.Name == deviceName).FirstOrDefault();
            }

            //Console.WriteLine("\nThe following devices are available on this machine:");
            //Console.WriteLine("----------------------------------------------------\n");
            //Console.WriteLine("{0}\n", device.ToString());
            if (device == null)
            {
                throw new Exception($"Сетевое устройство {deviceName} не найдено.");
            }

            return device;
        }

        private string GetHttpHeader(byte[] inputBuffer, uint sequenceNumber)
        {
            if (inputBuffer.Length == 0)
            {
                return string.Empty;
            }
            var res = Encoding.ASCII.GetString(inputBuffer);
            return res;
        }
    }
}
