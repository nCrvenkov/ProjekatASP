using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System.Linq;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class DeletePostCommand : EfUseCase, IDeletePostCommand
    {
        private readonly IAppUser _user;
        public DeletePostCommand(ProjekatDbContext context, IAppUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 2;

        public string Name => "Delete post";

        public string Description => "Allowed for moderator who posted it, and admin";

        public void Execute(int request)
        {
            var post = Context.Posts.Find(request);

            if (post == null)
            {
                throw new EntityNotFoundException(nameof(Post), request);
            }

            if (_user.Id != post.UserId && _user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            Context.Posts.Remove(post);

            Context.SaveChanges();
        }
    }
}
