using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private UseCaseHandler _handler;
        public CategoryController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IFindCategoryQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddCategoryDto dto, [FromServices] IAddCategoryCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
