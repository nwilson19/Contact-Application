using System;
using System.Collections.Generic;
using System.Linq;

namespace Nate.ContactApp
{
    public static class Extensions
    {
        /*
        public static string StripPhoneFormatting(this string phone)
        {
            string properNumber = phone;

            if (properNumber != null)
                properNumber = String.Join("", phone.Where(c => Char.IsDigit(c)));

            return properNumber;
        }
        */

        public static bool IsEqualTo(this Contact contact, Contact contact2)
        {
             return (contact.IsActiveRecord == contact2.IsActiveRecord && contact.ContactID == contact2.ContactID &&
                     contact.Email.Address == contact2.Email.Address && contact.FirstName == contact2.FirstName &&
                     contact.LastName == contact2.LastName && contact.Cell.Number == contact2.Cell.Number &&
                     contact.Home.Number == contact2.Home.Number && contact.Work.Number == contact2.Work.Number);
        }

    }
}
