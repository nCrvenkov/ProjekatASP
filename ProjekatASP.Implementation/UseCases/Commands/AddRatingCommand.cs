using FluentValidation;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class AddRatingCommand : EfUseCase, IAddRatingCommand
    {
        private readonly RatingValidator _validator;
        private readonly IAppUser _user;
        public AddRatingCommand(ProjekatDbContext context, RatingValidator validator, IAppUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 3;

        public string Name => "Add rating command";

        public string Description => "Adding rating used by all users in system";

        public void Execute(AddRatingDto request)
        {
            _validator.ValidateAndThrow(request);

            var rating = new Rating
            {
                UserId = _user.Id,
                PostId = request.PostId,
                RatingValue = request.RatingValue
            };

            Context.Ratings.Add(rating);
            Context.SaveChanges();
        }
    }
}
