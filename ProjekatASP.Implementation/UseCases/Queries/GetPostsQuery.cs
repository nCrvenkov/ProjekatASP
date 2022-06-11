using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.DTO.Searches;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjekatASP.Implementation.UseCases.Queries
{
    public class GetPostsQuery : EfUseCase, IGetPostsQuery
    {
        public GetPostsQuery(ProjekatDbContext context) : base(context)
        {

        }
        public int Id => 4;

        public string Name => "Dohvatanje postova";

        public string Description => "";
        

        public PagedResponse<PostsDto> Execute(BasePagedSearch search)
        {
            var query = Context.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.Contains(search.Keyword) || x.PostTags.Select(y => y.Tag.TagName).Contains(search.Keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<PostsDto>();

            response.TotalCount = query.Count();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new PostsDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                TagList = x.PostTags.Select(y => y.Tag.TagName),
                AverageRating = x.Ratings.Select(r => r.RatingValue).Average(),
                Images = x.PostImages.Select(z => z.Image.Path)
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;

        }
    }
}
