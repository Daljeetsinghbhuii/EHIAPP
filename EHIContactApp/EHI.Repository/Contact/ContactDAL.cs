using EHI.Services.DBModel.Contact;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBModel = EHI.Services.DBModel.Contact;

namespace EHI.Services.DAL.Contact
{
    public class ContactDAL
    {
        #region Private Variables        
        private EHIDemoContext eHIDemoContext;
        #endregion

        #region Public Constructors

        /// <summary>
        /// Contact dal constructor
        /// </summary>
        /// <param name="_eHIDemoContext"></param>
        public ContactDAL(EHIDemoContext _eHIDemoContext)
        {
            eHIDemoContext = _eHIDemoContext;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// GetContactList
        /// </summary>
        /// <returns>Returns list of Contact Models</returns>
        public async Task<List<DBModel.Contact.Contact>> GetContactList()
        {
            return await eHIDemoContext.Contact.ToAsyncEnumerable().ToList().ConfigureAwait(false);
        }


        public bool CheckContatExist(int id)
        {
            DBModel.Contact.Contact contact = eHIDemoContext.Contact.Where(r => r.ContacttId == id).FirstOrDefault();

            if (contact == null)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Add Contact
        /// </summary>
        /// <param name="Contact">Contact</param>
        /// <returns>Return value>0 if addition is successful else false</returns>
        public async Task<int> AddContact(DBModel.Contact.Contact contact)
        {
            eHIDemoContext.Contact.Add(contact);
            return await eHIDemoContext.SaveChangesAsync().ConfigureAwait(false);
        }

        ///// <summary>
        ///// Update Contact
        ///// </summary>
        ///// <param name="Contact">Contact</param>
        ///// <returns>Return value>0 if updation is successful else false</returns>
        public async Task<int> UpdateContact(DBModel.Contact.Contact contact)
        {
            eHIDemoContext.Contact.Update(contact);
            return await eHIDemoContext.SaveChangesAsync().ConfigureAwait(false);
        }

        ///// <summary>
        ///// Update Contact
        ///// </summary>
        ///// <param name="Contact">Contact</param>
        ///// <returns>Return value>0 if updation is successful else false</returns>
        public async Task<int> DeleteContact(int ContactId)
        {
            DBModel.Contact.Contact contact = eHIDemoContext.Contact.Where(r => r.ContacttId == ContactId).FirstOrDefault();
            if (contact != null)
            {
                eHIDemoContext.Contact.Remove(contact);
                return await eHIDemoContext.SaveChangesAsync().ConfigureAwait(false);
            }
            return 0;
        }
      

        #endregion
    }
}
