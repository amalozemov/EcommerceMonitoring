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

        public ClientEndPoint(string ip, int port, IStorage storage)
        {
            Ip = ip;
            Port = port;
            _storage = storage;
            _lanMonitor = new ECMonitoringPicap(Ip, Port);
            _lanMonitor.TcpStatusChangedOn += _monitor_TcpStatusChangedOn;
            _lanMonitor.HttpArrivalOn += _monitor_HttpArrivalOn;
        }

        private void _monitor_HttpArrivalOn(object sender, LanDeviceHttpStatus httpStatus)
        {
            _storage.WriteData(Id, Ip, Port, httpStatus);
            Console.WriteLine($"httpStatus = {httpStatus}");
        }

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
