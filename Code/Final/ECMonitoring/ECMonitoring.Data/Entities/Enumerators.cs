using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data
{

    public enum TypeEndPoint : int
    {
        LanMonitor = 0,
        ResourceMonitor = 1
    }

    public enum TypeRequestContents : int
    {
        Json = 0,
        Xml = 1
    }
}
