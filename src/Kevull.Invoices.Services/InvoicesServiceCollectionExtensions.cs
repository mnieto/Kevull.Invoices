using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Kevull.Invoices.Persistence;

namespace Kevull.Invoices.Services {
    public static class InvoicesServiceCollectionExtensions {
        public static IServiceCollection AddInovicesBusinessServices(this IServiceCollection services) {
            services.AddPersistenceServices();
            services.AddTransient<CustomersService>();
            return services;
        }
    }
}
