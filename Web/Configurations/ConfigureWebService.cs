namespace Web.Configurations
{
    public static class ConfigureWebService
    {
        public static IServiceCollection AddWebService(this IServiceCollection services)
        {
            services.AddScoped<ShoppingCartViewModelService>();
            services.AddScoped<AppointmentDetailViewModelService>();
            services.AddScoped<OrderDetailViewModelService>();
            services.AddScoped<OrderViewModelService>();
            services.AddScoped<MemberAppointmentService>();
            //services.AddScoped<DifySearchService>();
          
            return services;
        }
    }
}
