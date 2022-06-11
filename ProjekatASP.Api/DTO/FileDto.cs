using Microsoft.AspNetCore.Http;
using ProjekatASP.Application.UseCases.DTO;

namespace ProjekatASP.Api.DTO
{
    public class AddPostApiDto : AddPostDto
    {
        public IFormFile Image { get; set; }
    }
    public class RegisterApiDto : RegisterDto
    {
        public IFormFile ImagePath { get; set; }
    }
}
