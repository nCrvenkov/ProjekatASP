using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Api.DTO;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.DTO.Searches;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PostsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery]BasePagedSearch search, [FromServices] IGetPostsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IFindPostsQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromForm] AddPostApiDto dto, [FromServices] IAddPostCommand command)
        {
            if(dto.Image != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(dto.Image.FileName);

                if (!SupportedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Invalid file extension");
                }

                var newFileName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.Image.CopyTo(fileStream);
                }

                dto.ImageFileName = newFileName;
            }

            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }

        private IEnumerable<string> SupportedExtensions =>
            new List<string> { ".png", ".jpeg", ".jpg" };
    }
}
