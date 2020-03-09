using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models.ECommerce
{
    public class DBContext : DbContext
    {
        public DBContext() : base("eCommerce")
        { }

    }
}

//