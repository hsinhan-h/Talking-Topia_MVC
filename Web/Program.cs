using Web.Data;
using Web.Repository;
using Web.Configurations;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            builder.Services.AddDbContext<Data.TalkingTopiaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TalkingTopiaDb")));

            //���UIRepository
            builder.Services.AddScoped<IRepository, GeneralRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //builder.Services.AddScoped<IHostedService,BackgroundTaskService>();
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<CourseService>();
            builder.Services.AddScoped<MemberDataService>();
            builder.Services.AddScoped<ResumeDataService>();
            builder.Services.AddScoped<TutorDataservice>();
            builder.Services.AddScoped<AccountService>();




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
                                // �S���v���ɪ��ɦV(HTTP Status Code: 403)
                                options.AccessDeniedPath = "/Account/AccessDenied";
                            });

            builder.Services.AddAuthorization();

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
