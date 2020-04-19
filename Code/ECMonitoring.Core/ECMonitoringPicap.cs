using ECMonitoring.Core.Devices;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    public class ECMonitoringPicap
    {
        enum PacketType
        {
            TCP,
            HTTP
        }

        public delegate void TCPArrivalHandler(string message);
        public event TCPArrivalHandler TcpArrivalHandler;

        public delegate void HTTPArrivalHandler(string message);
        public event HTTPArrivalHandler HttpArrivalHandler;

        //Timer _timer { get; set; }

        LanDevice _lanDevice;
        HttpAnalyzer _httpAnalyzer;
        TcpAnalyzer _tcpAnalyzer;

        public ECMonitoringPicap(string ip, int port)
        {
            //_timer = new Timer(FakeArrivalHandler);
            _lanDevice = new LanDevice(ip, port);
            _lanDevice.PacketArrivalOn += _lanDevice_PacketArrivalOn;
            _httpAnalyzer = new HttpAnalyzer();
            _httpAnalyzer.HttpArrivalOn += _httpAnalyzer_HttpArrivalOn;
            _tcpAnalyzer = new TcpAnalyzer();
            _tcpAnalyzer.TcpArrivalOn += _tcpAnalyzer_TcpArrivalOn;
        }

        private void _tcpAnalyzer_TcpArrivalOn(CaptureEventArgs e)
        {
            TcpArrivalHandler?.Invoke("Пришёл TCP пакет.");
        }

        private void _httpAnalyzer_HttpArrivalOn(CaptureEventArgs e)
        {
            HttpArrivalHandler?.Invoke("Пришёл HTTP пакет.");
        }

        private void _lanDevice_PacketArrivalOn(CaptureEventArgs e)
        {
            var packetType = GetPacketType(e);

            if (packetType == PacketType.TCP)
            {
                _tcpAnalyzer.Analyze(e);
            }
            else if (packetType == PacketType.HTTP)
            {
                _httpAnalyzer.Analyze(e);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Не определён тип пакета.");
            }

        }

        private PacketType GetPacketType(CaptureEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            _lanDevice.Start();
        }

        public void Stop()
        {
            //_timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            _lanDevice.Stop();
        }

        private void FakeArrivalHandler(object state)
        {
            TcpArrivalHandler?.Invoke("Пришёл TCP пакет.");
        }
    }
}
