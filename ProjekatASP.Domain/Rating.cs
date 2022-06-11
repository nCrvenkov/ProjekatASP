using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Rating : Entity
    {
        public int? UserId { get; set; }
        public int PostId { get; set; }
        public int RatingValue { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
