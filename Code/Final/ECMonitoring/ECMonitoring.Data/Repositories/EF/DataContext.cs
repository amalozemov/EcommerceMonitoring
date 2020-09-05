using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data.EF
{
    internal class DataContext : DbContext
    {
        public DataContext(string connectionString)
           : base(connectionString)       
        {
        }
    }
}
