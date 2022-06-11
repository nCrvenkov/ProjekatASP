using FluentValidation;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class RatingValidator : AbstractValidator<AddRatingDto>
    {
        private readonly IAppUser _user;
        public RatingValidator(ProjekatDbContext _context, IAppUser user)
        {
            _user = user;
            var ValueRegex = @"^[1-5]$";
            RuleFor(x => x.RatingValue).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Rating value can't be empty")
                .InclusiveBetween(1, 5).WithMessage("Rating must be number between 1 and 5");

            RuleFor(x => x.PostId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("User Id is required")
                .Must(x => _context.Posts.Any(y => y.Id == x))
                .WithMessage("Post with Id {PropertyValue} does not exist.");

            RuleFor(m => new { _user.Id, m.PostId })
                .Must(x =>
                {
                    if (_context.Ratings.Any(y => y.UserId == _user.Id) && _context.Ratings.Any(y => y.PostId == x.PostId))
                    {
                        return false;
                    }
                    return true;
                }).WithMessage("This user has already rated this post");
        }
    }
}
