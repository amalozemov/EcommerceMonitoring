using ECMonitoring.Data;
using ECMonitoring.Data.Cryptography;
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
        IUnitOfWorkFactory _unitOfWorkFactory;

        public FormAuthProvider(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public bool Authenticate(string userName, string password)
        {
            var enc = new SHA1Encryption();
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var user = 
                    repository.GetEntities<User>().Where(u => u.Login == userName && 
                    enc.DecryptData(u.Password) == password).FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(userName, true);
                }
                return user != null;
            }
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
