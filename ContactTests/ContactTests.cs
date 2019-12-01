using Xunit;

namespace Nate.ContactApp.Tests
{
    public class ContactTests
    {
        [Fact]
        public void Contact_Constructor_Creates_Valid_CustomerID()
        {
            //Arrange
            Contact test = new Contact();
            int isValidID = 0;

            //Act

            //Assert
            Assert.Equal(test.ContactID, isValidID);
        }

        [Fact]
        public void Phone_Numbers_Are_Stored_Without_Extra_Characters()
        {
            //Arrange
            var test = "(816) 867-5309";
            Contact contact = new Contact();

            //Act
            contact.Home.Number = test;
            contact.Work.Number = test;
            contact.Cell.Number = test;

            //Assert
            Assert.Equal("8168675309", contact.Home.Number);
            Assert.Equal("8168675309", contact.Work.Number);
            Assert.Equal("8168675309", contact.Cell.Number);
        }

        [Fact]
        public void Equals_Properly_Compares_Two_Contacts()
        {
            Contact contact1 = new Contact();
            contact1.ContactID = 12;
            contact1.Email.Address = "different@gmail.com";
            contact1.FirstName = "New";
            contact1.LastName = "Contact";
            contact1.Cell.Number = "(888) 867-5309";
            contact1.Home.Number = "(888) 867-5309";
            contact1.Work.Number = "(888) 867-5309";
            Contact contact2 = new Contact();
            contact2.ContactID = 12;
            contact2.Email.Address = "different@gmail.com";
            contact2.FirstName = "New";
            contact2.LastName = "Contact";
            contact2.Cell.Number = "(888) 867-5309";
            contact2.Home.Number = "(888) 867-5309";
            contact2.Work.Number = "(888) 867-5309";

            var isEqual = contact1.IsEqualTo(contact2);

            Assert.True(isEqual);
        }
    }
}
