﻿using FluentValidation;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class PostsValidator : AbstractValidator<AddPostDto>
    {
        public PostsValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.Title).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(3).WithMessage("Minimum Title length is 3 characters")
                .Must(title => !context.Posts.Any(y => y.Title == title && y.IsActive))
                    .WithMessage("Title {PropertyValue} is already in use");

            RuleFor(x => x.Content).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content is required")
                .MinimumLength(15).WithMessage("Minimum content length is 15 characters");

            RuleFor(x => x.CategoryId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category id is required")
                .Must(category => context.Categories.Any(y => y.Id == category && y.IsActive))
                    .WithMessage("Category {PropertyValue} is not found");

            RuleFor(x => x.Tags).Cascade(CascadeMode.Stop)
                .Must(x => x.Count() >= 1).WithMessage("You have to add at least one tag")
                .Must(x => x.Count() < 5).WithMessage("You cannot add more than 4 tags")
                .When(x => x.Tags != null && x.Tags.Any())
                .Must(tags =>
                {
                    if (tags == null)
                    {
                        return true;
                    }

                    return tags.Distinct().Count() == tags.Count();
                }).WithMessage("Duplicate tag names are not allowed").DependentRules(() =>
                {
                    RuleForEach(x => x.Tags).NotEmpty().WithMessage("Tag name should not be empty.");
                });
        }
    }
}
