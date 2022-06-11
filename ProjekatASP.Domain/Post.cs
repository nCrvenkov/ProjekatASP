using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();
    }
}
