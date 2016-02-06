using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kevull.Invoices.Entities {
    public class Address {
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

    }
}
