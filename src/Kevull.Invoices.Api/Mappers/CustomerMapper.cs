using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kevull.Invoices.Entities;
using Kevull.Invoices.Api.Models;

namespace Kevull.Invoices.Api.Mappers {
    public static class CustomerMapper {
        public static IEnumerable<CustomerModel> ToModel(IEnumerable<Customer> source) {
            foreach (Customer item in source) {
                yield return ToModel(item);
            }
        }

        public static CustomerModel ToModel(Customer source) {
            return new CustomerModel {
                Id = source.Id,
                Name = source.Name,
                Street = source.Street,
                City = source.City,
                PostalCode = source.PostalCode,
                Region = source.Region,
                FiscalIdentifier = source.FiscalIdentifier,
                SendMailing = source.SendMailing
            };
        }

        public static Customer ToEntity(CustomerModel source) {
            return new Customer {
                Id = source.Id,
                Name = source.Name.Trim(),
                Street = source.Street.Trim(),
                City = source.City.Trim(),
                PostalCode = source.PostalCode.Trim(),
                Region = source.Region.Trim(),
                FiscalIdentifier = source.FiscalIdentifier.Trim(),
                SendMailing = source.SendMailing
            };
        }
    }
}
