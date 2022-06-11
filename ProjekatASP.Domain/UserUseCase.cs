using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class UserUseCase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public virtual User User { get; set; }
    }
}
