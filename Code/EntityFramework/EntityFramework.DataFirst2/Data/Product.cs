//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework.DataFirst2.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<long> OrderId { get; set; }
        public Nullable<long> ProductTypeId { get; set; }

        ////public TypeProduct TypeProduct
        ////{
        ////    get 
        ////    {
        ////        return ProductType.Value;
        ////    }
        ////    set
        ////    {
        ////        if (ProductType == null)
        ////        {
        ////            ProductType = new ProductType()
        ////            {
        ////            }
        ////        }
        ////        ProductType.Value = value;
        ////    }
        ////}

        public virtual Order Order { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
