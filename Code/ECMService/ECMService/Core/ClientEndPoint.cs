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
            _monitor.TcpArrivalHandler += _monitor_TcpArrivalHandler;
        }

        private void _monitor_TcpArrivalHandler(string message)
        {
            Console.WriteLine($"IP: {Ip} - {message}");
        }

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
