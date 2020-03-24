using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SocialDemo.Models
{
  public class SocialDemoContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Post> Posts {get;set;}
    public DbSet<Comment> Comments {get;set;}

    public SocialDemoContext(DbContextOptions options) : base(options) { }
  }
}