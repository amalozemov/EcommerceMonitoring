using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data
{
    public interface ICommonRepository
    {
        T FindById<T>(long id) where T : Entity;

        T GetEntity<T>(Expression<Func<T, bool>> expr, bool includeInactive = false) where T : Entity;       

        IEnumerable<T> GetEntities<T>() where T : Entity;
        
        IEnumerable<T> GetEntities<T>(Expression<Func<T, bool>> expr, bool includeInactive = false) where T : Entity;

        void Add<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;

    }
}
