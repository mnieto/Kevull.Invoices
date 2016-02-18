using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kevull.Invoices.Api.Infraestructure {
    public class StringLengthMsgAttribute : StringLengthAttribute {
        public StringLengthMsgAttribute(int maximumLength) : base(maximumLength) {
            ErrorMessageResourceType = typeof(DataAnnotationsResources);
            ErrorMessageResourceName = "StringLengthMessage";
        }
    }
}
