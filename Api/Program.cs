
using Api.Configurations;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure;

namespace Api
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

            var origins = new[]
             {
                "http://localhost:5173",
            };

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(origins).AllowAnyHeader()
                                               .AllowAnyMethod()
                                               .AllowCredentials();

                });
            });

            builder.Services.AddInfrastructureService(builder.Configuration);
            builder.Services.AddApiService();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
