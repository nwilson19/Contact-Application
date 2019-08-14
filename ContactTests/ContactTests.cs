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
            Assert.Equal(test.contactID, isValidID);
        }

        [Fact]
        public void Phone_Numbers_Are_Stored_Without_Extra_Characters()
        {
            //Arrange
            var test = "(816) 867-5309";
            Contact contact = new Contact();

            //Act
            contact.HomePhone = test;
            contact.WorkPhone = test;
            contact.CellPhone = test;

            //Assert
            Assert.Equal("8168675309", contact.HomePhone);
            Assert.Equal("8168675309", contact.WorkPhone);
            Assert.Equal("8168675309", contact.CellPhone);
        }

        [Fact]
        public void Equals_Properly_Compares_Two_Contacts()
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

            var isEqual = contact1.Equals(contact2);

            Assert.True(isEqual);

        }
    }
}
