using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System.Linq;

namespace ProjekatASP.Implementation.UseCases.Queries
{
    public class FindPostsQuery : EfUseCase, IFindPostsQuery
    {
        public FindPostsQuery(ProjekatDbContext context) : base(context)
        {

        }
        public int Id => 4;

        public string Name => "Find post query";

        public string Description => "Query used for selecting post by Id.";

        public FindPostDto Execute(int id)
        {
            var query = Context.Posts.Find(id);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Post), id);
            }

            if (!query.Ratings.Select(r => r.RatingValue).Any())
            {
                return new FindPostDto
                {
                    Id = query.Id,
                    Title = query.Title,
                    Author = query.User.FirstName + " " + query.User.LastName,
                    Content = query.Content,
                    TagList = query.PostTags.Select(y => y.Tag.TagName),
                    Images = query.PostImages.Select(z => z.Image.Path),
                    Comments = query.Comments.Select(c => new FindPostCommentsDto
                    {
                        Id = c.Id,
                        User = c.User.FirstName + " " + c.User.LastName,
                        CommentContent = c.CommentContent
                    })
                };
            }
            else
            {
                return new FindPostDto
                {
                    Id = query.Id,
                    Title = query.Title,
                    Author = query.User.FirstName + " " + query.User.LastName,
                    Content = query.Content,
                    TagList = query.PostTags.Select(y => y.Tag.TagName),
                    AverageRating = query.Ratings.Select(r => r.RatingValue).Average(),
                    Images = query.PostImages.Select(z => z.Image.Path),
                    Comments = query.Comments.Select(c => new FindPostCommentsDto
                    {
                        Id = c.Id,
                        User = c.User.FirstName + " " + c.User.LastName,
                        CommentContent = c.CommentContent
                    })
                };
            }
        }
    }
}
