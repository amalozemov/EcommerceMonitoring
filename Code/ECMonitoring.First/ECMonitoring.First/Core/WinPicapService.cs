using ECMonitoring.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECMonitoring.First.Core
{
    public class WinPicapService
    {
        ECMonitoringPicap _monitor = new ECMonitoringPicap();

        public WinPicapService()
        {
            _monitor.TcpArrivalHandler += _monitor_TcpArrivalHandler;
        }

        private void _monitor_TcpArrivalHandler(string message)
        {
            var t = message;
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