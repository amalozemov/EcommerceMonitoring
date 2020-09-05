using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
