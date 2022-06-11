using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Domain;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppUserController : ControllerBase
    {
        public IActionResult Get([FromServices] IAppUser user)
        {
            return Ok(user);
        }
    }
}
