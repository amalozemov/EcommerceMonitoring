using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models.EcMonitoring
{
    public class DBContext : DbContext
    {
        public DBContext() : base("EcMonitoring")
        { }

        //public DbSet<Book> Books { get; set; }
        //public DbSet<Purchase> Purchases { get; set; }
    }
}