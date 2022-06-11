using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess.Configurations
{
    public class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).IsRequired().HasMaxLength(150);

            builder.HasMany(x => x.PostImages)
                   .WithOne(x => x.Image)
                   .HasForeignKey(x => x.ImageId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
