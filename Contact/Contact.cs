using System;

namespace Nate.ContactApp
{
    public class Contact
    {
        public int contactID;
        public string firstName;
        public string lastName;
        public string email;
        private string phoneHome;
        public string HomePhone
        {
            get => phoneHome;
            set => phoneHome = formatPhoneNumber(value);
        }
        private string phoneWork;
        public string WorkPhone
        {
            get => phoneWork;
            set => phoneWork = formatPhoneNumber(value);
        }
        private string phoneCell;
        public string CellPhone
        {
            get => phoneCell;
            set => phoneCell = formatPhoneNumber(value);
        }

        public bool isActiveRecord;

        public Contact()
        {
            contactID = 0;
            firstName = "";
            lastName = "";
            phoneHome = "";
            phoneWork = "";
            phoneCell = "";
            email = "";

            isActiveRecord = true;
        }

        public bool IsEqual(Contact contact, Contact contact2)
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

        private static string formatPhoneNumber(string phone)
        {
            string properNumber = phone;
            properNumber = properNumber.Replace(" ", "");
            properNumber = properNumber.Replace("(", "");
            properNumber = properNumber.Replace(")", "");
            properNumber = properNumber.Replace("-", "");

            return properNumber;
        }

    }
}
