using System;
using System.Collections.Generic;

namespace EHI.Services.DBModel.Contact
{
    public partial class Contact
    {
        public int ContacttId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
    }
}
