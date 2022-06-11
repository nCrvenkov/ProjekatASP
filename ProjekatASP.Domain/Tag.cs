using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Tag : Entity
    {
        public string TagName { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
