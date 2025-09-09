using Microsoft.EntityFrameworkCore;
using PropostaService.Adapters.Data;
using PropostaService.Adapters.Persistence;
using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Application.UseCases;
using PropostaService.Core.Domain.Interfaces;
using System.Text.Json;

namespace PropostaService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Configuração do Entity Framework Core
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<PropostaDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
            builder.Services.AddScoped<ICriarPropostaUseCase, CriarPropostaUseCase>();
            builder.Services.AddScoped<IListarPropostasUseCase, ListarPropostasUseCase>();
            builder.Services.AddScoped<IAlterarStatusPropostaUseCase, AlterarStatusPropostaUseCase>();            

            var app = builder.Build();            

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
