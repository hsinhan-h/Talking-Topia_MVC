using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Web.Services;

namespace Web.Configurations
{
    public static class ConfigureWebService
    {
        public static IServiceCollection AddWebService(this IServiceCollection services)
        {

            services.AddScoped<ShoppingCartViewModelService>();
            services.AddScoped<AppointmentDetailService>();
            return services;
        }
    }
}
