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
