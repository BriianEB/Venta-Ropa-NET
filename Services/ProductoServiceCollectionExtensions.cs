using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace VentaRopa.Services
{
    public static class ProductoServiceCollectionExtensions
    {
        public static IServiceCollection AddProductoService(this IServiceCollection services)
        {
            services.AddScoped<ProductoService>();

            return services;
        }
    }
}
