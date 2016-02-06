using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kevull.Invoices.Entities;
using Kevull.Invoices.Persistence;
using Microsoft.Data.Entity;

namespace Kevull.Invoices.Services {
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class CustomersService {

        public Context Context { get; set; }
        public CustomersService(Context context) {
            Context = context;
        }

        public async Task<List<Customer>> GetAll() {
            return await Context.Customers.ToListAsync();
        }

        public async Task<Customer> Get(int id) {
            return await Context.Customers
                .Include(x => x.Contacts)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Customer>> SearchByName(string name) {
            return await Context.Customers.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<int> Save(Customer customer) {
            if (string.IsNullOrEmpty(customer.Street))
                throw new InvalidOperationException("Street is required");
            if (customer.IsTransient()) {
                Context.Customers.Add(customer);
            } else {
                Context.Customers.Attach(customer).State = Microsoft.Data.Entity.EntityState.Modified;
            }
            await Context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task Delete(int id) {
            var customer = new Customer {
                Id = id
            };
            Context.Customers.Attach(customer).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }
    }
}
