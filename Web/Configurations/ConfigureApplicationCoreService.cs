using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.ECpay;
using Infrastructure.Interfaces.ECpay;

namespace Web.Configurations
{
    public static class ConfigureApplicationCoreService
    {
        public static IServiceCollection AddApplicationCoreService(this IServiceCollection services)
        {
            services.AddScoped<IPayment, Payment>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICourseService, ApplicationCore.Services.CourseService>();
            services.AddScoped<ICourseService, ApplicationCore.Services.CourseService>();

            return services;
        }
    }
}
