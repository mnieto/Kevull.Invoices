using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Kevull.Invoices.Api {
    public class ErrorMessage {

        public ErrorMessage(string message, params object[] details) {
            Message = message;
            Details = new List<object>(details);
        }
        public ErrorMessage(string errorCode, string message, params object[] details) : this (message, details) {
            if (string.IsNullOrEmpty(errorCode))
                throw new ArgumentNullException(nameof(errorCode));
            ErrorCode = errorCode;
        }

        public ErrorMessage(LogLevel level, string message, params object[] details) : this(message, details) {
            Level = level;
        }
        public ErrorMessage(LogLevel level, string errorCode, string message, params object[] details) : this(message, details) {
            if (string.IsNullOrEmpty(errorCode))
                throw new ArgumentNullException(nameof(errorCode));
            Level = level;
            ErrorCode = errorCode;
        }
        public string ErrorCode { get; set; }
        public LogLevel Level { get; set; } = LogLevel.Error;
        public string Message { get; set; }
        public IEnumerable<object> Details { get; set; }

        public override string ToString() {
            if (string.IsNullOrEmpty(ErrorCode))
                return Message;
            else
                return string.Concat(ErrorCode, " - ", Message);
        }
    }
}
