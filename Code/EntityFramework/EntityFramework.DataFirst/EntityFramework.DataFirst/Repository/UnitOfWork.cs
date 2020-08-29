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
    /// http://sonyks2007.blogspot.com/2015/10/unit-of-work.html
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dbContext;
        private ICommonRepository _commonRepository;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
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
