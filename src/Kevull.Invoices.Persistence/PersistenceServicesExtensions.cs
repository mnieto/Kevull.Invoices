using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Kevull.Invoices.Persistence {
    public static class PersistenceServicesExtensions {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {
            services.AddTransient<Context>();
            services.BuildServiceProvider().GetService<Context>().Database.EnsureCreatedAsync();
            return services;
        }

    }
}
