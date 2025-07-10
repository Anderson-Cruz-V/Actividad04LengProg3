using Actividad4LengProg3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Actividad4LengProg3.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MiContexto>
    {
        public MiContexto CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connStr = config.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<MiContexto>();
            builder.UseSqlServer(connStr);

            return new MiContexto(builder.Options);
        }
    }
}


