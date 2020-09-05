using EntityFramework.DataFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityFramework.DataFirst.Data.Models.Enumerators;

namespace EntityFramework.DataFirst.Data.Models
{
    public class ProductType : Entity
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
        }

        //public long Id { get; set; }
        public string Description { get; set; }
        public TypeProduct? Value { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
