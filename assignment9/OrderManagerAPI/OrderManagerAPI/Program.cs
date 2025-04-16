using Microsoft.EntityFrameworkCore;
using OrderManagerAPI.Models;

namespace OrderManagerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json");
            var connectionString = builder.Configuration.GetConnectionString("orderDB");

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<OrdersContext>(opt =>
                opt.UseInMemoryDatabase("orderdb"));
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
