using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductAttribute = new HashSet<ProductAttribute>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public int TypeId { get; set; }
        public int BranchId { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttribute { get; set; }
    }
}
