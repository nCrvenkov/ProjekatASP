using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int? ImageId { get; set; }

        public virtual ICollection<UserUseCase> UseCases { get; set; }
        public virtual Role Role { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
