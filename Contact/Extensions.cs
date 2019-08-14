using System;
using System.Linq;

namespace Nate.ContactApp
{
    public static class Extensions
    {
        public static string StripPhoneFormatting(this string phone)
        {
            string properNumber = phone;

            if (properNumber != null)
                properNumber = String.Join("", phone.Where(c => Char.IsDigit(c)));

            return properNumber;
        }

        public static bool Equals(this Contact contact, Contact contact2)
        {
            bool isEqual = true;
            isEqual = contact.isActiveRecord == contact2.isActiveRecord;
            if (isEqual)
                isEqual = contact.contactID == contact2.contactID;
            if (isEqual)
                isEqual = contact.email == contact2.email;
            if (isEqual)
                isEqual = contact.firstName == contact2.firstName;
            if (isEqual)
                isEqual = contact.lastName == contact2.lastName;
            if (isEqual)
                isEqual = contact.CellPhone == contact2.CellPhone;
            if (isEqual)
                isEqual = contact.HomePhone == contact2.HomePhone;
            if (isEqual)
                isEqual = contact.WorkPhone == contact2.WorkPhone;
            return isEqual;
        }

    }
}
