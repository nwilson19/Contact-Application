using System;
using System.Collections.Generic;
using System.Text;

namespace Nate.ContactApp
{
    public static class ContactExtensions
    {
        public static bool IsEqual(this Contact contact, Contact contact2)
        {
            bool isEqual = true;
            isEqual = contact.isActiveRecord == contact2.isActiveRecord;
            if(isEqual)
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
