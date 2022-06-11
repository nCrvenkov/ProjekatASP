using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class DeleteRatingCommand : EfUseCase, IDeleteRatingCommand
    {
        private readonly IAppUser _user;
        public DeleteRatingCommand(ProjekatDbContext context, IAppUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 3;

        public string Name => "Delete Rating command";

        public string Description => "Rating delete is allowed to user who made it, and admin";

        public void Execute(int request)
        {
            var rating = Context.Ratings.Find(request);
            
            if (rating == null)
            {
                throw new EntityNotFoundException(nameof(Rating), request);
            }
            if (_user.Id != rating.UserId)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            Context.Ratings.Remove(rating);

            Context.SaveChanges();
        }
    }
}
