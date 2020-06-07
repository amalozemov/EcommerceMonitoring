using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Manager.DTO
{
    internal class DataContainer<T>
    {
        public DateTime LastAccessedTime { get; set; }
        public T DataObject { get; set; }
    }
}
