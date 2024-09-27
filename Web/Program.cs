using Web.Data;
using Web.Repository;
using Web.Configurations;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Service;

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

            builder.Services.AddHttpContextAccessor();



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // �ҥ� Session �䴩
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // �]�w Session �L���ɶ�
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

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

            // �����ҦA���v.
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }


    }
}
