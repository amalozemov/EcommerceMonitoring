using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Manager
{
    internal class DataContainer<T>
    {
        public DateTime TimeStamp { get; set; }
        public T DataObject { get; set; }
    }
}
