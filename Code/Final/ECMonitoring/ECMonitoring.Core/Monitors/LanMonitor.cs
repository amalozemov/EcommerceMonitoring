using ECMonitoring.Core.Devices;
using ECMonitoring.Logger;
using System;

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
        //ILogger _logger;
        IEcmLogger _logger;

        public LanMonitor(string ip, int port)
        {
            _lanDevice = new LanDevice(ip, port); //new FakeLanDevice(ip, port);//
            _lanDevice.PacketArrivalOn += _lanDevice_PacketArrivalOn;

            _tcpAnalyzer = new TcpAnalyzer(ip);
            _tcpAnalyzer.TcpAnalyzeCompleteOn += _tcpAnalyzer_TcpAnalyzeCompleteOn;

            _httpAnalyzer = new HttpAnalyzer();
            _httpAnalyzer.HttpAnalyzeCompleteOn += _httpAnalyzer_HttpAnalyzeCompleteOn;
            _logger = new EcmLogger("Core-LanMonitor");
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
            _logger.Info($"Сервис {((LanDevice)_lanDevice).Ip}:{((LanDevice)_lanDevice).Port} изменил состояние на {deviceStatus}");
            var eventArgs = new LanDeviceStatusEventArgs(SourceEvent.Tcp, deviceStatus, null);
            DeviceStatusChangedOn?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Завершение работы анализатора HTTP пакетов.
        /// </summary>
        private void _httpAnalyzer_HttpAnalyzeCompleteOn(object sender, LanDeviceHttpStatus httpStatus)
        {
            var errorsCountPart = httpStatus.HttpErrorsCount == 0 ? string.Empty : $" - Кол-во ошибок: {httpStatus.HttpErrorsCount}";
            _logger.Info($"Сервис {((LanDevice)_lanDevice).Ip}:{((LanDevice)_lanDevice).Port} вернул ответ: " + 
                $"{httpStatus.ErrorDescription}({httpStatus.StatusCode}){errorsCountPart}");
            var eventArgs = new LanDeviceStatusEventArgs(SourceEvent.Http, null, httpStatus.HttpErrorsCount);
            DeviceStatusChangedOn?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Пришёл пакет из SharpPcap
        /// </summary>
        private void _lanDevice_PacketArrivalOn(object sender, LanDeviceEventArgs e)
        {
            try
            {
                _tcpAnalyzer.Analyze(e);
                _httpAnalyzer.Analyze(e);
            }
            catch (Exception ex)
            {
                _logger.Error($"При разборе пакетов произошла ошибка:{Environment.NewLine}{ex}");
            }
        }

        public void Start()
        {
            _lanDevice.Start();
            _tcpAnalyzer.PingExternalStart();
        }

        public void Stop()
        {
            Dispose();
        }

        /// <summary>
        /// Сброс кол-ва ошибок http анализатора.
        /// </summary>
        public void HttpErrorsReset()
        {
            _httpAnalyzer.HttpErrorsReset();
        }
    }
}
