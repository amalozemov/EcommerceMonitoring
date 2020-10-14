using ECMonitoring.Core.Resources;
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
        private string _ip;
        private string _userName;
        private string _password;
        private IResourceInfo _resourceInfo;
        //Timer _timer;

        public ResourceMonitor(string ip, string userName, string password)//(string ip)
        {
            _ip = ip;
            _userName = userName;
            _password = password;
            _resourceInfo = new ResourceInfo(ip, userName, password);
            //_resourceInfo = new FakeResourceInfo(ip, userName, password);//(ip, "SystemMonitor", "12345");
            _resourceInfo.ResourceStatusChangedOn += _resourceInfo_ResourceStatusChangedOn;
        }

        public void Dispose()
        {
            _resourceInfo.ResourceStatusChangedOn -= _resourceInfo_ResourceStatusChangedOn;
            _resourceInfo.Stop();
        }

        private void _resourceInfo_ResourceStatusChangedOn(object sender, ResourceUsageEventArgs e)
        {
            DeviceStatusChangedOn?.Invoke(this, e);
        }

        public void Start()
        {
            //_timer = new Timer(GetResources, null, 0, 1000);
            _resourceInfo.Start();
        }

        public void Stop()
        {
            //_timer.Change(Timeout.Infinite, Timeout.Infinite);
            //_timer.Dispose();
            //_timer = null;
            Dispose();
        }

        //private void GetResources(object o)
        //{
        //    var result = new ResourceUsageEventArgs(71, 34);
        //    DeviceStatusChangedOn?.Invoke(this, result);
        //}
    }
}
