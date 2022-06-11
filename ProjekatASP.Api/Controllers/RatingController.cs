using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {
        private UseCaseHandler _handler;
        public RatingController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddRatingDto dto, [FromServices]IAddRatingCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IDeleteRatingCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
