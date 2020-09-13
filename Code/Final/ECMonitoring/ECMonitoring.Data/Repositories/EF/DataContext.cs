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

        public DbSet<EndPoint> EndPoints { get; set; }
        public DbSet<EndPointType> EndPointTypes { get; set; }
        public DbSet<RequestContentsType> RequestContentsTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
