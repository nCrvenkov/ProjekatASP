using FluentValidation;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class AddCommentCommand : EfUseCase, IAddCommentCommand
    {
        private readonly CommentsValidator _validator;
        private readonly IAppUser _user;
        public AddCommentCommand(ProjekatDbContext context, CommentsValidator validator, IAppUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 3;

        public string Name => "Add Comment command";

        public string Description => "Adding comments used by all users in system";

        public void Execute(AddCommentsDto request)
        {
            _validator.ValidateAndThrow(request);

            var comment = new Comment
            {
                UserId = _user.Id,
                PostId = request.PostId,
                CommentContent = request.CommentContent
            };

            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
    }
}
