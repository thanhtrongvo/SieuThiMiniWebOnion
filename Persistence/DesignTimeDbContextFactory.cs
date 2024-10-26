using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Hshop2023Context>
    {
        public Hshop2023Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Hshop2023Context>();

            // Điều chỉnh đường dẫn tới appsettings.json của dự án WebMiniShop
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "WebMiniShop"))  // Điều chỉnh đúng với dự án WebMiniShop
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new Hshop2023Context(optionsBuilder.Options);
        }
    }
}
