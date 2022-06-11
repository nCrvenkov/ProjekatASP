using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class AddCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<FindCategoryUserPostDto> Posts { get; set; }
    }
}
