using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases.Queries
{
    public interface IGetPostsQuery : IQuery<BasePagedSearch, PagedResponse<PostsDto>>
    {
    }
}
