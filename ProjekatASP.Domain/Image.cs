using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Image : Entity
    {
        public string Path { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();
    }
}
