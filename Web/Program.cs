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

            //註冊IRepository
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




            // 要加下面這個 AddInfrastructureService      
            builder.Services.AddInfrastructureService(builder.Configuration);
            // 將DI改至Configurations資料夾內的兩支檔案，若有改就可以把上方那一排Service注入個別刪除
            // ConfigureApplicationCoreService -> for 非Web專案內的DI
            // ConfigureWebService -> for Web專案內的DI
            builder.Services.AddApplicationCoreService().AddWebService();
            // 大國的，勿刪(只在開發環境加入User Secrets)
            //if (builder.Environment.IsDevelopment())
            //{
            //    builder.Configuration.AddUserSecrets<Program>();
            //}


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                // 登入用路徑
                                options.LoginPath = "/Account/Login";
                                // 沒有權限時的導向(HTTP Status Code: 403)
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

            // 先驗證再授權.
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
