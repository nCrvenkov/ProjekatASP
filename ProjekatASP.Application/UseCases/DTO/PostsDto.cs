﻿using System.Collections.Generic;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class PostsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<string> TagList { get; set; }
        public double? AverageRating { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
    public class FindPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public IEnumerable<string> TagList { get; set; }
        public double AverageRating { get; set; }
        public IEnumerable<string> Images { get; set; }
        public IEnumerable<FindPostCommentsDto> Comments { get; set; }
    }
    public class AddPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string ImageFileName { get; set; }
    }
    public class FindCategoryUserPostDto
    {
        public string Title { get; set; }
        public string ContentExcerpt { get; set; }
        public IEnumerable<string> TagList { get; set; }
        public double? AverageRating { get; set; }
    }
}
