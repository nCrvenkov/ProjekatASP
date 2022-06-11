using FluentValidation;
using ProjekatASP.Application.Exceptions;
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
    public class AddCategoryCommand : EfUseCase, IAddCategoryCommand
    {
        private readonly CategoryValidator _validator;
        private readonly IAppUser _user;
        public AddCategoryCommand(ProjekatDbContext context, CategoryValidator validator, IAppUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 1;

        public string Name => "Add category command";

        public string Description => "Adding category used only by admin user";

        public void Execute(AddCategoryDto request)
        {
            if (_user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            Context.Categories.Add(category);
            Context.SaveChanges();
        }
    }
}
