using System.Net;

namespace EHI.Services.ServiceModel.Contact.Error
{
    public class RecordNotFoundException : BaseApplicationException
    {
        public RecordNotFoundException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode) : base(errorCode, errorMessage, httpStatusCode) { }
    }
}
