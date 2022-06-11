using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.UseCases.Queries
{
    public class FindCategoryQuery : EfUseCase, IFindCategoryQuery
    {
        public FindCategoryQuery(ProjekatDbContext context) : base(context)
        {

        }
        public int Id => 4;

        public string Name => "Find category query";

        public string Description => "Query used for selecting category by Id.";

        public CategoryDto Execute(int id)
        {
            var query = Context.Categories.Find(id);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Category), id);
            }



            return new CategoryDto
            {
                Id = query.Id,
                Name = query.Name,
                Description = query.Description,
                Posts = query.Posts.Select(x => new FindCategoryUserPostDto
                {
                    Title = x.Title,
                    ContentExcerpt = x.Content.Remove(15),
                    TagList = x.PostTags.Select(y => y.Tag.TagName),
                    AverageRating = x.Ratings.Select(z => z.RatingValue).DefaultIfEmpty(0).Average()
                })
            };
        }
    }
}
