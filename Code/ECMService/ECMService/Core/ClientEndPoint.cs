using DBaseService;
using DBaseService.DTO;
using ECMonitoring.Core;
using ECMService.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECMService.Core
{

    internal class ClientEndPoint
    {
        public int ServiceId { get; private set; }
        public int Id { get; private set; }
        public string Ip { get; private set; }
        public int Port { get; private set; }
        public string NetworkName { get; private set; }
        //public MonitorType[] Metrics { get; private set; }
        public MonitorType TypeMonitor { get; private set; }

        //IList<IECMonitor> _monitors;    // мониторы, они же метрики

        IECMonitor _monitor;
        IStorage _storage;

        //public ClientEndPoint(IRepository repository, string ip, int port, int id, string networkName, IStorage storage)
        public ClientEndPoint(ClientEndPointDTO endPoint, IStorage storage)
        {
            ServiceId = endPoint.ServiceId;
            Ip = endPoint.Ip;
            Port = endPoint.Port;
            Id = endPoint.Id;
            NetworkName = endPoint.NetworkName;
            TypeMonitor = endPoint.TypeMonitor;
            _storage = storage;
            
            //_monitors = new List<IECMonitor>();
            //Metrics = repository.GetMetrics(id).Select(m => (MonitorType)m).ToArray();
            //Metrics = endPoint.Metrics.Select(m => m.MetricType).ToArray();
            //foreach (var m in Metrics)
            //{
            switch (TypeMonitor)
            {
                case MonitorType.LanMonitor:
                    //var lanMonitor = new LanMonitor(Ip, Port);
                    //lanMonitor.DeviceStatusChangedOn += _lanMonitor_DeviceStatusChangedOn;
                    //_monitors.Add(lanMonitor);
                    _monitor = new LanMonitor(Ip, Port);
                    _monitor.DeviceStatusChangedOn += _lanMonitor_DeviceStatusChangedOn;
                    break;
                case MonitorType.ResourceMonitor:
                    ////var resourceMonitor = new ResourceMonitor(NetworkName);
                    ////resourceMonitor.DeviceStatusChangedOn += ResourceMonitor_DeviceStatusChangedOn;
                    ////_monitors.Add(resourceMonitor);
                    _monitor = new ResourceMonitor(NetworkName);
                    _monitor.DeviceStatusChangedOn += ResourceMonitor_DeviceStatusChangedOn;

                    break;

                default:
                    throw new NotImplementedException("Данный тип конечной точки не поддерживается.");
            }
            //}
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
                Console.WriteLine($"deviceStatus = {deviceStatus.DeviceStatus.Value}");
            }
            else
            {
                _storage.WriteData(Id, deviceStatus.HttpErrorsCount.Value);
                Console.WriteLine($"Количество ошибок HTTP  = {deviceStatus.HttpErrorsCount.Value}");
            }
        }

        /// <summary>
        /// Изменение состояния памяти или загрузки процессора
        /// </summary>
        private void ResourceMonitor_DeviceStatusChangedOn(object sender, object eventArgs)
        {
            var resource = (ResourceUsageEventArgs)eventArgs;
            _storage.WriteData(Id, new ResourceUsage(resource.MemoryUsage, resource.ProcessorTime));
            Console.WriteLine($"Ресурсы:  Используемая память: {resource.MemoryUsage}; Время процессора: {resource.ProcessorTime}");
        }

        public void Start()
        {
            ////foreach (var m in _monitors)
            ////{
            ////    m.Start();
            ////}
            //Parallel.ForEach(_monitors, m => m.Start());
            _monitor.Start();
        }

        public void Stop()
        {
            //foreach (var m in _monitors)
            //{
            //    m.Stop();
            //}
            _monitor.Stop();
        }
    }
}
