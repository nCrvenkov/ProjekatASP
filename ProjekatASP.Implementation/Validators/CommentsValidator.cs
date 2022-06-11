using FluentValidation;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System.Linq;
namespace ProjekatASP.Implementation.Validators
{
    public class CommentsValidator : AbstractValidator<AddCommentsDto>
    {
        private readonly IAppUser _user;
        public CommentsValidator(ProjekatDbContext _context, IAppUser user)
        {
            _user = user;

            RuleFor(x => x.CommentContent).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Comment can't be empty");

            RuleFor(x => x.PostId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post Id is required")
                .Must(x => _context.Posts.Any(y => y.Id == x))
                .WithMessage("Post with Id {PropertyValue} does not exist.");

            RuleFor(m => new { _user.Id, m.PostId })
                .Must(x =>
                {
                    if (_context.Comments.Any(y => y.UserId == _user.Id) && _context.Comments.Any(y => y.PostId == x.PostId))
                    {
                        return false;
                    }
                    return true;
                }).WithMessage("This user has already commented on this post");
        }
    }
}
