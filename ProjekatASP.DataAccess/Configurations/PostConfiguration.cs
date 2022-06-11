using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess.Configurations
{
    public class PostConfiguration : EntityConfiguration<Post>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Post> builder)
        {

            builder.HasIndex(x => x.Title).IsUnique();

            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Content).IsRequired();

            builder.HasMany(x => x.Ratings)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PostTags)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PostImages)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
