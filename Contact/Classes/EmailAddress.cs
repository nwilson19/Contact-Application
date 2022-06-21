using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NateCRM.Classes
{
    public class EmailAddress
    {
        public string Address { get; set; }

        public EmailAddress()
        {
            Address = null;
        }

        public bool Validate(EmailAddress EmailAddress)
        {
            var isValidEmail = true;

            if (EmailAddress.Address != null && !EmailAddress.Address.Contains("@") && EmailAddress.Address.Length > 0)
                isValidEmail = false;

            return isValidEmail;
        }
    }
}
