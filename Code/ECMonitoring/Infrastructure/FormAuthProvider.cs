using DBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace ECMonitoring.Infrastructure
{
    public class FormAuthProvider : IAuthProvider
    {
        IRepository _repository;

        public FormAuthProvider(IRepository repository)
        {
            _repository = repository;
        }

        public bool Authenticate(string userName, string password)
        {
            var result = _repository.IsUserPresent(userName, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName, true);
            }
            return result;
        }
    }
}
