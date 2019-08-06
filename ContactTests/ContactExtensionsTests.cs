using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Nate.ContactApp.Tests
{
    public class ContactExtensionsTests
    {
        [Fact]
        public void ContactIsEqual_Properly_Compares_Two_Contacts()
        {
            Contact contact1 = new Contact();
            contact1.contactID = 12;
            contact1.email = "different@gmail.com";
            contact1.firstName = "New";
            contact1.lastName = "Contact";
            contact1.CellPhone = "(888) 867-5309";
            contact1.HomePhone = "(888) 867-5309";
            contact1.WorkPhone = "(888) 867-5309";
            Contact contact2 = new Contact();
            contact2.contactID = 12;
            contact2.email = "different@gmail.com";
            contact2.firstName = "New";
            contact2.lastName = "Contact";
            contact2.CellPhone = "(888) 867-5309";
            contact2.HomePhone = "(888) 867-5309";
            contact2.WorkPhone = "(888) 867-5309";

            Assert.True(contact1.IsEqual(contact2));

        }
    }
}
