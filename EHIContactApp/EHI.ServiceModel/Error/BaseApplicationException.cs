using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EHI.Services.ServiceModel.Contact.Error
{
    public class BaseApplicationException : Exception
    {
        #region Properties
        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public HttpStatusCode HttpStatusCode { get; }

        #endregion

        #region constructors      

        public BaseApplicationException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode) : base(errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.HttpStatusCode = httpStatusCode;
        }
        #endregion
    }
}
