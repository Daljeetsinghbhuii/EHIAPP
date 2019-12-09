using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace EHI.Services.ServiceModel.Contact.Error
{
    public class ClientErrors
    {
        private readonly CustomErrorWrapper errorConfig;
        public ClientErrors(CustomErrorWrapper _errorConfig)
        {
            errorConfig = _errorConfig;
        }

        public BadRequestException GetClientErrors(string ErrorKey, List<string> ErrorParameters = null)
        {
            CustomError errorCustom = errorConfig.CustomErrorList.Where(x => x.ErrorKey == ErrorKey).FirstOrDefault();
            if (ErrorParameters != null)
                ErrorParameters.ForEach(x => errorCustom.ErrorMessage = errorCustom.ErrorMessage.Replace("{" + Convert.ToString(ErrorParameters.IndexOf(x)) + "}", x));
            return new BadRequestException(errorCustom.Errorcode, errorCustom.ErrorMessage, HttpStatusCode.BadRequest);
        }
    }
}
