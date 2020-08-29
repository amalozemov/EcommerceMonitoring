using EntityFramework.DataFirst.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DataFirst.Data
{
    public class DataContext : DbContext
    {
        // base без name подключается с именем TEST_DB
        // base без параметра создаёт БД с именем которое сам придумает (Code First)
        // переопределение OnModelCreating - Code First
        // name=TEST_DB читает строку подключения из файла конфигурации, но не может её распарсить
        // в base нужно непосредственно передавать Connection Strting для Data First

        ////public DataContext()
        ////    : base("name=TEST_DB")
        ////    //:base(@"Data Source=STAS-PC\SQLEXPRESS;Initial Catalog=TEST_DB;Integrated Security=True")
        ////{
        ////}

        public DataContext(string connectionString)
            : base(connectionString)
        //:base(@"Data Source=STAS-PC\SQLEXPRESS;Initial Catalog=TEST_DB;Integrated Security=True")
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
