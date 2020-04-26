using ECMonitoring.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Core
{

    public class ClientEndPoint
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }

        ECMonitoringPicap _monitor;

        public ClientEndPoint()
        {
            _monitor = new ECMonitoringPicap(Ip, Port);
            _monitor.TcpArrivalOn += _monitor_TcpArrivalOn;
        }

        private void _monitor_TcpArrivalOn(object sender, DeviceStatus deviceStatus)
        {
            // нужен IP приёмника сервера чей статус определяется
            Console.WriteLine($"deviceStatus = {deviceStatus}");
        }

        //private void _monitor_TcpArrivalOn(string message)
        //{
        //    Console.WriteLine($"IP: {Ip} - {message}");
        //}

        public void Start()
        {
            _monitor.Start();

        }

        public void Stop()
        {
            _monitor.Stop();
        }
    }
}
