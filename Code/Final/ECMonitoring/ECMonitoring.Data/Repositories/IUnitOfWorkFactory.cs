using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
