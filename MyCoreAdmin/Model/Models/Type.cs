using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Type
    {
        public Type()
        {
            Attribute = new HashSet<Attribute>();
            Product = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Attribute> Attribute { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
