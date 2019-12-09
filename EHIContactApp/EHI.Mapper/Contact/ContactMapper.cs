using System.Collections.Generic;
using EHI.Services.ServiceModel.Contact;

namespace EHI.Services.Mapper.Contact
{
    /// <summary>
    /// Contact mapper class
    /// </summary>
    public class ContactMapper
    {

        /// <summary>
        /// Mapper For Contact List
        /// </summary>
        /// <param name="contacts">contacts</param>
        /// <returns>Converts DbModel to Custom Model</returns>
        public static List<ContactResponse> MapperForContactList(List<DBModel.Contact.Contact> contacts)
        {
            return contacts.ConvertAll(contactElement => new ContactResponse()
            {
                ContacttId = contactElement.ContacttId,
                FirstName = contactElement.FirstName,
                LastName = contactElement.LastName,
                Email = contactElement.Email,
                Phone = contactElement.Phone,
                Status = contactElement.Status
            });            
        }

        /// <summary>
        /// Mapper For Contact Add
        /// </summary>
        /// <param name="contacts">contacts</param>
        /// <returns>Returns Custom model to DbModel</returns>
        public static Services.DBModel.Contact.Contact MapperForContactAdd(ContactRequest contacts)
        {
            return new Services.DBModel.Contact.Contact()
            {
                ContacttId = contacts.ContacttId,
                FirstName = contacts.FirstName,
                LastName = contacts.LastName,
                Email = contacts.Email,
                Phone = contacts.Phone,
                Status = contacts.Status
            };
        }

        /// <summary>
        /// Mapper For Contact Update
        /// </summary>
        /// <param name="contactsRequest">contactsRequest</param>
        /// <returns>Convert DbModel to Another DBModel</returns>
        public static Services.DBModel.Contact.Contact MapperForContactUpdate(ContactRequest contacts)
        {
            return new Services.DBModel.Contact.Contact()
            {
                ContacttId = contacts.ContacttId,
                FirstName = contacts.FirstName,
                LastName = contacts.LastName,
                Email = contacts.Email,
                Phone = contacts.Phone,
                Status = contacts.Status
            };
        }
    }
}
