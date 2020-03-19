using Microsoft.EntityFrameworkCore;

namespace SocialDemo.Models
{
  public class SocialDemoContext : DbContext
  {
    public virtual DbSet<Post> Posts {get;set;}
    public DbSet<Comment> Comments {get;set;}

    public SocialDemoContext(DbContextOptions options) : base(options) { }
  }
}