using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Nate.ContactApp.Tests
{
    public class ContactsTests
    {
        [Fact]
        public void Contacts_Constructor_returns_empty_List()
        {
            Contacts test = new Contacts();
            List<Contact> testValue = new List<Contact>();

            Assert.Equal(test.ContactList, testValue);
        }
    }
}
