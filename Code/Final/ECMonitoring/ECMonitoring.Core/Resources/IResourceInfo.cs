using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Resources
{
    internal delegate void ResourceStatusChangedHandler(object sender, ResourceUsageEventArgs e);
    internal interface IResourceInfo
    {
        void Start();
        void Stop();
        event ResourceStatusChangedHandler ResourceStatusChangedOn;
    }
}
