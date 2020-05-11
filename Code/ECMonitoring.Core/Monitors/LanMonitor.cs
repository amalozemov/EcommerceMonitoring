using ECMonitoring.Core.Devices;


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

    public class LanMonitor : IECMonitor
    {
        public event DeviceStatusChangedHandler DeviceStatusChangedOn;
        ILanDevice _lanDevice;
        HttpAnalyzer _httpAnalyzer;
        TcpAnalyzer _tcpAnalyzer;
        ILogger _logger;

        public LanMonitor(string ip, int port)
        {
            _lanDevice = new FakeLanDevice(ip, port);//new LanDevice(ip, port); //
            _lanDevice.PacketArrivalOn += _lanDevice_PacketArrivalOn;

            _tcpAnalyzer = new TcpAnalyzer(ip);
            _tcpAnalyzer.TcpAnalyzeCompleteOn += _tcpAnalyzer_TcpAnalyzeCompleteOn;

            _httpAnalyzer = new HttpAnalyzer();
            _httpAnalyzer.HttpAnalyzeCompleteOn += _httpAnalyzer_HttpAnalyzeCompleteOn;
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
            var eventArgs = new LanDeviceStatusEventArgs(SourceEvent.Tcp, deviceStatus, null);
            DeviceStatusChangedOn?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Завершение работы анализатора HTTP пакетов.
        /// </summary>
        private void _httpAnalyzer_HttpAnalyzeCompleteOn(object sender, LanDeviceHttpStatus httpStatus)
        {
            _logger.HttpLog(httpStatus);
            var eventArgs = new LanDeviceStatusEventArgs(SourceEvent.Http, null, httpStatus.HttpErrorsCount);
            DeviceStatusChangedOn?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Пришёл пакет из SharpPcap
        /// </summary>
        private void _lanDevice_PacketArrivalOn(object sender, LanDeviceEventArgs e)
        {
            _tcpAnalyzer.Analyze(e);
            _httpAnalyzer.Analyze(e);
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
