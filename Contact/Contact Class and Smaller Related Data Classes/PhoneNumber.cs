using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nate.ContactApp
{
    public class PhoneNumber
    {
        private string phoneNumber;
        public string Number
        {
            get => phoneNumber;
            set => phoneNumber = StripPhoneFormatting(value);
        }

        public PhoneNumber()
        {
            phoneNumber = null;
        }

        private string StripPhoneFormatting(string number)
        {
            string properNumber = number;

            if (properNumber != null)
                properNumber = String.Join("", number.Where(c => Char.IsDigit(c)));

            return properNumber;
        }
    }
}
