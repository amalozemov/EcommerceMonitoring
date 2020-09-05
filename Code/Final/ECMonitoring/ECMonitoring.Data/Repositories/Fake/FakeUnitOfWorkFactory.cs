using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data.Fake
{
    public class FakeUnitOfWorkFactory : IUnitOfWorkFactory
    {
        string _connectionString;// = @"Data Source=STAS-PC\SQLEXPRESS;Initial Catalog=TEST_DB;Integrated Security=True";

        public FakeUnitOfWorkFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IUnitOfWork Create()
        {
            return new FakeUnitOfWork();
        }
    }
}
