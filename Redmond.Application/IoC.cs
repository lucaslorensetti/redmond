using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Application
{
    public static class IoC
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDispatcher, Dispatcher>();
        }
    }
}
