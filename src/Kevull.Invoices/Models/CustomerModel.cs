using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Kevull.Invoices.Infraestructure;

namespace Kevull.Invoices.Models {
    public class CustomerModel {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre", Description = "Nombre completo del cliente")]
        [StringLengthMsg(100)]
        [RequiredMsg]
        public string Name { get; set; }

        [Display(Name = "Calle", Description = "Calle, portal, piso")]
        [StringLengthMsg(100)]
        [RequiredMsg]
        public string Street { get; set; }

        [Display(Name = "Ciudad", Description = "Ciudad")]
        [StringLengthMsg(80)]
        [RequiredMsg]
        public string City { get; set; }

        [Display(Name = "Código postal", Description = "Código postal", ShortName = "CP")]
        [StringLengthMsg(10)]
        public string PostalCode { get; set; }

        [Display(Name = "Ciudad", Description = "Ciudad")]
        [StringLengthMsg(80)]
        public string Region { get; set; }

        [Display(Name = "CIF/NIF", Description = "CIF, NIF o tarjeta de residente")]
        [StringLengthMsg(10)]
        public string FiscalIdentifier { get; set; }

        [Display(Name = "Correspondencia", Description = "Enviar correspondencia")]
        public bool SendMailing { get; set; }
    }
}
