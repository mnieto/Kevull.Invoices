using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace Kevull.Invoices.Persistence {
    public static class PersistenceServicesExtensions {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {
            var config = services.BuildServiceProvider().GetRequiredService<IConfigurationRoot>();
            string connectionString = config["Data:ConnectionString"];
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<Context>(options => options.UseSqlite(connectionString));

            var database = services.BuildServiceProvider().GetService<Context>().Database;
            if (!database.EnsureCreated())
                database.Migrate();

            return services;
        }

    }
}
