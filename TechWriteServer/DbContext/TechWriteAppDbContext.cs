using Microsoft.EntityFrameworkCore;
using TechWriteServer.Models.Blog;
using TechWriteServer.Models.Tag;
using TechWriteServer.Models.User;
namespace TechWriteServer.DbContext;
public class TechWriteAppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public TechWriteAppDbContext(DbContextOptions<TechWriteAppDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Seed Data

        modelBuilder.Entity<UserType>().HasData(
         new UserType { UserTypeId = 1001, Type = "Admin" },
         new UserType { UserTypeId = 2002, Type = "User" },
         new UserType { UserTypeId = 3003, Type = "Visitor" }
         );

        #endregion

        #region Global Query Filters

        // modelBuilder.Entity<Blog>().HasQueryFilter(x => x.IsApproved == true && x.IsActive==true);
        modelBuilder.Entity<User>().HasQueryFilter(x => x.isActive == true);
        modelBuilder.Entity<Tag>().HasQueryFilter(x => x.IsActive == true);
        #endregion

        #region Model Relations
        modelBuilder.Entity<Blog>().HasOne(b => b.Tag).WithOne(t => t.Blog).HasForeignKey<Blog>(b => b.TagId);
        #endregion
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<BlogComment> blogComments {get;set;}
    public DbSet<Blog> Blogs { get; set; }
}
