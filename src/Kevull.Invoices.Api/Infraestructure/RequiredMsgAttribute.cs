using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kevull.Invoices.Api.Infraestructure {
    public class RequiredMsgAttribute : RequiredAttribute {
        public RequiredMsgAttribute() {
            ErrorMessageResourceName = "RequiredMessage";
            ErrorMessageResourceType = typeof(DataAnnotationsResources);
        }
    }
}
