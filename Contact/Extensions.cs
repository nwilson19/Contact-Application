using System;
using System.Collections.Generic;
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

        public static bool IsEqualTo(this Contact contact, Contact contact2)
        {
             return (contact.isActiveRecord == contact2.isActiveRecord && contact.contactID == contact2.contactID &&
                     contact.email == contact2.email && contact.firstName == contact2.firstName &&
                     contact.lastName == contact2.lastName && contact.CellPhone == contact2.CellPhone &&
                     contact.HomePhone == contact2.HomePhone && contact.WorkPhone == contact2.WorkPhone);
        }

    }
}
