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
    }
}
