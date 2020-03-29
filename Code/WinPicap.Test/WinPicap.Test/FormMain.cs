using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// https://www.codeproject.com/Articles/12458/SharpPcap-A-Packet-Capture-Framework-for-NET

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

            int readTimeoutMilliseconds = 1200;
            _device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            string filter = "ip and tcp";// "ip.src = 192.168.0.103";// "ip and tcp";
            _device.Filter = filter;

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
            Packet packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var ip = (IpPacket)packet.Extract(typeof(IpPacket));
            if (ip != null)
            {
                DateTime time = e.Packet.Timeval.Date;
                int len = e.Packet.Data.Length;

                string srcIp = ip.SourceAddress.ToString();
                string dstIp = ip.DestinationAddress.ToString();

                if (srcIp == "192.168.0.103")
                //if (dstIp == "192.168.23.15")
                //if (dstIp == "100.106.86.121")
                //if (dstIp == "192.168.0.103")
                {
                    Console.WriteLine("{0}:{1}:{2},{3} (Len={4});  SrcIp={5} -> DstIp={6}",
                        time.Hour, time.Minute, time.Second,
                        time.Millisecond, len, srcIp, dstIp);
                    //Console.WriteLine(e.Packet.ToString());
                }
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
        private void _btnDevicesList_Click(object sender, EventArgs e)
        {
            if (_device != null)
            {
                Console.WriteLine("Устройство уже подключено.");
                return;
            }

            _device = GetDivice();
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
            var device = CaptureDeviceList.Instance.FirstOrDefault();
            //var device = CaptureDeviceList.Instance[1];//.FirstOrDefault();
            return device;
        }
    }
}
