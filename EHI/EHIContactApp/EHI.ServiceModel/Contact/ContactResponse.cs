
using System;

namespace EHI.Services.ServiceModel.Contact
{
    public class ContactResponse
    {
        public int ContacttId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
    }
}

