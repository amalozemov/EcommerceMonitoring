using DBaseService;
using ECMonitoring.Core;
using ECMService.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Core
{

    internal class ClientEndPoint
    {
        public int Id { get; private set; }
        public string Ip { get; private set; }
        public int Port { get; private set; }
        public MonitorType[] Metrics { get; private set; }

        IList<IECMonitor> _monitors;
        IStorage _storage;

        public ClientEndPoint(IRepository repository, string ip, int port, int id, IStorage storage)
        {
            Ip = ip;
            Port = port;
            Id = id;
            _storage = storage;

            _monitors = new List<IECMonitor>();
            Metrics = repository.GetMetrics(id).Select(m => (MonitorType)m).ToArray();
            foreach (var m in Metrics)
            {
                switch (m)
                {
                    case MonitorType.LanMonitor:
                        var lanMonitor = new LanMonitor(Ip, Port);
                        lanMonitor.DeviceStatusChangedOn += _lanMonitor_DeviceStatusChangedOn;
                        _monitors.Add(lanMonitor);
                        break;
                    default:
                        throw new NotImplementedException("Метрика не реализована.");
                }
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
                Console.WriteLine($"deviceStatus = {deviceStatus.DeviceStatus.Value}");
            }
            else
            {
                _storage.WriteData(Id, deviceStatus.HttpErrorsCount.Value);
                Console.WriteLine($"Количество ошибок HTTP  = {deviceStatus.HttpErrorsCount.Value}");
            }
        }

        public void Start()
        {
            foreach (var m in _monitors)
            {
                m.Start();
            }
        }

        public void Stop()
        {
            foreach (var m in _monitors)
            {
                m.Stop();
            }
        }
    }
}
