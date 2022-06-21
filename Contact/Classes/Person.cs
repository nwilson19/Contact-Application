using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NateCRM.Classes
{
    public class Person
    {
        public int RecordID;
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public EmailAddress Email;
        public PhoneNumber Home;
        public PhoneNumber Work;
        public PhoneNumber Cell;

        public Person()
        {
            RecordID = 0;
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Email = new EmailAddress();
            Home = new PhoneNumber();
            Work = new PhoneNumber();
            Cell = new PhoneNumber();
        }

        public Person(int ID)
        {
            RecordID = ID;
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Email = new EmailAddress();
            Home = new PhoneNumber();
            Work = new PhoneNumber();
            Cell = new PhoneNumber();
        }
    }
}
