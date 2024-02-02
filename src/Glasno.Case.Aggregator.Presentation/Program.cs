using System.Reflection;
using Glasno.Case.Aggregator.Application;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr;
using Glasno.Case.Aggregator.Infrastructure;
using Glasno.Case.Aggregator.Presentation.Controllers;
using MediatR;

namespace Glasno.Case.Aggregator.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddApplication();
        builder.Services.AddKadArbitrProvider();
        builder.Services.AddInfrastructure();
        builder.Services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}