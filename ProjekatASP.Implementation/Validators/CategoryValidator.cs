using FluentValidation;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class CategoryValidator : AbstractValidator<AddCategoryDto>
    {
        public CategoryValidator(ProjekatDbContext _context)
        {
            var CatRegex = "^[A-Z][a-z]*$";
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category name is required")
                .Matches(CatRegex.Trim()).WithMessage("Category must be one word with a Capital letter and without any special signs or numbers");

            RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category description is required")
                .MinimumLength(10).WithMessage("Description has to be more than 10 characters.");
        }
    }
}
