using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redmond.Infrastructure.Contexts;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Infrastructure
{
    public static class IoC
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDbContext, RedmondContext>(cfg =>
            {
                var connectionString = configuration.GetConnectionString("RedmondDb");
                cfg.UseSqlServer(connectionString);
            });
        }
    }
}
