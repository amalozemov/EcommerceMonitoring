using ECMonitoring.Core;
using ECMonitoring.Data;
using ECMonitoring.Service.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
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
        IECMonitor _monitor;
        IStorage _storage;

        public ECMonitor(EndPoint endPoint, IStorage storage)
        {
            ServiceId = endPoint.ServiceId.Value;
            Ip = endPoint.Ip;
            Port = endPoint.Port.Value;
            Id = endPoint.Id;
            NetworkName = endPoint.NetworkName;
            TypeMonitor = (MonitorType)endPoint.EndPointType.Value;
            _storage = storage;

            switch (TypeMonitor)
            {
                case MonitorType.LanMonitor:
                    _monitor = new LanMonitor(Ip, Port);
                    _monitor.DeviceStatusChangedOn += _lanMonitor_DeviceStatusChangedOn;
                    break;
                case MonitorType.ResourceMonitor:
                    _monitor = new ResourceMonitor(NetworkName);
                    _monitor.DeviceStatusChangedOn += ResourceMonitor_DeviceStatusChangedOn;
                    break;
                default:
                    throw new NotImplementedException("Данный тип конечной точки не поддерживается.");
            }
        }

        /// <summary>
        /// Изменение состояния TCP или HTTP
        /// </summary>
        private void _lanMonitor_DeviceStatusChangedOn(object sender, object eventArgs)
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
            _storage.WriteData(Id, new ResourceUsage(resource.MemoryUsage, resource.ProcessorTime));
            //Console.WriteLine($"Ресурсы:  Используемая память: {resource.MemoryUsage}; Время процессора: {resource.ProcessorTime}");
        }

        public void Start()
        {
            _monitor.Start();
        }

        public void Stop()
        {
            _monitor.Stop();
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
