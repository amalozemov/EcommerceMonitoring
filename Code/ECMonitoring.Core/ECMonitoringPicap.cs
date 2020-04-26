using ECMonitoring.Core.Devices;
//using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    public enum ServerHttpResponseStatus
    {
        OK,
        Error
    }

    public enum DeviceStatus
    {
        Sleep,
        Connect,
        Disconnect,
        Break
    }

    public class ECMonitoringPicap
    {
        public delegate void TcpArrivalHandler(object sender, DeviceStatus deviceStatus);
        public event TcpArrivalHandler TcpArrivalOn;

        public delegate void HttpArrivalHandler(string message);
        public event HttpArrivalHandler HttpArrivalOn;

        //Timer _timer { get; set; }

        LanDevice _lanDevice;
        HttpAnalyzer _httpAnalyzer;
        TcpAnalyzer _tcpAnalyzer;
        IStorageHandler _storage;
        ILogger _logger;

        public ECMonitoringPicap(string ip, int port)
        {
            //_timer = new Timer(FakeArrivalHandler);
            _lanDevice = new LanDevice(ip, port);
            _lanDevice.PacketArrivalOn += _lanDevice_PacketArrivalOn;
            _tcpAnalyzer = new TcpAnalyzer();
            _httpAnalyzer = new HttpAnalyzer();
            //_lanDevice.PacketArrivalOn += _lanDevice_PacketArrivalOn;
            //_httpAnalyzer = new HttpAnalyzer();
            //_httpAnalyzer.HttpArrivalOn += _httpAnalyzer_HttpArrivalOn;
            //_tcpAnalyzer = new TcpAnalyzer();
            //_tcpAnalyzer.TcpArrivalOn += _tcpAnalyzer_TcpArrivalOn;
            _storage = new MemoryStorage();
            _logger = new FileLogger();
        }

        private void _lanDevice_PacketArrivalOn(object sender, LanDeviceEventArgs e)
        {
            var tcpStatus = _tcpAnalyzer.Analyze(e);
            _storage.WriteData(tcpStatus);
            _logger.TcpLog(tcpStatus);
            TcpArrivalOn?.BeginInvoke(this, tcpStatus, null, null);

            if (e.IsHttpPresent)
            {
                var t = e.HttpContent;

                var httpStatus = _httpAnalyzer.Analyze(e);
                if (httpStatus.ResponseStatus == ServerHttpResponseStatus.Error)
                {
                    _storage.WriteData(httpStatus);
                    _logger.HttpLog(httpStatus);
                    // тут тоже вызвать событие для Http (события вызываем на всякий случай и для тестирования) но передать в событие всё содержимое Store
                }
            }



        }

        //private void _tcpAnalyzer_TcpArrivalOn(CaptureEventArgs e)
        //{
        //    TcpArrivalOn?.Invoke("Пришёл TCP пакет.");
        //}

        //private void _httpAnalyzer_HttpArrivalOn(CaptureEventArgs e)
        //{
        //    HttpArrivalOn?.Invoke("Пришёл HTTP пакет.");
        //}

        //private void _lanDevice_PacketArrivalOn(CaptureEventArgs e)
        //{
        //    var packetType = GetPacketType(e);

        //    if (packetType == PacketType.TCP)
        //    {
        //        _tcpAnalyzer.Analyze(e);
        //    }
        //    else if (packetType == PacketType.HTTP)
        //    {
        //        _httpAnalyzer.Analyze(e);
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException("Не определён тип пакета.");
        //    }
        //}

        //private PacketType GetPacketType(CaptureEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

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
            //TcpArrivalOn?.Invoke("Пришёл TCP пакет.");
        }
    }
}
