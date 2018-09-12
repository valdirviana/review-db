using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ReviewDB.Infra.Data
{
    public class DesignTimeReviewDBContextFactory : IDesignTimeDbContextFactory<ReviewDBContext>
    {
        public ReviewDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ReviewDBContext>();
            var connectionString = configuration.GetConnectionString("ReviewDBConnection");
            builder.UseSqlServer(connectionString);
            return new ReviewDBContext(builder.Options);
        }
    }
}
