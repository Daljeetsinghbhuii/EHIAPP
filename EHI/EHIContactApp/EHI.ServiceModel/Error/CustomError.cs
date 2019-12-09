using System;
using System.Collections.Generic;

namespace EHI.Services.ServiceModel.Contact.Error
{
    /// <summary>
    /// Food Rebel Error 
    /// </summary>
    public class CustomError
    {
        /// <summary>
        /// Gets or Sets Errorcode
        /// </summary>
        public string Errorcode { get; set; }

        /// <summary>
        /// localized description of the error
        /// </summary>
        /// <value>localized description of the error</value>
        public string ErrorMessage { get; set; }

        public string ErrorKey { get; set; }

        /// <summary>
        /// Exception generated in case of generic_error only
        /// </summary>
        /// <value>Exception generated in case of generic_error only</value>
        public Object Exception { get; set; }
    }

    /// <summary>
    /// Custome Error class wrapper
    /// </summary>
    public class CustomErrorWrapper
    {
        /// <summary>
        /// Custom error list
        /// </summary>
        public List<CustomError> CustomErrorList { get; set; }
    }

   
}
