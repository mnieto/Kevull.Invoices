using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kevull.Invoices.Entities {

    public class Entity : IEntity<int> {
        public int Id { get; set; }
        object IEntity.Id {
            get { return this.Id; }
            set { this.Id = (int)value; }
        }

        public bool IsTransient() {
            return Id == 0;
        }
    }

}
