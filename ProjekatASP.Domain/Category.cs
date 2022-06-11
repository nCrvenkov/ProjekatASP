using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
