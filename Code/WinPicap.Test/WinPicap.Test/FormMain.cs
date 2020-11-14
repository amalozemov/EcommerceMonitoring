using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

// https://www.codeproject.com/Articles/12458/SharpPcap-A-Packet-Capture-Framework-for-NET
// http://blog.sedicomm.com/2017/05/30/tcpdump-poleznoe-rukovodstvo-s-primerami/
// ((ip.src == 192.168.0.103 && ip.dst == 192.168.0.100 && tcp.port==1800) || ( ip.src == 192.168.0.100 && tcp.port==1800 && ip.dst == 192.168.0.103)) && (http || tcp)
// https://wiki.merionet.ru/servernye-resheniya/42/zaxvat-paketov-s-tcpdump-rukovodstvo-s-primerami/

namespace WinPicap.Test
{
    public partial class FormMain : Form
    {
        ICaptureDevice _device;

        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            string ver = SharpPcap.Version.VersionString;
            Console.WriteLine("SharpPcap {0}, Example1.IfList.cs", ver);

            _btnDevicesList_Click(null, null);
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            if (_device == null)
            {
                Console.WriteLine("Устройство ещё не подключено.");
                return;
            }
            if (_device.Started)
            {
                Console.WriteLine("Устройство уже работает.");
                return;
            }

            _device.OnPacketArrival += device_OnPacketArrival;

            int readTimeoutMilliseconds = 300;
            _device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            //string filter = "src 192.168.0.103";//"host 192.168.0.103";// "ip and tcp";// "ip.src = 192.168.0.103";// "ip and tcp";
            //string filter = "host 192.168.0.103";

            //string filter = "((src 192.168.0.103 && dst 192.168.0.100 && dst port 1800) || ( src 192.168.0.100 && dst port 1800 && dst 192.168.0.103)) && (http || tcp)";
            string filter = "(src 192.168.0.103 && dst 192.168.0.100 && port 1800) || (src 192.168.0.100 && port 1800 && dst 192.168.0.103) && tcp";
            //_device.Filter = filter;

            Console.WriteLine("-- Listening on {0}, hit 'Enter' to stop...",
                _device.Description);

            _device.StartCapture();
        }

        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            //var time = e.Packet.Timeval.Date;
            //var len = e.Packet.Data.Length;
            //Console.WriteLine("{0}:{1}:{2},{3} Len={4}",
            //    time.Hour, time.Minute, time.Second, time.Millisecond, len);

            //var tcp = (TcpPacket)e.Packet.Extract(typeof(TcpPacket));
            var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);


            
            var ip = (IpPacket)packet.Extract(typeof(IpPacket));

            var tcp = (TcpPacket)ip.Extract(typeof(TcpPacket));
            
            //Console.WriteLine($"tcp = {tcp}");
            //var t = tcp;

            //https://stackoverflow.com/questions/1863564/how-to-capture-http-packet-with-sharppcap
            //https://stackoverflow.com/questions/318506/converting-raw-http-request-into-httpwebrequest-object
            var buffer = tcp.PayloadData;
            //var buffer2 = tcp.PayloadPacket;
            //if (buffer2 != null)
            //{
            //    var httpHeader = buffer2;// GetHttpHeader(buffer2);
            //}

            //var httpHeader = string.Empty;
            //if (buffer?.Length > 0)
            //{
            var httpHeader = GetHttpHeader(buffer, tcp.SequenceNumber);
            //}

            //var http = (IpPacket)tcp.Extract(typeof(PacketDotNet.SessionPacket));
            //Console.WriteLine($"http = {http}");

            if (ip != null)
            {
                var time = e.Packet.Timeval.Date;
                var len = e.Packet.Data.Length;

                var srcIp = ip.SourceAddress.ToString();
                var dstIp = ip.DestinationAddress.ToString();

                //if (srcIp == "192.168.0.103")
                //if (dstIp == "192.168.23.15")
                //if (dstIp == "100.106.86.121")
                //if (dstIp == "192.168.0.103")
                //{
                //if (srcIp == "192.168.0.103" && dstIp == "192.168.0.100" || srcIp == "192.168.0.100" && dstIp == "192.168.0.103")
                var proto = 
                    httpHeader.IndexOf("http", StringComparison.CurrentCultureIgnoreCase) >= 0 || httpHeader.IndexOf("post", StringComparison.CurrentCultureIgnoreCase) >= 0 ? "HTTP" : ip.Protocol.ToString();
                Console.WriteLine("{0}:{1}:{2},{3} (Len={4});  SrcIp={5} -> DstIp={6}, {7}, Rst={8}",
                        time.Hour, time.Minute, time.Second,
                        string.Empty, len, srcIp, dstIp, proto, Convert.ToInt32(tcp.Rst));
                    //Console.WriteLine(e.Packet.ToString());
                //}
            }

            //// парсинг всего пакета
            //Packet packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            //// получение только TCP пакета из всего фрейма
            //var tcpPacket = TcpPacket.GetEncapsulated(packet);
            //// получение только IP пакета из всего фрейма
            //var ipPacket = IpPacket.GetEncapsulated(packet);
            //if (tcpPacket != null && ipPacket != null)
            //{
            //    DateTime time = e.Packet.Timeval.Date;
            //    int len = e.Packet.Data.Length;

            //    // IP адрес отправителя
            //    var srcIp = ipPacket.SourceAddress.ToString();
            //    // IP адрес получателя
            //    var dstIp = ipPacket.DestinationAddress.ToString();

            //    // порт отправителя
            //    var srcPort = tcpPacket.SourcePort.ToString();
            //    // порт получателя
            //    var dstPort = tcpPacket.DestinationPort.ToString();
            //    // данные пакета
            //    string data = tcpPacket.PayloadPacket.ToString();
            //    Console.WriteLine(data);
            //}
        }

        private string GetHttpHeader(byte[] inputBuffer, uint sequenceNumber)
        {
            //            string requestString =
            //@"POST /resource/?query_id=0 HTTP/1.1
            //Host: example.com
            //User-Agent: custom
            //Accept: */*
            //Connection: close
            //Content-Length: 20
            //Content-Type: application/json

            //{""key1"":1, ""key2"":2}";
            //            byte[] requestRaw = Encoding.UTF8.GetBytes(requestString);
            //            ReadOnlySequence<byte> buffer = new ReadOnlySequence<byte>(requestRaw);
            //            HttpParser<Program> parser = new HttpParser<Program>();
            //            Program app = new Program();
            //            Console.WriteLine("Start line:");
            //            parser.ParseRequestLine(app, buffer, out var consumed, out var examined);
            //            buffer = buffer.Slice(consumed);
            //            Console.WriteLine("Headers:");
            //            parser.ParseHeaders(app, buffer, out consumed, out examined, out var b);
            //            buffer = buffer.Slice(consumed);
            //            string body = Encoding.UTF8.GetString(buffer.ToArray());
            //            Dictionary<string, int> bodyObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, int>>(body);
            //            Console.WriteLine("Body:");
            //            foreach (var item in bodyObject)
            //                Console.WriteLine($"key: {item.Key}, value: {item.Value}");
            //            Console.ReadKey();

            if (inputBuffer.Length == 0)
            {
                return string.Empty;
            }

            var path = $@"E:\Projects\Tolik\ECMonitoring\Code\WinPicap.Test\Data\damp{sequenceNumber}.bin";

            // создаем объект BinaryWriter
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                //// записываем в файл значение каждого поля структуры
                //foreach (State s in states)
                //{
                //    writer.Write(s.name);
                //    writer.Write(s.capital);
                //    writer.Write(s.area);
                //    writer.Write(s.people);
                //}
                writer.Write(inputBuffer);
            }


            //var t = BitConverter.ToString(inputBuffer);
            var res = Encoding.ASCII.GetString(inputBuffer);
            return res;
        }

        private void _btnDevicesList_Click(object sender, EventArgs e)
        {
            if (_device != null)
            {
                Console.WriteLine("Устройство уже подключено.");
                return;
            }

            //_device = GetDivice();
            //var deviceName = @"rpcap://\Device\NPF_{F4D18444-FF49-4876-8CC7-3782EC14FCBE}";
            var deviceName = @"rpcap://\Device\NPF_{823D5A81-B42A-4079-ADAF-8B7B74C7970A}";
            _device = GetDivice(deviceName);
            Console.WriteLine("\nThe following devices are available on this machine:");
            Console.WriteLine("----------------------------------------------------\n");
            Console.WriteLine("{0}\n", _device.ToString());
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _device.StopCapture();
            }
            catch { }
            _device.Close();
            _device = null;
            Console.WriteLine("Устройство отключено.");
        }

        ICaptureDevice GetDivice(string deviceName = null)
        {
            var ret = default(ICaptureDevice);
            //var device = CaptureDeviceList.Instance.FirstOrDefault();
            var devices = CaptureDeviceList.Instance; //;//.FirstOrDefault();
                                                      //var device = CaptureDeviceList.Instance[1];//.FirstOrDefault();

            //foreach (var device in devices)
            //{
            //    Console.WriteLine($"device.Name = {device.Name};{Environment.NewLine}device.Description = {device.Description}");
            //}

            if (string.IsNullOrWhiteSpace(deviceName))
            {
                ret = devices.FirstOrDefault();
            }
            else
            {
                ret = CaptureDeviceList.Instance.Where(d => d.Name == deviceName).FirstOrDefault();
            }
            return ret;
        }
    }
}
