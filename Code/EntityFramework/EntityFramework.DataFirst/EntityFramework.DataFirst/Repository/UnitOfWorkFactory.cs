using EntityFramework.DataFirst.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DataFirst.Repository
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        string _connectionString;// = @"Data Source=STAS-PC\SQLEXPRESS;Initial Catalog=TEST_DB;Integrated Security=True";

        public UnitOfWorkFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IUnitOfWork Create()
        {
            var dbContext = new DataContext(_connectionString);
            return new UnitOfWork(dbContext);
        }
    }
}
