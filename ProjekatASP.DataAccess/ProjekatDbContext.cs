using Microsoft.EntityFrameworkCore;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess
{
    public class ProjekatDbContext : DbContext
    {
        public ProjekatDbContext(DbContextOptions options = null) : base(options)
        {

        }
        public IAppUser User { get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<PostTag>().HasKey(x => new { x.PostId, x.TagId });
            modelBuilder.Entity<PostImage>().HasKey(x => new { x.PostId, x.ImageId});
            modelBuilder.Entity<UserUseCase>().HasKey(x => new {x.UserId, x.UseCaseId});
            modelBuilder.Entity<Comment>().Property(x => x.CommentContent).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjekatASPdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }*/


        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User?.Identity;
                            break;
                        case EntityState.Deleted:
                            e.DeletedAt = DateTime.UtcNow;
                            e.DeletedBy = User?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
