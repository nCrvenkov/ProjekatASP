using FluentValidation;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class AddTagCommand : EfUseCase, IAddTagCommand
    {
        private readonly TagValidator _validator;
        private readonly IAppUser _user;
        public AddTagCommand(ProjekatDbContext context, TagValidator validator, IAppUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 1;

        public string Name => "Add Tag";

        public string Description => "Adding Tag, only allowed to admin";

        public void Execute(AddTagDto Tag)
        {
            if (_user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }
            _validator.ValidateAndThrow(Tag);

            var tag = new Tag
            {
                TagName = Tag.TagName.Trim()
            };

            Context.Tags.Add(tag);
            Context.SaveChanges();

        }
    }
}
