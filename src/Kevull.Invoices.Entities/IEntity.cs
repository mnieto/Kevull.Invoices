//using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kevull.Invoices.Entities {
    public interface IEntity {
        object Id { get; set; }
        bool IsTransient();
    }

    public interface IEntity<T> : IEntity {
        T Id { get; set; }
    }

}
