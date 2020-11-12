using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace VentaRopa.Services
{
    public static class VentaServiceCollectionExtensions
    {
        public static IServiceCollection AddVentaService(this IServiceCollection services)
        {
            services.AddScoped<VentaService>();

            return services;
        }
    }
}
