using ApplicationCore.Interfaces;
using Infrastructure.ECpay;
using Infrastructure.Interfaces.ECpay;

namespace Web.Configurations
{
    public static class ConfigureApplicationCoreService
    {
        public static IServiceCollection AddApplicationCoreService(this IServiceCollection services)
        {
            services.AddScoped<IPayment, Payment>();
            //services.AddScoped<IOrderService, OrderService>(); 大國的，別動Q_Q
            services.AddScoped<OrderService>();

            return services;
        }
    }
}
