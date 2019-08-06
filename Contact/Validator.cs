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

            if (!contact.email.Contains("@") && contact.email.Length > 0)
                isValidEmail = false;

            return isValidEmail;
        }

        public static bool hasValidID( this Contact contact )
        {
            var isValidID = true;

            if ( contact.contactID < 0 )
                isValidID = false;

            return isValidID;
        }

        public static bool hasValidName( this Contact contact )
        {
            var isValidName = true;

            if (contact.firstName.Length == 0 && contact.lastName.Length == 0)
                isValidName = false;

            return isValidName;
        }

        public static bool hasValidPhone( this Contact contact )
        {
            var isValidPhone = false;

            if (contact.HomePhone.Length == 0 || contact.HomePhone.Length == 10)   //Assuming US Phone Number of 10 digits or empty field
                isValidPhone = true;
            if (contact.WorkPhone.Length == 0 || contact.WorkPhone.Length == 10)
                isValidPhone = true;
            if (contact.CellPhone.Length == 0 || contact.CellPhone.Length == 10)
                isValidPhone = true;

            return isValidPhone;
        }
    }
}
