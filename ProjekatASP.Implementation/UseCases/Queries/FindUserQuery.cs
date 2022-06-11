using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Linq;

namespace ProjekatASP.Implementation.UseCases.Queries
{
    public class FindUserQuery : EfUseCase, IFindUserQuery
    {
        private readonly IAppUser _user;
        public FindUserQuery(ProjekatDbContext context, IAppUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 3;

        public string Name => "Find post query";

        public string Description => "Query used for selecting user by Id.";

        public FindUserDto Execute(int id)
        {
            var query = Context.Users.Find(id);

            if(_user.RoleId != 1 && _user.Id != query.Id)
            {
                throw new UnauthorizedAccessException();
            }
            if (query == null)
            {
                throw new EntityNotFoundException(nameof(User), id);
            }


            if (query.ImageId == null)
            {
                if (_user.RoleId != 3)
                {
                    return new FindAdminModeratorDto
                    {
                        Id = query.Id,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        Username = query.Username,
                        Email = query.Email,
                        Role = query.Role.RoleName,
                        Posts = query.Posts.Select(x => new FindCategoryUserPostDto
                        {
                            Title = x.Title,
                            ContentExcerpt = x.Content.Remove(15),
                            TagList = x.PostTags.Select(y => y.Tag.TagName),
                            AverageRating = x.Ratings.Select(z => z.RatingValue).DefaultIfEmpty(0).Average()
                        }),
                        Comments = query.Comments.Select(x => new UsersCommentDto
                        {
                            PostTitle = x.Post.Title,
                            CommentContent = x.CommentContent
                        }),
                        Ratings = query.Ratings.Select(x => new UsersRatingDto
                        {
                            PostTitle = x.Post.Title,
                            Rating = x.RatingValue
                        })
                    };
                }
                else
                {
                    return new FindUserDto
                    {
                        Id = query.Id,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        Username = query.Username,
                        Email = query.Email,
                        Role = query.Role.RoleName,
                        Comments = query.Comments.Select(x => new UsersCommentDto
                        {
                            PostTitle = x.Post.Title,
                            CommentContent = x.CommentContent
                        }),
                        Ratings = query.Ratings.Select(x => new UsersRatingDto
                        {
                            PostTitle = x.Post.Title,
                            Rating = x.RatingValue
                        })
                    };
                }
            }
            else
            {
                if (_user.RoleId != 3)
                {
                    return new FindAdminModeratorDto
                    {
                        Id = query.Id,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        Username = query.Username,
                        Email = query.Email,
                        Role = query.Role.RoleName,
                        Image = query.Image.Path,
                        Posts = query.Posts.Select(x => new FindCategoryUserPostDto
                        {
                            Title = x.Title,
                            ContentExcerpt = x.Content.Remove(15),
                            TagList = x.PostTags.Select(y => y.Tag.TagName),
                            AverageRating = x.Ratings.Select(z => z.RatingValue).DefaultIfEmpty(0).Average()
                        }),
                        Comments = query.Comments.Select(x => new UsersCommentDto
                        {
                            PostTitle = x.Post.Title,
                            CommentContent = x.CommentContent
                        }),
                        Ratings = query.Ratings.Select(x => new UsersRatingDto
                        {
                            PostTitle = x.Post.Title,
                            Rating = x.RatingValue
                        })
                    };
                }
                else
                {
                    return new FindUserDto
                    {
                        Id = query.Id,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        Username = query.Username,
                        Email = query.Email,
                        Role = query.Role.RoleName,
                        Image = query.Image.Path,
                        Comments = query.Comments.Select(x => new UsersCommentDto
                        {
                            PostTitle = x.Post.Title,
                            CommentContent = x.CommentContent
                        }),
                        Ratings = query.Ratings.Select(x => new UsersRatingDto
                        {
                            PostTitle = x.Post.Title,
                            Rating = x.RatingValue
                        })
                    };
                }
            }
        }
    }
}
