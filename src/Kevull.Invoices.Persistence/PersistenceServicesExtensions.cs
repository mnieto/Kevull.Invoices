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
            //https://github.com/aspnet/EntityFramework/issues/3160
            //EnsureCreated is designed for testing or rapid prototyping where you are ok with dropping and re-creating the database each time.
            //If you are using migrations and want to have them automatically applied on app start, then you can use context.Database.Migrate() instead
            //database.EnsureCreated();     
            database.Migrate();

            return services;
        }

    }
}
