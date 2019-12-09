using EHI.Services.DAL.Contact;
using EHI.Services.DBModel.Contact;
using EHI.Services.ServiceModel.Contact;
using EHI.Services.ServiceModel.Contact.Error;

namespace EHI.Services.BL.Contact
{
    //Commented by Daljeet
    //Added Custom validator class to valide Contact Request
    public class ContactValidator
    {
        #region Private Variables        
        private EHIDemoContext ehiDemoContext;
        private ClientErrors clientErrors;
        #endregion

        #region Public Constructor
        /// <summary>
        /// Constructor for Contact validator
        /// </summary>
        /// <param name="_ehiDemoContext"></param>
        /// <param name="_errorConfig"></param>
        public ContactValidator(EHIDemoContext _ehiDemoContext)
        {
            ehiDemoContext = _ehiDemoContext;            
        }
        #endregion

        /// <summary>
        /// Validate Contact Request
        /// </summary>
        /// <param name="contactRequest">contactRequest</param>
        public void ValidateContactRequest(ContactRequest contactRequest)
        {
            if (contactRequest == null)
            {
                throw clientErrors.GetClientErrors(ErrorcodeEnum.InvalidRequest.ToString());
            }

            if (string.IsNullOrEmpty(contactRequest.FirstName))
            {
                throw clientErrors.GetClientErrors(ErrorcodeEnum.InvalidFirstName.ToString());                
            }

            if (string.IsNullOrEmpty(contactRequest.Email))
            {                
                throw clientErrors.GetClientErrors(ErrorcodeEnum.InvalidEmail.ToString());
            }
        }


        /// <summary>
        /// Validate delete Contact request
        /// </summary>
        /// <param name="id">ID</param>
        public void ValidateDeleteContactRequest(int id)
        {
            ContactDAL contactDAL = new ContactDAL(ehiDemoContext);
            if (!contactDAL.CheckContatExist(id))
            {
                throw clientErrors.GetClientErrors(ErrorcodeEnum.RecordsNotFound.ToString());
            }
        }

    }
}

