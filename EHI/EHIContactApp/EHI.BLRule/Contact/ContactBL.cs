using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EHI.Services.DBModel.Contact;
using EHI.Services.ServiceModel.Contact;
using EHI.Services.DAL.Contact;
using EHI.Services.Mapper.Contact;

namespace EHI.Services.BL.Contact
{
    public class ContactBL
    {
        #region Private Variables        
        private EHIDemoContext eHIDemoContext;
        #endregion

        #region Public Constructor
        /// <summary>
        /// Constructor for Contact BL
        /// </summary>
        /// <param name="_eHIDemoContext">Food Rebel Context</param>        
        public ContactBL(EHIDemoContext _eHIDemoContext)
        {
            eHIDemoContext = _eHIDemoContext;
        }
        #endregion

        #region Public Methods


        /// <summary>
        /// Get Contact List
        /// </summary>
        /// <returns>Returns list of Contact</returns>
        public async Task<List<ContactResponse>> GetContactList()
        {
            ContactDAL contactDAL = new ContactDAL(eHIDemoContext);
            Task<List<DBModel.Contact.Contact>> getContactList = Task.Run(() => contactDAL.GetContactList());

            List<DBModel.Contact.Contact> contactList = await getContactList.ConfigureAwait(false);
            List<ContactResponse> contactResponse = new List<ContactResponse>();
            if (contactList.Count > 0)
            {
                contactResponse = ContactMapper.MapperForContactList(contactList);
            }
            return contactResponse;
        }


        /// <summary>
        /// Add Contact
        /// </summary>
        /// <param name="contactRequest">contactRequest</param>
        /// <returns>Returns true if addition is successful else false</returns>
        public async Task<bool> AddContact(ContactRequest contactRequest)
        {
            ContactValidator contactValidator = new ContactValidator(eHIDemoContext);
            contactValidator.ValidateContactRequest(contactRequest);

            ContactDAL contactDAL = new ContactDAL(eHIDemoContext);
            DBModel.Contact.Contact contact = ContactMapper.MapperForContactAdd(contactRequest);
            int savedRecordCount = await contactDAL.AddContact(contact).ConfigureAwait(false);
            if (savedRecordCount > 0)
                return true;
            return false;
        }



        /// <summary>
        /// Update Contact
        /// </summary>
        /// <param name="contactRequest">contactRequest</param>
        /// <returns>Returns true if updation is successful else false</returns>
        public async Task<bool> UpdateContact(ContactRequest contactRequest)
        {
            ContactValidator contactValidator = new ContactValidator(eHIDemoContext);
            contactValidator.ValidateContactRequest(contactRequest);
            ContactDAL contactDAL = new ContactDAL(eHIDemoContext);

            DBModel.Contact.Contact contact = ContactMapper.MapperForContactUpdate(contactRequest);
            int savedRecordCount = await contactDAL.UpdateContact(contact).ConfigureAwait(false);
            if (savedRecordCount > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="ContactId">ContactId</param>
        /// <returns>Returns true if deletion is successful else false</returns>
        // DELETE: api/Contact/Delete/5
        public async Task<bool> DeleteContact(int ContactId)
        {
            ContactValidator contactValidator = new ContactValidator(eHIDemoContext);
            contactValidator.ValidateDeleteContactRequest(ContactId);

            ContactDAL contactDAL = new ContactDAL(eHIDemoContext);
            int deletedRecordCount = await contactDAL.DeleteContact(ContactId).ConfigureAwait(false); ;
            if (deletedRecordCount > 0)
                return true;
            return false;
        }

        #endregion
    }
}
