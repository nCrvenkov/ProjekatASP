using FluentValidation;
using ProjekatASP.Application.Emails;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System.Collections.Generic;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class RegisterUserCommand : EfUseCase, IRegistrationCommand
    {
        private readonly RegistrationValidator _validator;
        private readonly IEmailSender _sender;
        public RegisterUserCommand(ProjekatDbContext context, RegistrationValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 5;

        public string Name => "User registration";

        public string Description => "User registration used by Anonymous users";

        public void Execute(RegisterDto request)
        {
            _validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = hash,
                RoleId = 3 
            };

            if (!string.IsNullOrEmpty(request.ImagePathName))
            {
                var newImage = new Image
                {
                    Path = request.ImagePathName
                };
                user.Image = newImage;
            }
            Context.Users.Add(user);

            var useCases = new List<UserUseCase>
            {
                new UserUseCase  { User = user, UseCaseId = 3 },
                new UserUseCase  { User = user, UseCaseId = 4 }
            };

            Context.UserUseCases.AddRange(useCases);

            Context.SaveChanges();

            _sender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration!",
                Body = "Dear " + request.Username + "\n Please activate your account...."
            });
        }
    }
}
