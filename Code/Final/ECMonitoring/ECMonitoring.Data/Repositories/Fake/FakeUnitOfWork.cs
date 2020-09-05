using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECMonitoring.Data.Fake
{
    /// <summary>
    /// http://sonyks2007.blogspot.com/2015/10/unit-of-work.html
    /// </summary>
    internal class FakeUnitOfWork : IUnitOfWork
    {
        private ICommonRepository _commonRepository;

        internal FakeUnitOfWork()
        {
            _commonRepository = new FakeCommonRepository();
        }

        ~FakeUnitOfWork()
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
                
            }
        }

        public ICommonRepository GetRepository()
        {
            return _commonRepository;
        }

        public void Commit()
        {
            
        }

        public void Rollback()
        {
        }
    }
}
