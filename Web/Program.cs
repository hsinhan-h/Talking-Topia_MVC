using Web.Data;
using Web.Repository;
using Infrastructure;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add DbContext configuration
            builder.Services.AddDbContext<TalkingTopiaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //註冊IRepository
            builder.Services.AddScoped<IRepository, GeneralRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<IHostedService,BackgroundTaskService>();
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<CourseService>();
            builder.Services.AddScoped<MemberDataService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<ResumeDataService>();
            builder.Services.AddScoped<TutorDataservice>();
            builder.Services.AddScoped<ShoppingCartService>();


            // 要加下面這個 AddInfrastructureService      
            builder.Services.AddInfrastructureService(builder.Configuration);

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
