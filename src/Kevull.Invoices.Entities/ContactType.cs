using System.Collections.Generic;

namespace Kevull.Invoices.Entities {
    public class ContactType : Entity {

        public ContactType() {
            Contacts = new HashSet<Contact>();
        }
        public string Name { get; set; }

        public virtual ICollection<Contact> Contacts { get; private set; }
    }
}