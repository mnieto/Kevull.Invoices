using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kevull.Invoices.Entities;
using Kevull.Invoices.Persistence;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Kevull.Invoices.Services {
    internal static class SampleData {

        public static async Task SeedData(IServiceProvider serviceProvider) {
            await AddOrUpdateAsync<Customer>(serviceProvider, x => x.Id, GetCustomers());
        }


        private static async Task AddOrUpdateAsync<TEntity>(
                                    IServiceProvider serviceProvider,
                                    Func<TEntity, object> propertyToMatch, IEnumerable<TEntity> entities)
                                    where TEntity : class {
            // Query in a separate context so that we can attach existing entities as modified
            List<TEntity> existingData;
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                var db = serviceScope.ServiceProvider.GetService<Context>();
                existingData = db.Set<TEntity>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                var db = serviceScope.ServiceProvider.GetService<Context>();
                foreach (var item in entities) {
                    db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
                        ? EntityState.Modified
                        : EntityState.Added;
                }

                await db.SaveChangesAsync();
            }
        }

        private static IEnumerable<Customer> GetCustomers() {
            return new List<Customer> {
                new Customer {
                    Id = 1,
                    Name = "Luis Navarrete",
                    Street = "Mayor, 42",
                    PostalCode = "31600",
                    City = "Burlada",
                    Region = "Navarra"
                },
                new Customer {
                    Id = 2,
                    Name = "Arancha Molinete",
                    Street = "Av Guipúzcoa, 12 3º I",
                    PostalCode = "31013",
                    City = "Berriozar",
                    Region = "Navarra"
                },
            };
        }

    }
}
