
using Api.Configurations;
using Api.Services;
using Api.Settings;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // 1. �[�J JwtSettings �ñq appsettings.json Ū��
            var jwtSettings = builder.Configuration.GetSection(JwtSettings.Key).Get<JwtSettings>();
            builder.Services.AddSingleton(jwtSettings);
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            // 2. ���U JwtService
            builder.Services.AddScoped<JwtService>();
            builder.Services.AddScoped<CloudinaryService>();
            builder.Services.AddScoped<CourseImageService>();

            // 3. �t�m JWT ����
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // �z�L�o���ŧi�A�N�i�H�q "sub" ���Ȩó]�w�� User.Identity.Name
                        NameClaimType = ClaimTypes.NameIdentifier,

                        // �z�L�o���ŧi�A�N�i�H�q "ClaimTypes.Role" ���ȡA�åi�� [Authorize] �P�_����
                        RoleClaimType = ClaimTypes.Role,

                        // �@��ڭ̳��|���� Issuer
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer"),

                        // �q�`���ӻݭn���� Audience
                        ValidateAudience = false,

                        // �@��ڭ̳��|���� Token �����Ĵ���
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,  // �קK Token �ɶ��}���ɭP���ҥ���

                        // ñ�W���_������
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:SignKey")))
                    };
                });


            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BS.DemoShopTemplate Admin API",
                    Description = "�y�z..."
                });

                // �K�[ JWT �w���w�q
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                // �t�m�w���ݨD
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }  // �Ŧr�Ŧ��ܤ��n�D���骺�v��
                }
            });
            });

            var origins = new[]
             {
                "http://localhost:5173","https://talkingtopiaadminsystem.azurewebsites.net"
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
