using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess.Configurations
{
    public class TagConfiguration : EntityConfiguration<Tag>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Tag> builder)
        {
            builder.HasIndex(x => x.TagName).IsUnique();

            //builder.Property(x => x.TagName).HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.PostTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
