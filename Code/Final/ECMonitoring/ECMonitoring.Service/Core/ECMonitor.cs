using ECMonitoring.Core;
using ECMonitoring.Data;
using ECMonitoring.Data.Cryptography;
using ECMonitoring.Logger;
using ECMonitoring.Service.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECMonitoring.Service.Core
{
    /// <summary>
    /// Подключение к Конечным точкам (они же Мониторы).
    /// </summary>
    internal class ECMonitor
    {
        public long ServiceId { get; private set; }
        public long Id { get; private set; }
        public string Ip { get; private set; }
        public int Port { get; private set; }
        public string NetworkName { get; private set; }
        public MonitorType TypeMonitor { get; private set; }
        public string Name { get; private set; }
        public string DeviceName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool IsDisabled { get; private set; }
        IECMonitor _monitor;
        IStorage _storage;
        IEcmLogger _logger;

        public ECMonitor(EndPoint endPoint, IStorage storage)
        {
            _logger = new EcmLogger("WCFService");
            ServiceId = endPoint.ServiceId.Value;
            Ip = endPoint.Ip;
            Port = endPoint.Port.HasValue ? endPoint.Port.Value : 0;
            Id = endPoint.Id;
            NetworkName = endPoint.NetworkName;
            Name = endPoint.Name;
            DeviceName = endPoint.ConnectorName;// "rpcap://\\Device\\NPF_{F4D18444-FF49-4876-8CC7-3782EC14FCBE}";// + "h";";
            TypeMonitor = (MonitorType)endPoint.EndPointType.Value;
            UserName = endPoint.HostUserName;// "SystemMonitor";
            Password = !string.IsNullOrWhiteSpace(endPoint.HostPassword) ?
                new SHA1Encryption().DecryptData(endPoint.HostPassword) : string.Empty;//"12345";
            IsDisabled = endPoint.IsDisabledEndPoint.HasValue ?
                endPoint.IsDisabledEndPoint.Value : false;
            _storage = storage;

            if (IsDisabled)
            {
                return;
            }

            switch (TypeMonitor)
            {
                case MonitorType.LanMonitor:
                    _monitor = new LanMonitor(Ip, Port, DeviceName);
                    _monitor.DeviceStatusChangedOn += LanMonitor_DeviceStatusChangedOn;
                    break;
                case MonitorType.ResourceMonitor:
                    _monitor = new ResourceMonitor(Ip, UserName, Password);
                    _monitor.DeviceStatusChangedOn += ResourceMonitor_DeviceStatusChangedOn;
                    break;
                default:
                    throw new NotImplementedException($"Тип {TypeMonitor} конечной точки не поддерживается.");
            }
        }

        /// <summary>
        /// Изменение состояния TCP или HTTP
        /// </summary>
        private void LanMonitor_DeviceStatusChangedOn(object sender, object eventArgs)
        {
            var deviceStatus = (LanDeviceStatusEventArgs)eventArgs;
            if (deviceStatus.EventSource == SourceEvent.Tcp)
            {
                _storage.WriteData(Id, deviceStatus.DeviceStatus.Value);
                //Console.WriteLine($"deviceStatus = {deviceStatus.DeviceStatus.Value}");
            }
            else
            {
                _storage.WriteData(Id, deviceStatus.HttpErrorsCount.Value);
                //Console.WriteLine($"Количество ошибок HTTP  = {deviceStatus.HttpErrorsCount.Value}");
            }
        }

        /// <summary>
        /// Изменение состояния памяти или загрузки процессора
        /// </summary>
        private void ResourceMonitor_DeviceStatusChangedOn(object sender, object eventArgs)
        {
            var resource = (ResourceUsageEventArgs)eventArgs;
            _storage.WriteData(Id, new ResourceUsage(resource.BusyPhysicalMemoryPercent, resource.PercentProcessorTime, resource.IsSuccess));
            //Console.WriteLine($"Ресурсы:  Используемая память: {resource.MemoryUsage}; Время процессора: {resource.ProcessorTime}");
        }

        public void Start()
        {
            //try
            //{
            //    _monitor.Start();
            //}
            //catch (Exception ex)
            //{
            //    _logger.Error($"Во время подключения Конечной точки произошла ошибка:{Environment.NewLine}{ex}");
            //}
            new Thread(delegate ()
            {
                if (_monitor != null)
                {
                    _monitor.Start();
                }
                else
                {
                    _logger.Trace($"Монитор {Name} ({Ip}) отключен.");
                }
            }).Start();
        }

        public void Stop()
        {
            //_monitor.Stop();
            //new Thread(delegate ()
            //{
                if (_monitor != null)
                {
                    _monitor.Stop();
                }
            //}).Start();
        }

        /// <summary>
        /// Сброс кол-ва ошибок http анализатора.
        /// </summary>
        public void HttpErrorsReset()
        {
            ((LanMonitor)_monitor).HttpErrorsReset();
        }
    }
}
