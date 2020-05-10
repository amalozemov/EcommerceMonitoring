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

        ECMonitoringPicap _lanMonitor;
        IStorage _storage;

        public ClientEndPoint(string ip, int port, int id, IStorage storage)
        {
            Ip = ip;
            Port = port;
            Id = id;
            _storage = storage;
            _lanMonitor = new ECMonitoringPicap(Ip, Port);
            _lanMonitor.TcpStatusChangedOn += _monitor_TcpStatusChangedOn;
            _lanMonitor.HttpStatusChangedOn += _lanMonitor_HttpStatusChangedOn;
        }

        /// <summary>
        /// Изменение состояния HTTP.
        /// </summary>
        private void _lanMonitor_HttpStatusChangedOn(object sender, int errorsCount)
        {
            _storage.WriteData(Id, Ip, Port, errorsCount);
            Console.WriteLine($"Количество ошибок HTTP  = {errorsCount}");
        }

        /// <summary>
        /// Изменение состояния TCP.
        /// </summary>
        private void _monitor_TcpStatusChangedOn(object sender, LanDeviceStatus deviceStatus)
        {
            _storage.WriteData(Id, Ip, Port, deviceStatus);
            Console.WriteLine($"deviceStatus = {deviceStatus}");
        }

        public void Start()
        {
            _lanMonitor.Start();

        }

        public void Stop()
        {
            _lanMonitor.Stop();
        }
    }
}
