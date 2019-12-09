using EHI.Services.ServiceModel.Contact;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System;
using EHI.Services.DBModel.Contact;
using EHI.Services.Contact.API;
using EHI.Services.BL.Contact;
using EHI.Services.ServiceModel.Contact.Error;

namespace EHI.Services.API.Controllers
{

    /// <summary>
    /// Contact controller methods
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        #region Private Variables  
        private readonly EHIDemoContext eHIDemoContext;
        #endregion

        #region Public Constructor
        /// <summary>
        /// Contact controller constructor
        /// </summary>
        /// <param name="_eHIDemoContext">EHIDemo context</param>
        public ContactController(EHIDemoContext _eHIDemoContext)
        {
            eHIDemoContext = _eHIDemoContext;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Get Contact List
        /// </summary>
        /// <returns>Returns list of Contact</returns>
        // GET: api/Contact/List
        [HttpGet()]
        [ActionName("List")]
        [SwaggerResponse(statusCode: 200, type: typeof(ContactResponse), description: "Get Contact List")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorInfo), description: "Exception occured while fetching the Contact.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorInfo), description: "Validation Exception occured while fetching the Contact.")]
        public async Task<IActionResult> GetContactList()
        {
            ContactBL contactBL = new ContactBL(eHIDemoContext);
            List<ContactResponse> response = await contactBL.GetContactList().ConfigureAwait(false);
            return Ok(response);
        }

        /// <summary>
        /// Add Contact
        /// </summary>
        /// <param name="contactRequest">Contact request object</param>
        /// <returns>Add Contact to database</returns>
        // POST: /api/Contact/Add
        [HttpPost]
        [ActionName("Add")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool), description: "Add Contact")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorInfo), description: "Exception occured while adding the Contact.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorInfo), description: "Validation Exception occured while adding the Contact.")]
        public async Task<ActionResult<bool>> AddContact(ContactRequest contactRequest)
        {
            ContactBL contactBL = new ContactBL(eHIDemoContext);
            bool isContactSavedSuccessful = await contactBL.AddContact(contactRequest).ConfigureAwait(false);
            return Ok(isContactSavedSuccessful);
        }

        /// <summary>
        /// Update Contact
        /// </summary>
        /// <param name="contactRequest">ContactRequest Object</param>
        /// <returns>Returns true if updation is successful else false</returns>
        // PUT: api/Contact/Update
        [HttpPut]
        [ActionName("Update")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool), description: "Update Contact")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorInfo), description: "Exception occured while updating the Contact.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorInfo), description: "Validation Exception occured while updating the Contact.")]
        public async Task<ActionResult<bool>> UpdateContact(ContactRequest contactRequest)
        {
            ContactBL contactBL = new ContactBL(eHIDemoContext);
            bool isContactUpdatedSuccessful = await contactBL.UpdateContact(contactRequest).ConfigureAwait(false);
            return Ok(isContactUpdatedSuccessful);
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="ContactId">ContactId</param>
        /// <returns>Returns true if deletion is successful else false</returns>
        // DELETE: api/Contact/Delete/5
        [HttpDelete("{ContactId}")]
        [ActionName("Delete")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool), description: "Delete Contact")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorInfo), description: "Exception occured while deleting the Contact.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorInfo), description: "Validation Exception occured while deleting the Contact.")]
        public async Task<ActionResult<bool>> DeleteContact(int ContactId)
        {
            ContactBL contactBL = new ContactBL(eHIDemoContext);
            bool isContactDeletedSuccessful = await contactBL.DeleteContact(ContactId).ConfigureAwait(false);
            return Ok(isContactDeletedSuccessful);
        }

        #endregion

    }
}

