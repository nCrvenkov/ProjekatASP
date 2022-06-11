using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess.Configurations
{
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(150).IsRequired();

            builder.HasMany(x => x.Posts)
                   .WithOne(x => x.Category)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
