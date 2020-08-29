using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DataFirst.Repository
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
