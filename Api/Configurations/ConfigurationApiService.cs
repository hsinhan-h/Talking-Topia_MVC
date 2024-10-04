using Api.Services;

namespace Api.Configurations
{
    public static class ConfigurationApiService
    {
        public static IServiceCollection AddApiService(this IServiceCollection services)
        {
            services.AddScoped<OrderApiService>();
            services.AddScoped<CourseManagementApiService>();

            return services;
        }
    }
}
