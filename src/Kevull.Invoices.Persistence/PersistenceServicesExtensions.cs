using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;

namespace Kevull.Invoices.Persistence {
    public static class PersistenceServicesExtensions {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {
            services.AddTransient<Context>();
            services.BuildServiceProvider().GetService<Context>().Database.EnsureCreated();
            services.BuildServiceProvider().GetService<Context>().Database.Migrate();
            return services;
        }

    }
}
