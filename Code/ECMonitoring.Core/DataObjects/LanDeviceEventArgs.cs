using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    internal class LanDeviceEventArgs : EventArgs
    {
        public string SrcIp { get; private set; }
        public bool IsHttpPresent { get; private set; }
        public bool IsRst { get; private set; }
        public HttpHeaderAttributes HttpContent { get; private set; }

        public LanDeviceEventArgs(string srcIp, bool isRst, bool isHttpPresent, HttpHeaderAttributes httpContent)
        {
            SrcIp = srcIp;
            IsHttpPresent = isHttpPresent;
            IsRst = isRst;
            HttpContent = httpContent;
        }
    }
}
