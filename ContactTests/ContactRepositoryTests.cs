using System.Collections.Generic;
using Xunit;

namespace Nate.ContactApp.Tests
{
    public class ContactRepositoryTests
    {
        [Fact]
        public void Contacts_Constructor_returns_empty_List()
        {
            ContactRepository test = new ContactRepository();
            List<Contact> testValue = new List<Contact>();
            var testList = test.Get();

            Assert.Equal(testList, testValue);
        }

        [Fact]
        public void Get_using_ID_Returns_Valid_Contact()
        {
            var testContainer = GenerateSmallList();

            //Act
            var testContact = testContainer.Get(12);

            //Assert
            Assert.Equal(12, testContact.ContactID);
        }

        [Fact]
        public void Get_using_Invalid_ID_Returns_null()
        {
            var testContainer = GenerateSmallList();

            //Act
            var testContact = testContainer.Get(88);

            //Assert
            Assert.Null(testContact);
        }

        [Fact]
        public void Get_returns_expected_list()
        {
            var contactData = GenerateSmallList();
            var newList = contactData.Get();

            foreach (Contact contact in newList)
            {
                var testContact = contactData.Get(contact.ContactID);
                Assert.True(contact.IsEqualTo(testContact));
            }
        }

        [Fact]
        public void Post_adds_new_record_successfully()
        {
            //Arrange
            ContactRepository testContainer = GenerateSmallList();

            //Act
            var testContact = testContainer.Get(1);

            //Assert
            Assert.Equal(1, testContact.ContactID);
        }

        [Fact]
        public void Delete_flags_correct_contact_as_inactive()
        {
            ContactRepository testContainer = GenerateSmallList();

            testContainer.Delete(12);
            var contact = testContainer.Get(12);
            var contact2 = testContainer.Get(100);
            var contact3 = testContainer.Get(1);

            Assert.False(contact.IsActiveRecord);
            Assert.True(contact2.IsActiveRecord);
            Assert.True(contact3.IsActiveRecord);
        }

        [Fact]
        public void Save_updates_the_correct_record()
        {
            ContactRepository testContainer = GenerateSmallList();

            Contact newContact = new Contact();
            newContact.ContactID = 12;
            newContact.Email.Address = "different@gmail.com";
            newContact.FirstName = "New";
            newContact.LastName = "Contact";
            newContact.Cell.Number = "(888) 867-5309";
            newContact.Home.Number = "(888) 867-5309";
            newContact.Work.Number = "(888) 867-5309";

            testContainer.Save(newContact.ContactID, newContact);
            var testContact = testContainer.Get(newContact.ContactID);

            Assert.True(newContact.IsEqualTo(testContact));
        }

        private ContactRepository GenerateSmallList()
        {
            ContactRepository testContainer = new ContactRepository();

            Contact contact = new Contact();
            contact.ContactID = 12;
            contact.Email.Address = "newcontact1@gmail.com";
            contact.FirstName = "Test";
            contact.LastName = "Contact";
            contact.Cell.Number = "(888) 867-5309";
            contact.Home.Number = "(888) 867-5309";
            contact.Work.Number = "(888) 867-5309";

            Contact contact2 = new Contact();
            contact2.ContactID = 100;
            contact2.Email.Address = "newcontact12@gmail.com";
            contact2.FirstName = "Test";
            contact2.LastName = "Contact 100";
            contact2.Cell.Number = "(888) 867-5309";
            contact2.Home.Number = "(888) 867-5309";
            contact2.Work.Number = "(888) 867-5309";

            Contact contact3 = new Contact();
            contact3.ContactID = 1;
            contact3.Email.Address = "newcontact1@gmail.net";
            contact3.FirstName = "Test";
            contact3.LastName = "Contact";
            contact3.Cell.Number = "(888) 867-5309";
            contact3.Home.Number = "(888) 867-5309";
            contact3.Work.Number = "(888) 867-5309";

            Contact contact4 = new Contact();
            contact4.ContactID = 9;
            contact4.Email.Address = "newcontact1@gmail.ca";
            contact4.FirstName = "Tes";
            contact4.LastName = "Contac";
            contact4.Cell.Number = "(888) 867-5309";
            contact4.Home.Number = "(888) 867-5309";
            contact4.Work.Number = "(888) 867-5309";

            var recordnumber = testContainer.Save(contact);
            recordnumber = testContainer.Save(contact2);
            recordnumber = testContainer.Save(contact3);
            recordnumber = testContainer.Save(contact4);

            return testContainer;
        }
    }
}
