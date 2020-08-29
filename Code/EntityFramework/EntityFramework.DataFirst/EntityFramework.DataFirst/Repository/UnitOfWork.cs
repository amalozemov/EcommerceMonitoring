using EntityFramework.DataFirst.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EntityFramework.DataFirst.Repository
{
    /// <summary>
    /// Строку подключения брать из конфигурационного файла, а путь к конфигурационному файлу прописан жёстко.
    /// http://sonyks2007.blogspot.com/2015/10/unit-of-work.html
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dbContext;
        private ICommonRepository _commonRepository;

        public UnitOfWork()
        {
            var connectionString = @"Data Source=STAS-PC\SQLEXPRESS;Initial Catalog=TEST_DB;Integrated Security=True";
            _dbContext = new DataContext(connectionString);
            _commonRepository = new CommonRepository(_dbContext);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }
        }

        public ICommonRepository GetRepository()
        {
            return _commonRepository;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
        }
    }
}
