﻿using EntityFramework.DataFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DataFirst.Data.Models
{
    public class Order : Entity
    {
        //public long Id { get; set; }
        public Order()
        {
            this.Products = new HashSet<Product>();
        }

        public string Number { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
