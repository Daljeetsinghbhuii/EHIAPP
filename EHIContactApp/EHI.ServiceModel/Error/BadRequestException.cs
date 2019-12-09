using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EHI.Services.ServiceModel.Contact.Error
{
    public class BadRequestException : BaseApplicationException
    {
        public BadRequestException(string code, string message, HttpStatusCode statusCode) : base(code, message, statusCode) { }
    }
}
