using System.Collections.Generic;
using System.Threading.Tasks;
using Kevull.Invoices.Entities;
using Kevull.Invoices.Persistence;

namespace Kevull.Invoices.Services {
    public interface ICustomersService {
        Task Delete(int id);
        Task<Customer> Get(int id);
        Task<List<Customer>> GetAll();
        Task<int> Save(Customer customer);
        Task<List<Customer>> SearchByName(string name);
    }
}