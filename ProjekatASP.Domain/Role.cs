using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
