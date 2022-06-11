using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases.DTO
{
    
    public class FindUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? Image { get; set; }
        public IEnumerable<UsersCommentDto> Comments { get; set; }
        public IEnumerable<UsersRatingDto> Ratings { get; set; }
    }
    public class FindAdminModeratorDto : FindUserDto
    {
        public IEnumerable<FindCategoryUserPostDto> Posts { get; set; }
    }
    public class UsersCommentDto
    {
        public string PostTitle { get; set; }
        public string CommentContent { get; set; }
    }
    public class UsersRatingDto
    {
        public string PostTitle { get; set; }
        public int Rating { get; set; }
    }
    public class UpdateUserRoleDto
    {
        public int UserId { get; set; }
    }
}
