using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SocialDemo.Models
{
  public class SocialDemoContextFactory : IDesignTimeDbContextFactory<SocialDemoContext>
  {

    SocialDemoContext IDesignTimeDbContextFactory<SocialDemoContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SocialDemoContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new SocialDemoContext(builder.Options);
    }
  }
}