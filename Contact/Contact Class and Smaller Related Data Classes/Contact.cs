using System;
using System.Collections.Generic;
using System.Text;

namespace Nate.ContactApp
{
    public class Contact
    {
        // Ideally need a 2-wide list of attributes with only a couple default attributes (ie first/last name)
        public int ContactID;
        public bool IsActiveRecord;
        public string FirstName;
        public string LastName;
        public PhoneNumber Home;
        public PhoneNumber Work;
        public PhoneNumber Cell;
        public EmailAddress Email;
        public PhysicalAddress Address;
        public string Notes;

        public Contact()
        {
            ContactID = 0;
            IsActiveRecord = true;
            FirstName = "";
            LastName = "";
            Home = new PhoneNumber();
            Work = new PhoneNumber();
            Cell = new PhoneNumber();
            Email = new EmailAddress();
            Address = new PhysicalAddress();
            Notes = "";
        }

        public Contact(int newID)
        {
            ContactID = newID;
            IsActiveRecord = true;
            FirstName = "";
            LastName = "";
            Home = new PhoneNumber();
            Work = new PhoneNumber();
            Cell = new PhoneNumber();
            Email = new EmailAddress();
            Address = new PhysicalAddress();
            Notes = "";
        }
    }
}
