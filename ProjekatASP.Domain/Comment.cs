using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Comment : Entity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CommentContent { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
