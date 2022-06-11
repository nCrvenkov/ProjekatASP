using FluentValidation;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System.Collections.Generic;
using System.Linq;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class AddPostCommand : EfUseCase, IAddPostCommand
    {
        private readonly PostsValidator _validator;
        private readonly IAppUser _user;
        public AddPostCommand(ProjekatDbContext context, PostsValidator validator, IAppUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 2;

        public string Name => "Add Post command";

        public string Description => "Adding Post and corresponding Tags used by all users in system";

        public void Execute(AddPostDto request)
        {
            if (_user.RoleId == 3)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            _validator.ValidateAndThrow(request);

            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                UserId = _user.Id,
                CategoryId = request.CategoryId
            };

            var postTag = new List<PostTag>();

            foreach (var d in request.Tags)
            {
                postTag.Add(new PostTag
                {
                    Post = post,
                    TagId = Context.Tags.Where(x => x.TagName == d).Select(x => x.Id).FirstOrDefault()
                });
            }

            if (!string.IsNullOrEmpty(request.ImageFileName))
            {

                var postImage = new PostImage
                {
                    Post = post,
                    Image = new Image
                    {
                        Path = request.ImageFileName
                    }
                };
                Context.PostImages.AddRange(postImage);
            }

            Context.Posts.Add(post);
            Context.PostTags.AddRange(postTag);
            Context.SaveChanges();
        }
    }
}
