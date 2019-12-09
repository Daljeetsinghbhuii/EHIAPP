using System;
using System.Net;

namespace EHI.Services.ServiceModel.Contact.Error
{
    public sealed class ErrorInfo
    {
        private ErrorInfo()
        {

        }

        public string Code { get; }

        public string Message { get; }

        public HttpStatusCode HttpStatusCode { get; }

        public ErrorInfo(string errorCode, string errorMessage, HttpStatusCode httpStatusCode)
        {
            if (string.IsNullOrWhiteSpace(errorCode))
                throw new ArgumentNullException(nameof(errorCode));

            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            Code = errorCode;
            Message = errorMessage;
            HttpStatusCode = httpStatusCode;
        }

        public static ErrorInfo FromBaseApplicationException(BaseApplicationException ex)
        {
            var errorInfo = new ErrorInfo(ex.ErrorCode, ex.ErrorMessage, ex.HttpStatusCode);
            return errorInfo;
        }        
    }
}
