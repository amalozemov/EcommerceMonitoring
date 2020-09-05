using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data.EF
{
    internal class CommonRepository : ICommonRepository
    {
        DataContext _dbContext;

        public CommonRepository(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public T FindById<T>(long id) where T : Entity
        {
            return _dbContext.Set<T>().Where(p => p.Id == id).FirstOrDefault(); 
        }

        public IEnumerable<T> GetEntities<T>() where T : Entity
        {
            return _dbContext.Set<T>().Select(p => p);
        }

        public IEnumerable<T> GetEntities<T>(Expression<Func<T, bool>> expr, bool includeInactive = false) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T GetEntity<T>(Expression<Func<T, bool>> expr, bool includeInactive = false) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
