using Infrastructure.ECpay;
using Infrastructure.Interfaces.ECpay;

namespace Web.Configurations
{
    public static class ConfigureApplicationCoreService
    {
        public static IServiceCollection AddApplicationCoreService(this IServiceCollection services)
        {
            //services.AddScoped<IOrderService, OrderService>(); 參考格式
            services.AddScoped<IPayment, Payment>();

            return services;
        }
    }
}
