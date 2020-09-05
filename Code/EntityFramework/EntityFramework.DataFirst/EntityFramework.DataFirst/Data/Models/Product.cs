using EntityFramework.DataFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DataFirst.Data.Models
{
    public class Product : Entity
    {
        //public long Id { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public long? OrderId { get; set; }
        public long? ProductTypeId { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
