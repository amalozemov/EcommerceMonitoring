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

    public enum LanDeviceStatus
    {
        Sleep,
        Connect,
        Disconnect,
        Break
    }

    internal delegate void PacketArrivalHandler(object sender, LanDeviceEventArgs e);

    public class ECMonitoringPicap
    {
        public delegate void TcpStatusChangedHandler(object sender, LanDeviceStatus deviceStatus);
        public event TcpStatusChangedHandler TcpStatusChangedOn;

        public delegate void HttpArrivalHandler(object sender, LanDeviceHttpStatus httpStatus);
        public event HttpArrivalHandler HttpArrivalOn;

        ILanDevice _lanDevice;
        HttpAnalyzer _httpAnalyzer;
        TcpAnalyzer _tcpAnalyzer;
        ILogger _logger;

        public ECMonitoringPicap(string ip, int port)
        {
            _lanDevice = new LanDevice(ip, port); //new FakeLanDevice(ip, port);//
            _lanDevice.PacketArrivalOn += _lanDevice_PacketArrivalOn;

            _tcpAnalyzer = new TcpAnalyzer(ip);
            _tcpAnalyzer.TcpAnalyzeCompleteOn += _tcpAnalyzer_TcpAnalyzeCompleteOn;

            _httpAnalyzer = new HttpAnalyzer();

            _logger = new FileLogger();
        }

        public void Dispose()
        {
            _lanDevice.Stop();
            _tcpAnalyzer.Dispose();
            _httpAnalyzer.Dispose();
        }

        /// <summary>
        /// Завершение работы анализатора TCP пакетов.
        /// </summary>
        private void _tcpAnalyzer_TcpAnalyzeCompleteOn(object sender, LanDeviceStatus deviceStatus)
        {
            _logger.TcpLog(deviceStatus);
            TcpStatusChangedOn?.Invoke(this, deviceStatus);
        }

        /// <summary>
        /// Пришёл пакет из SharpPcap
        /// </summary>
        private void _lanDevice_PacketArrivalOn(object sender, LanDeviceEventArgs e)
        {
            _tcpAnalyzer.Analyze(e);
            //_httpAnalyzer.Analyze(e);
        }

        public void Start()
        {
            _lanDevice.Start();
        }

        public void Stop()
        {
            Dispose();
        }
    }
}
