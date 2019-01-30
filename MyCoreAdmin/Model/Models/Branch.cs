using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Type = new HashSet<Type>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public virtual ICollection<Type> Type { get; set; }
    }
}
