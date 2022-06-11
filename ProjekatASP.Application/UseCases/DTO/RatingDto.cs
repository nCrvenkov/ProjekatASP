using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class AddRatingDto
    {
        public int PostId { get; set; }
        public int RatingValue { get; set; }
    }
}
