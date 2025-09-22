using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {        
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
       
            var webProjectPath = Path.Combine(Directory.GetCurrentDirectory());
        
            var jsonFilePath = Path.Combine(webProjectPath, $"appsettings.{environment}.json");

            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException(
                    $"Cannot find configuration file: {jsonFilePath}");
            }
                      
            var configuration = new ConfigurationBuilder()
                .SetBasePath(webProjectPath)
                .AddJsonFile(jsonFilePath, optional: false, reloadOnChange: true)
                .Build();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
           
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
