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
            Assert.Equal(12, testContact.contactID);
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
                var testContact = contactData.Get(contact.contactID);
                Assert.True(contact.IsEqual(contact, testContact));
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
            Assert.Equal(1, testContact.contactID);
        }

        [Fact]
        public void Delete_flags_correct_contact_as_inactive()
        {
            ContactRepository testContainer = GenerateSmallList();

            testContainer.Delete(12);
            var contact = testContainer.Get(12);
            var contact2 = testContainer.Get(100);
            var contact3 = testContainer.Get(1);

            Assert.False(contact.isActiveRecord);
            Assert.True(contact2.isActiveRecord);
            Assert.True(contact3.isActiveRecord);
        }

        [Fact]
        public void Put_updates_the_correct_record()
        {
            ContactRepository testContainer = GenerateSmallList();

            Contact newContact = new Contact();
            newContact.contactID = 12;
            newContact.email = "different@gmail.com";
            newContact.firstName = "New";
            newContact.lastName = "Contact";
            newContact.CellPhone = "(888) 867-5309";
            newContact.HomePhone = "(888) 867-5309";
            newContact.WorkPhone = "(888) 867-5309";

            testContainer.Put(newContact.contactID, newContact);
            var testContact = testContainer.Get(newContact.contactID);

            Assert.True(newContact.IsEqual(newContact, testContact));
        }

        [Fact]
        public void Filter_returns_expected_value_first_name()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = testContainer.Filter("Test");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("Test", contact.firstName);
            }
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void Filter_works_when_called_multiple_times()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = testContainer.Filter("Tes");
            var results2 = testContainer.Filter("Test");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("Tes", contact.firstName);
            }
            Assert.Equal(4, results.Count);

            foreach (Contact contact in results2)
            {
                Assert.Contains("Test", contact.firstName);
            }
            Assert.Equal(3, results2.Count);
        }

        [Fact]
        public void Filter_returns_expected_value_last_name()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = testContainer.Filter("Contact");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("Contact", contact.lastName);
            }
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void Filter_returns_expected_value_last_name2()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = testContainer.Filter("100");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("100", contact.lastName);
            }
            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Filter_returns_expected_value_email()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = testContainer.Filter(".com");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains(".com", contact.email);
            }
            Assert.Equal(2, results.Count);
        }



        private ContactRepository GenerateSmallList()
        {
            ContactRepository testContainer = new ContactRepository();

            Contact contact = new Contact();
            contact.contactID = 12;
            contact.email = "newcontact1@gmail.com";
            contact.firstName = "Test";
            contact.lastName = "Contact";
            contact.CellPhone = "(888) 867-5309";
            contact.HomePhone = "(888) 867-5309";
            contact.WorkPhone = "(888) 867-5309";

            Contact contact2 = new Contact();
            contact2.contactID = 100;
            contact2.email = "newcontact12@gmail.com";
            contact2.firstName = "Test";
            contact2.lastName = "Contact 100";
            contact2.CellPhone = "(888) 867-5309";
            contact2.HomePhone = "(888) 867-5309";
            contact2.WorkPhone = "(888) 867-5309";

            Contact contact3 = new Contact();
            contact3.contactID = 1;
            contact3.email = "newcontact1@gmail.net";
            contact3.firstName = "Test";
            contact3.lastName = "Contact";
            contact3.CellPhone = "(888) 867-5309";
            contact3.HomePhone = "(888) 867-5309";
            contact3.WorkPhone = "(888) 867-5309";

            Contact contact4 = new Contact();
            contact4.contactID = 9;
            contact4.email = "newcontact1@gmail.ca";
            contact4.firstName = "Tes";
            contact4.lastName = "Contac";
            contact4.CellPhone = "(888) 867-5309";
            contact4.HomePhone = "(888) 867-5309";
            contact4.WorkPhone = "(888) 867-5309";


            var recordnumber = testContainer.Post(contact);
            recordnumber = testContainer.Post(contact2);
            recordnumber = testContainer.Post(contact3);
            recordnumber = testContainer.Post(contact4);


            return testContainer;
        }
    }
}
