using Microsoft.EntityFrameworkCore;
using PropostaService.Adapters.Data;
using PropostaService.Adapters.Persistence;
using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Application.UseCases;
using PropostaService.Core.Domain.Interfaces;

namespace PropostaService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers();
            // Configuração do Entity Framework Core
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<PropostaDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
            builder.Services.AddScoped<ICriarPropostaUseCase, CriarPropostaUseCase>();
            builder.Services.AddScoped<IListarPropostasUseCase, ListarPropostasUseCase>();
            builder.Services.AddScoped<IAlterarStatusPropostaUseCase, AlterarStatusPropostaUseCase>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
