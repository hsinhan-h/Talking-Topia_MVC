using Web.Data;
using Web.Repository;
using Web.Configurations;
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
            builder.Services.AddScoped<OrderDetailService>();
            

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
