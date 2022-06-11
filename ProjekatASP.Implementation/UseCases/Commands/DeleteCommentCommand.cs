﻿using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class DeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {
        private readonly IAppUser _user;
        public DeleteCommentCommand(ProjekatDbContext context, IAppUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 3;

        public string Name => "Delete Comment command";

        public string Description => "Comment delete is allowed to user who made it, and admin";

        public void Execute(int request)
        { 
            var comment = Context.Comments.Find(request);
            
            if (comment == null)
            {
                throw new EntityNotFoundException(nameof(Comment), request);
            }
            if (_user.Id != comment.UserId && _user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            Context.Comments.Remove(comment);

            Context.SaveChanges();
        }
    }
}
