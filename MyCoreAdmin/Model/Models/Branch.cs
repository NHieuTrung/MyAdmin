using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Product = new HashSet<Product>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
