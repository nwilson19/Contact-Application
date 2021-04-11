using NateCRM;
using NateCRM.Classes;
using System;
using Xunit;

namespace Testing
{
    public class EmailAddressTests
    {
        [Fact]
        public void NewEmailAddressCreatedAsNull()
        {
            EmailAddress Test = new EmailAddress();

            //Act
            var test = Test.Address;

            //Assert
            Assert.True(test == null);
        }

        [Fact]
        public void Email_Is_Valid_When_At_Symbol_Exists()
        {
            //Arrange
            EmailAddress test = new EmailAddress();
            var isValidID = true;

            //Act
            test.Address = "test@test.com";
            var testResult = test.Validate();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Email_Is_Not_Valid_When_At_Symbol_Is_Missing()
        {
            //Arrange
            EmailAddress test = new EmailAddress();
            var isValidEmail = false;

            //Act
            test.Address = "testtest.com";
            var testResult = test.Validate();

            //Assert
            Assert.Equal(testResult, isValidEmail);
        }
    }
}