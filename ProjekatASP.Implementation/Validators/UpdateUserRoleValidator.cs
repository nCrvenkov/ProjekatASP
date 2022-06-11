using FluentValidation;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using System.Linq;

namespace ProjekatASP.Implementation.Validators
{
    public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleDto>
    {
        public UpdateUserRoleValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.UserId).Cascade(CascadeMode.Stop)
                .Must(x => context.Users.Any(u => u.Id == x && u.IsActive))
                .WithMessage("User with provided ID doesn't exist");
        }
    }
}
