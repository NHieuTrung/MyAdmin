using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            ProductAttribute = new HashSet<ProductAttribute>();
        }

        public int AttributeId { get; set; }
        public int? TypeId { get; set; }
        public string AttributeName { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttribute { get; set; }
    }
}
