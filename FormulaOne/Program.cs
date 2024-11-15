
using DataService.Data;
using DataService.Repositories;
using DataService.Repositories.Interfaces;
using FormulaOne.Behaviors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container

            // Adding Logs
            //var services = new ServiceCollection();
            //services.AddLogging(builder => builder.AddConsole());

            // Get connection string
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // Initialising my DbContext inside the DI Container
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adding AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Adding for interface IUnitOfWork to be recognized by my app
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Injecting the MediatR to our DI
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

            // For behavior class for logging - will be used any generic type parameters <,>
            builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

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
