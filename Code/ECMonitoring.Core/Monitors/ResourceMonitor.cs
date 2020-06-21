using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// https://www.cyberforum.ru/csharp-net/thread329031.html
// https://www.cyberforum.ru/csharp-beginners/thread1954683.html

namespace ECMonitoring.Core
{
    public class ResourceMonitor : IECMonitor
    {
        public event DeviceStatusChangedHandler DeviceStatusChangedOn;
        private string _networkName;
        Timer _timer;

        public ResourceMonitor(string networkName)
        {
            _networkName = networkName;
        }

        public void Start()
        {
            _timer = new Timer(GetResources, null, 0, 1000);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Dispose();
            _timer = null;
        }

        private void GetResources(object o)
        {
            var result = new ResourceUsageEventArgs(300000, 34);
            DeviceStatusChangedOn?.Invoke(this, result);
        }
    }
}
