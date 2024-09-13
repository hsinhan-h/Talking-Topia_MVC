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
            services.AddScoped<IOrderService, ApplicationCore.Services.OrderService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();

            return services;
        }
    }
}
