using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TalkingTopiaDb");
            services.AddDbContext<TalkingTopiaContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}
