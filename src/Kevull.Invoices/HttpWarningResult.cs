using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;

namespace Kevull.Invoices {
    public class HttpWarningResult : ObjectResult {

        public ErrorMessage Message => (ErrorMessage)Value;

        public HttpWarningResult(ErrorMessage message) : base(message) {
            StatusCode = StatusCodes.Status200OK;
        }

        public override void ExecuteResult(ActionContext context) {
            string encoded = EncodeQuotedPrintable(Message.ToString());
            context.HttpContext.Response.Headers.Add("X-Warning", encoded);
            base.ExecuteResult(context);
        }

        public override Task ExecuteResultAsync(ActionContext context) {
            string encoded = EncodeQuotedPrintable(Message.ToString());
            context.HttpContext.Response.Headers.Add("X-Warning", encoded);
            return base.ExecuteResultAsync(context);
        }

        //http://stackoverflow.com/questions/11793734/code-for-encode-decode-quotedprintable
        public static string EncodeQuotedPrintable(string value) {
            if (string.IsNullOrEmpty(value))
                return value;

            StringBuilder builder = new StringBuilder();
            builder.Append("=?UTF-8?Q?");

            byte[] bytes = Encoding.UTF8.GetBytes(value);
            foreach (byte v in bytes) {
                // The following are not required to be encoded:
                // - Tab (ASCII 9)
                // - Space (ASCII 32)
                // - Characters 33 to 126, except for the equal sign (61).

                if ((v == 9) || ((v >= 32) && (v <= 60)) || ((v >= 62) && (v <= 126))) {
                    builder.Append(Convert.ToChar(v));
                } else {
                    builder.Append('=');
                    builder.Append(v.ToString("X2"));
                }
            }

            char lastChar = builder[builder.Length - 1];
            if (char.IsWhiteSpace(lastChar)) {
                builder.Remove(builder.Length - 1, 1);
                builder.Append('=');
                builder.Append(((int)lastChar).ToString("X2"));
            }

            builder.Append("?=");
            return builder.ToString();
        }
    }
}
