using System;
using Xunit;

namespace Nate.ContactApp.Tests
{
    public class SearchTests
    {
        [Fact]
        public void Filter_returns_expected_value_first_name()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = Search.Filter(testContainer.Get(), "Test");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("Test", contact.FirstName);
            }
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void Filter_works_when_called_multiple_times()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = Search.Filter(testContainer.Get(), "Tes");
            var results2 = Search.Filter(testContainer.Get(), "Test");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("Tes", contact.FirstName);
            }
            Assert.Equal(4, results.Count);

            foreach (Contact contact in results2)
            {
                Assert.Contains("Test", contact.FirstName);
            }
            Assert.Equal(3, results2.Count);
        }

        [Fact]
        public void Filter_returns_expected_value_last_name()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = Search.Filter(testContainer.Get(), "Contact");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("Contact", contact.LastName);
            }
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void Filter_returns_expected_value_last_name2()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = Search.Filter(testContainer.Get(), "100");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("100", contact.LastName);
            }
            Assert.Single(results);
        }

        [Fact]
        public void Filter_returns_expected_value_email()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = Search.Filter(testContainer.Get(), ".com");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains(".com", contact.Email.Address);
            }
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void Filter_returns_expected_while_ignoring_capitalization()
        {
            var testContainer = GenerateSmallList();

            //Act
            var results = Search.Filter(testContainer.Get(), "TEST");

            //Assert
            foreach (Contact contact in results)
            {
                Assert.Contains("Test", contact.FirstName);
            }
            Assert.Equal(3, results.Count);
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
