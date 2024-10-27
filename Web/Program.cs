using Web.Data;
using Web.Repository;
using Web.Configurations;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Service;
using Web.Hubs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Web.Models.MongoDB;
using Web.Settings;
using Web.Helpers;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Coravel;
using Coravel.Scheduling.Schedule.Interfaces;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }

            // Add DbContext configuration
            builder.Services.AddDbContext<Data.TalkingTopiaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TalkingTopiaDb")));

            //���UIRepository
            builder.Services.AddScoped<IRepository, GeneralRepository>();

            //���ULineAuthService
            builder.Services.AddScoped<ILineAuthService, LineAuthService>();

            //���UEmailService
            builder.Services.AddScoped<IEmailService, EmailService>();

            //���USearchService
            builder.Services.AddScoped<ISearchService, ApplicationCore.Services.SearchService>();


            //���UCoravel Scheduler
            builder.Services.AddScheduler();

            builder.Services.AddHttpContextAccessor();

            //���Uredis distributed cache
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration["ConnectionStrings:Redis"];
                options.InstanceName = "TalkingTopia-Cache";
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // �ҥ� Session �䴩
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // �]�w Session �L���ɶ�
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddHttpClient();

            //builder.Services.AddScoped<IHostedService,BackgroundTaskService>();
            builder.Services.AddScoped<Services.BookingService>();
            builder.Services.AddScoped<CourseService>();
            builder.Services.AddScoped<MemberDataService>();
            builder.Services.AddScoped<ResumeDataService>();
            builder.Services.AddScoped<TutorDataservice>();
            builder.Services.AddScoped<AccountService>();
            builder.Services.AddScoped<NationService>();
            builder.Services.AddScoped<CourseCategoryService>();
            builder.Services.AddScoped<CloudinaryService>();
            builder.Services.AddScoped<RedisCacheHelper>();
            builder.Services.AddScoped<AppointmentNotificationService>();

            // �n�[�U���o�� AddInfrastructureService      
            builder.Services.AddInfrastructureService(builder.Configuration);
            // �NDI���Configurations��Ƨ���������ɮסA�Y����N�i�H��W�診�@��Service�`�J�ӧO�R��
            // ConfigureApplicationCoreService -> for �DWeb�M�פ���DI
            // ConfigureWebService -> for Web�M�פ���DI
            builder.Services.AddApplicationCoreService().AddWebService();
            // �j�ꪺ�A�ŧR(�u�b�}�o���ҥ[�JUser Secrets)
            //if (builder.Environment.IsDevelopment())
            //{
            //    builder.Configuration.AddUserSecrets<Program>();
            //}

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7263")
                               .AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .WithExposedHeaders("*");

                        //builder.WithOrigins("http://example.com","http://www.contoso.com")
                        //       .WithMethods("GET", "POST", "PUT", "DELETE");
                    });
            });

            // Add SignalR
            builder.Services.AddSignalR();

            // Add MongoDB settings
            builder.Services
            .Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<MongoDbSettings>();
                return new MongoClient(settings.ConnectionString);
            });
            builder.Services.AddScoped<MongoRepository>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                // �n�J�θ��|
                                options.LoginPath = "/Account/Login";
                                // �n�X�θ��|
                                options.LogoutPath = "/Account/Logout";
                                // �S���v���ɪ��ɦV(HTTP Status Code: 403)
                                options.AccessDeniedPath = "/Account/AccessDenied";
                                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);  // �w�]�L���ɶ�
                            });

            builder.Services.AddAuthorization();
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // �ҥ� Session
            app.UseSession();

            app.UseCors();

            // �����ҦA���v.
            app.UseAuthentication();
            app.UseAuthorization();

            //�]�mCoravel�Ƶ{
            var scheduler = app.Services.GetRequiredService<IScheduler>();
            scheduler.Schedule(async () =>
            {
                using var scope = app.Services.CreateScope();
                var notificationService = scope.ServiceProvider.GetRequiredService<AppointmentNotificationService>();
                await notificationService.SendNotificationsAsync();
            }).EveryMinute();

            app.MapControllerRoute(
            name: "Login",
            pattern: "Login",
            defaults: new { controller = "Account", action = "Account" });

            app.MapControllerRoute(
            name: "MemberData",
            pattern: "MemberData",
            defaults: new { controller = "Member", action = "MemberData" });

            app.MapControllerRoute(
            name: "MemberTransaction",
            pattern: "MemberOrderDetails",
            defaults: new { controller = "Member", action = "MemberTransaction" });

            app.MapControllerRoute(
            name: "TutorData",
            pattern: "TutorData",
            defaults: new { controller = "Tutor", action = "TutorData" });

            app.MapControllerRoute(
            name: "PublishCourse",
            pattern: "PublishCourse",
            defaults: new { controller = "Tutor", action = "PublishCourse" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }


    }
}
