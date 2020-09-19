using ECMonitoring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Service.Forms
{
    enum EndPointGridRowStatus
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }

    class EndPointGridRow : EndPoint
    {
        public EndPointGridRowStatus RowStatus { get; set; } = EndPointGridRowStatus.Unchanged;
    }
}
