using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NateCRM.Classes
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

        private static string StripPhoneFormatting(string number)
        {
            string properNumber = number;

            if (properNumber != null)
                properNumber = String.Join("", number.Where(c => Char.IsDigit(c)));

            return properNumber;
        }

        public bool Validate(PhoneNumber Phone)
        {
            var isValidPhone = false;

            if (Phone.Number == null || Phone.Number.Length == 0 || Phone.Number.Length == 10)   //Assuming US Phone Number of 10 digits or empty field
                isValidPhone = true;

            return isValidPhone;
        }
    }
}
