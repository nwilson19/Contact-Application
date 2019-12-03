using System;

namespace Nate.ContactApp
{
    public static class Validator
    {
        public static bool IsValid( this Contact contact )
        {
            var isValidContact = true;

            isValidContact = contact.hasValidID();

            if ( isValidContact )
                isValidContact = contact.hasValidEmail();
            if ( isValidContact )
                isValidContact = contact.hasValidName();
            if (isValidContact)
                isValidContact = contact.hasValidPhone();

            return isValidContact;
        }

        public static bool hasValidEmail( this Contact contact )
        {
            var isValidEmail = true;

            if (!contact.Email.Address.Contains("@") && contact.Email.Address.Length > 0)
                isValidEmail = false;

            return isValidEmail;
        }

        public static bool hasValidID( this Contact contact )
        {
            var isValidID = true;

            if ( contact.ContactID < 0 )
                isValidID = false;

            return isValidID;
        }

        public static bool hasValidName( this Contact contact )
        {
            var isValidName = true;

            if (contact.FirstName.Length == 0 && contact.LastName.Length == 0)
                isValidName = false;

            return isValidName;
        }

        public static bool hasValidPhone( this Contact contact )
        {
            var isValidPhone = false;

            if (contact.Home.Number == null || contact.Home.Number.Length == 0 || contact.Home.Number.Length == 10)   //Assuming US Phone Number of 10 digits or empty field
                isValidPhone = true;
            if (contact.Work.Number == null || contact.Work.Number.Length == 0 || contact.Work.Number.Length == 10)
                isValidPhone = true;
            if (contact.Cell.Number == null || contact.Cell.Number.Length == 0 || contact.Cell.Number.Length == 10)
                isValidPhone = true;

            return isValidPhone;
        }
    }
}
