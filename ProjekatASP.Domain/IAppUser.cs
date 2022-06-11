using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public interface IAppUser
    {
        public string Identity { get; }
        public int Id { get; }
        public IEnumerable<int> UseCaseIds { get; }
        public string Email { get; }
        public int RoleId { get; }
    }
}
