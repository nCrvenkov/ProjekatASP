using FluentValidation;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;

namespace ProjekatASP.Implementation.Validators
{
    public class TagValidator : AbstractValidator<AddTagDto>
    {
        public TagValidator(ProjekatDbContext context)
        {
            var TagRegex = "^[A-Z][A-z]*$";
            RuleFor(x => x.TagName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Tag name is required")
                .Matches(TagRegex.Trim()).WithMessage("Tag must be one word with a Capital letter and without any special signs or numbers");
        }
    }
}
