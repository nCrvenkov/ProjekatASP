using Microsoft.AspNetCore.Mvc;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDataController : ControllerBase
    {
        
        // POST api/<AddDataController>
        [HttpPost]
        public void Post()
        {
            var context = new ProjekatDbContext();

            var roles = new List<Role>
            {
                new Role { RoleName = "Admin" },
                new Role { RoleName = "Moderator" },
                new Role { RoleName = "Reader" }
            };

            var images = new List<Image>
            {
                new Image { Path = "pathdoslike1.jpg"},
                new Image { Path = "pathdoslike2.jpg"},
                new Image { Path = "pathdoslike3.jpg"},
                new Image { Path = "pathdoslike4.jpg"},
                new Image { Path = "pathdoslike5.jpg"},
                new Image { Path = "pathdoslike6.jpg"},
                new Image { Path = "pathdoslike7.jpg"},
                new Image { Path = "pathdoslike8.jpg"},
                new Image { Path = "pathdoslike9.jpg"},
                new Image { Path = "pathdoslike10.jpg"},
                new Image { Path = "pathdoslike11.jpg"},
                new Image { Path = "pathdoslike12.jpg"},
                new Image { Path = "pathdoslike13.jpg"},
            };

            var users = new List<User>
            {
                new User { FirstName = "Nikola", LastName = "Nikolic", Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin"), Email = "admin@gmail.com", Role = roles.First(), Image = null},
                new User { FirstName = "Marko", LastName = "Markovic", Username = "mare", Password = BCrypt.Net.BCrypt.HashPassword("marepass"), Email = "mare@gmail.com", Role = roles.ElementAt(1), Image = images.ElementAt(0)},
                new User { FirstName = "Ivana", LastName = "Ivanovic", Username = "iva", Password = BCrypt.Net.BCrypt.HashPassword("ivapass"), Email = "iva@gmail.com", Role = roles.ElementAt(1), Image = images.ElementAt(1)},
                new User { FirstName = "Aleksa", LastName = "Aleksic", Username = "aki", Password = BCrypt.Net.BCrypt.HashPassword("akipass"), Email = "aki@gmail.com", Role = roles.ElementAt(2), Image = null},
                new User { FirstName = "Jovana", LastName = "Jovanovic", Username = "joki", Password = BCrypt.Net.BCrypt.HashPassword("jokipass"), Email = "joki@gmail.com", Role = roles.ElementAt(2), Image = images.ElementAt(2)},
                new User { FirstName = "Lazar", LastName = "Lazarevic", Username = "laza", Password = BCrypt.Net.BCrypt.HashPassword("lazapass"), Email = "laza@gmail.com", Role = roles.ElementAt(2), Image = null}
            };

            var categories = new List<Category>
            {
                new Category { Name = "Kulinarstvo", Description = "Postovi o kulinarstvu" },
                new Category { Name = "Pcelarstvo", Description = "Postovi o pcelarstvu" },
                new Category { Name = "Cvecarstvo", Description = "Postovi o cvecarstvu" }
            };

            var posts = new List<Post>
            {
                new Post { Title = "Kulinarstvo1", Content = "Post o kulinarstvu br1", User = users.ElementAt(1), Category = categories.ElementAt(0)},
                new Post { Title = "Kulinarstvo2", Content = "Post o kulinarstvu br2", User = users.ElementAt(2), Category = categories.ElementAt(0)},
                new Post { Title = "Kulinarstvo3", Content = "Post o kulinarstvu br3", User = users.ElementAt(1), Category = categories.ElementAt(0)},
                new Post { Title = "Pcelarstvo1", Content = "Post o pcelarstvu br1", User = users.ElementAt(2), Category = categories.ElementAt(1)},
                new Post { Title = "Pcelarstvo2", Content = "Post o pcelarstvu br2", User = users.ElementAt(1), Category = categories.ElementAt(1)},
                new Post { Title = "Pcelarstvo3", Content = "Post o pcelarstvu br3", User = users.ElementAt(2), Category = categories.ElementAt(1)},
                new Post { Title = "Cvecarstvo1", Content = "Post o cvecarstvu br1", User = users.ElementAt(1), Category = categories.ElementAt(2)},
                new Post { Title = "Cvecarstvo2", Content = "Post o cvecarstvu br2", User = users.ElementAt(2), Category = categories.ElementAt(2)},
                new Post { Title = "Cvecarstvo3", Content = "Post o cvecarstvu br3", User = users.ElementAt(1), Category = categories.ElementAt(2)},
            };

            var tags = new List<Tag>
            {
                new Tag { TagName = "New" },
                new Tag { TagName = "Old" },
                new Tag { TagName = "Fresh" },
                new Tag { TagName = "NeedToSee" },
                new Tag { TagName = "Blessed" },
                new Tag { TagName = "Follow" },
                new Tag { TagName = "Nice" },
                new Tag { TagName = "Awesome" }
            };

            var postTags = new List<PostTag>
            {
                new PostTag { Post = posts.ElementAt(8), Tag = tags.ElementAt(0)},
                new PostTag { Post = posts.ElementAt(7), Tag = tags.ElementAt(1)},
                new PostTag { Post = posts.ElementAt(6), Tag = tags.ElementAt(2)},
                new PostTag { Post = posts.ElementAt(5), Tag = tags.ElementAt(3)},
                new PostTag { Post = posts.ElementAt(4), Tag = tags.ElementAt(4)},
                new PostTag { Post = posts.ElementAt(3), Tag = tags.ElementAt(5)},
                new PostTag { Post = posts.ElementAt(2), Tag = tags.ElementAt(6)},
                new PostTag { Post = posts.ElementAt(1), Tag = tags.ElementAt(7)},
                new PostTag { Post = posts.ElementAt(0), Tag = tags.ElementAt(6)},
                new PostTag { Post = posts.ElementAt(1), Tag = tags.ElementAt(5)},
                new PostTag { Post = posts.ElementAt(2), Tag = tags.ElementAt(4)},
                new PostTag { Post = posts.ElementAt(3), Tag = tags.ElementAt(3)},
            };

            var postImages = new List<PostImage>
            {
                new PostImage { Post = posts.ElementAt(0), Image = images.ElementAt(3) },
                new PostImage { Post = posts.ElementAt(1), Image = images.ElementAt(4) },
                new PostImage { Post = posts.ElementAt(2), Image = images.ElementAt(5) },
                new PostImage { Post = posts.ElementAt(3), Image = images.ElementAt(6) },
                new PostImage { Post = posts.ElementAt(4), Image = images.ElementAt(7) },
                new PostImage { Post = posts.ElementAt(4), Image = images.ElementAt(8) },
                new PostImage { Post = posts.ElementAt(6), Image = images.ElementAt(9) },
                new PostImage { Post = posts.ElementAt(7), Image = images.ElementAt(10) },
                new PostImage { Post = posts.ElementAt(7), Image = images.ElementAt(11) },
                new PostImage { Post = posts.ElementAt(0), Image = images.ElementAt(4) },
                new PostImage { Post = posts.ElementAt(1), Image = images.ElementAt(5) },
            };

            var ratings = new List<Rating>
            {
                new Rating { User = users.ElementAt(3), Post = posts.ElementAt(1), RatingValue = 3},
                new Rating { User = users.ElementAt(4), Post = posts.ElementAt(2), RatingValue = 4},
                new Rating { User = users.ElementAt(5), Post = posts.ElementAt(2), RatingValue = 5},
                new Rating { User = users.ElementAt(3), Post = posts.ElementAt(4), RatingValue = 3},
                new Rating { User = users.ElementAt(4), Post = posts.ElementAt(4), RatingValue = 4},
                new Rating { User = users.ElementAt(5), Post = posts.ElementAt(5), RatingValue = 5},
                new Rating { User = users.ElementAt(3), Post = posts.ElementAt(6), RatingValue = 3},
                new Rating { User = users.ElementAt(4), Post = posts.ElementAt(6), RatingValue = 4},
                new Rating { User = users.ElementAt(5), Post = posts.ElementAt(6), RatingValue = 5},
                new Rating { User = users.ElementAt(3), Post = posts.ElementAt(7), RatingValue = 3},
                new Rating { User = users.ElementAt(4), Post = posts.ElementAt(7), RatingValue = 4},
                new Rating { User = users.ElementAt(5), Post = posts.ElementAt(7), RatingValue = 5},
                new Rating { User = users.ElementAt(3), Post = posts.ElementAt(5), RatingValue = 5},
                new Rating { User = users.ElementAt(3), Post = posts.ElementAt(2), RatingValue = 5}
            };

            var comments = new List<Comment>
            {
                new Comment { User = users.ElementAt(1), Post = posts.ElementAt(0), CommentContent = "Komentar1"},
                new Comment { User = users.ElementAt(2), Post = posts.ElementAt(1), CommentContent = "Komentar2"},
                new Comment { User = users.ElementAt(3), Post = posts.ElementAt(3), CommentContent = "Komentar3"},
                new Comment { User = users.ElementAt(4), Post = posts.ElementAt(3), CommentContent = "Komentar4"},
                new Comment { User = users.ElementAt(5), Post = posts.ElementAt(4), CommentContent = "Komentar5"},
                new Comment { User = users.ElementAt(3), Post = posts.ElementAt(5), CommentContent = "Komentar6"},
                new Comment { User = users.ElementAt(4), Post = posts.ElementAt(5), CommentContent = "Komentar7"},
                new Comment { User = users.ElementAt(5), Post = posts.ElementAt(6), CommentContent = "Komentar8"},
                new Comment { User = users.ElementAt(3), Post = posts.ElementAt(6), CommentContent = "Komentar9"},
                new Comment { User = users.ElementAt(4), Post = posts.ElementAt(7), CommentContent = "Komentar10"},
                new Comment { User = users.ElementAt(5), Post = posts.ElementAt(7), CommentContent = "Komentar11"},
                new Comment { User = users.ElementAt(3), Post = posts.ElementAt(8), CommentContent = "Komentar12"},
            };

            context.Roles.AddRange(roles);
            context.Images.AddRange(images);
            context.Users.AddRange(users);
            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.Tags.AddRange(tags);
            context.PostTags.AddRange(postTags);
            context.PostImages.AddRange(postImages);
            context.Ratings.AddRange(ratings);
            context.Comments.AddRange(comments);

            context.SaveChanges();
            
        }

    }
}
