using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Timings
{
    //internal delegate void PingOnHandler(object sender, PingStatus result);

    internal interface IPingNotification
    {
        //event PingOnHandler PingOn;
        void PingOn(PingStatus result);
        string Ip { get; }
    }
}
