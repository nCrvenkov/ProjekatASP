using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(80).IsRequired();

            builder.HasMany(x => x.Ratings)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);  

            builder.HasMany(x => x.Posts)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Image)
                   .WithOne(x => x.User)
                   .HasForeignKey<User>(x => x.ImageId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.UseCases)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
