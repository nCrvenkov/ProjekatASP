using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class AddCommentsDto
    {
        public int PostId { get; set; }
        public string CommentContent { get; set; }
    }
    public class FindPostCommentsDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string CommentContent { get; set; }
    }
}
