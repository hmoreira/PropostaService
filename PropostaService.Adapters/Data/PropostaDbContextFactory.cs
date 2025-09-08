using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Adapters.Data
{
    public class PropostaDbContextFactory : IDesignTimeDbContextFactory<PropostaDbContext>
    {
        public PropostaDbContext CreateDbContext(string[] args)
        {
            // Se você usar um arquivo appsettings.json:
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // O diretório atual será o do projeto infra
                .AddJsonFile("appsettings.json") 
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<PropostaDbContext>();
            optionsBuilder.UseSqlServer(connectionString); 

            return new PropostaDbContext(optionsBuilder.Options);
        }
    }
}
