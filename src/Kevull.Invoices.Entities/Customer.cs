using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kevull.Invoices.Entities {
    public class Customer : Entity {

        public Customer() {
            Contacts = new HashSet<Contact>();
        }
        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public string FiscalIdentifier { get; set; }

        public bool SendMailing { get; set; }

        public virtual ICollection<Contact> Contacts { get; private set; }

    }
}
