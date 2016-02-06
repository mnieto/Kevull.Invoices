using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace Kevull.Invoices {
    public class HttpErrorResult : ObjectResult {

        public object Error => Value;
        public ErrorMessage Message {
            get {
                return Value is ErrorMessage ? (ErrorMessage)Value : (ErrorMessage)null;
            }
        }
        public HttpErrorResult(object error) : base(error) {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
        public HttpErrorResult(ErrorMessage error) : base(error) {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        public HttpErrorResult(ModelStateDictionary modelState) : base(new SerializableError(modelState)) {
            if (modelState == null) {
                throw new ArgumentNullException(nameof(modelState));
            }
            StatusCode = StatusCodes.Status500InternalServerError;
        }

    }
}
