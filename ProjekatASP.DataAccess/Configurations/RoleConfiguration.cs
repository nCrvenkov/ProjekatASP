using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(x => x.Users)
                   .WithOne(x => x.Role)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
