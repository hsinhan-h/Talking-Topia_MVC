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
            
            //services.AddScoped<IProductViewModelService, ProductViewModelService>(); 參考用
            
            return services;
        }
    }
}
