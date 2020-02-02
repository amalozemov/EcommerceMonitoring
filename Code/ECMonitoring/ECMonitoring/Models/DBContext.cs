using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("BookStore")
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}