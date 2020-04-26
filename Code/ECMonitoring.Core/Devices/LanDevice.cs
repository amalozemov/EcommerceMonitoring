using ECMonitoring.Core.Exceptions;
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

    internal class LanDevice
    {
        
        public delegate void PacketArrivalHandler(object sender, LanDeviceEventArgs e);
        public event PacketArrivalHandler PacketArrivalOn;
        public string Ip { get; private set; }
        public int Port { get; private set; }

        ICaptureDevice _device;

        public LanDevice(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }

        public void Start()
        {
            if (_device != null)
            {
                throw new DeviceAlreadyConnectedException("Устройство уже подключено.");
            }

            _device = GetDivice();
            _device.OnPacketArrival += device_OnPacketArrival;

            int readTimeoutMilliseconds = 300;
            _device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            string filter = "(src 192.168.0.103 && dst 192.168.0.100 && port 1800) || (src 192.168.0.100 && port 1800 && dst 192.168.0.103) && tcp";
            _device.Filter = filter;

            _device.StartCapture();

            //Console.WriteLine("-- Listening on {0}, hit 'Enter' to stop...",
            //    _device.Description);
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

                Console.WriteLine("{0}:{1}:{2},{3} (Len={4});  SrcIp={5} -> DstIp={6}, {7}, Rst={8}",
                        time.Hour, time.Minute, time.Second,
                        string.Empty, len, srcIp, dstIp, proto, Convert.ToInt32(tcp.Rst));

                var eventArgs = 
                    new LanDeviceEventArgs(srcIp, tcp.Rst, isHttpPresent, httpAttributes);

                PacketArrivalOn?.Invoke(this, eventArgs);
            }
        }

        public void Stop()
        {
            try
            {
                _device.OnPacketArrival -= device_OnPacketArrival;
                _device.StopCapture();
            }
            catch
            {
                Console.WriteLine("При отключении устройства произошла ошибка.");
            }
            _device.Close();
            _device = null;
        }

        ICaptureDevice GetDivice(string deviceName = null)
        {
            var device = CaptureDeviceList.Instance.FirstOrDefault();

            //Console.WriteLine("\nThe following devices are available on this machine:");
            //Console.WriteLine("----------------------------------------------------\n");
            //Console.WriteLine("{0}\n", device.ToString());

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
