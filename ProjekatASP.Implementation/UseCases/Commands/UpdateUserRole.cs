﻿using FluentValidation;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Linq;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class UpdateUserRole : EfUseCase, IUpdateUserRole
    {
        private UpdateUserRoleValidator _validator;

        public UpdateUserRole(ProjekatDbContext context, UpdateUserRoleValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 1;

        public string Name => "Update user role command";

        public string Description => "Used only by admin to promote Subscriber to Moderator";

        public void Execute(UpdateUserRoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var existingRoleId = Context.Users.Where(x => x.Id == request.UserId).Select(x => x.RoleId).FirstOrDefault();

            if(existingRoleId != 3)
            {
                throw new Exception("User has to be Subscriber to be updated to Moderator");
            }

            var user = new User { Id = request.UserId, RoleId = 2 };
            
            Context.Users.Attach(user).Property(x => x.RoleId).IsModified = true;

            var addUseCase = new UserUseCase { UserId = request.UserId, UseCaseId = 2 };

            Context.UserUseCases.Add(addUseCase);

            Context.SaveChanges();

            
        }
    }
}
