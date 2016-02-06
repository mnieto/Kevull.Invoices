using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kevull.Invoices.Entities {
    public class Contact : Entity {
        public int ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
