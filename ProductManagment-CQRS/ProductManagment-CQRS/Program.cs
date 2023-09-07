using Microsoft.EntityFrameworkCore;
using ProductManagment_CQRS.Entity;
using ProductManagment_CQRS.Interface;
using ProductManagment_CQRS.Services;

namespace ProductManagment_CQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProductDBContext>(ops =>
            {
                ops.UseSqlServer(builder.Configuration.GetConnectionString("MyStore"));
            });
            builder.Services.AddTransient<ICommandService, CommandService>();
            builder.Services.AddTransient<IQueryService, QueryService>();
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