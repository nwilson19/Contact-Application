using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Nate.ContactApp.Tests
{
    public class ValidatorTests
    {
        [Fact]
        public void Contact_Validator_Email_Passes_When_At_Symbol_Exists()
        {
            //Arrange
            Contact test = new Contact();
            var isValidID = true;

            //Act
            test.Email.Address = "test@test.com";
            var testResult = test.hasValidEmail();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_Email_Fails_When_At_Symbol_Is_Missing()
        {
            //Arrange
            Contact test = new Contact();
            var isValidEmail = false;

            //Act
            test.Email.Address = "testtest.com";
            var testResult = test.hasValidEmail();

            //Assert
            Assert.Equal(testResult, isValidEmail);
        }

        [Fact]
        public void Contact_Validator_ID_Fails_When_Contact_ID_Less_Than_Zero()
        {
            //Arrange
            Contact test = new Contact();
            var isValidID = false;

            //Act
            test.ContactID = -1;
            var testResult = test.hasValidID();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_ID_Passes_When_Contact_ID_Equals_Zero()
        {
            //Arrange
            Contact test = new Contact();
            var isValidID = true;

            //Act
            test.ContactID = 0;
            var testResult = test.hasValidID();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_ID_Passes_When_Contact_ID_Greater_Than_Zero()
        {
            //Arrange
            Contact test = new Contact();
            var isValidID = true;

            //Act
            test.ContactID = 7854362;
            var testResult = test.hasValidID();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_Name_Passes_When_First_Name_Exists()
        {
            //Arrange
            Contact test = new Contact();
            var isValidID = true;

            //Act
            test.FirstName = "Test";
            var testResult = test.hasValidName();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_Name_Passes_When_Last_Name_Exists()
        {
            //Arrange
            Contact test = new Contact();
            var isValidID = true;

            //Act
            test.LastName = "Test";
            var testResult = test.hasValidName();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_Name_Fails_When_Neither_First_Or_Last_Name_Exists()
        {
            //Arrange
            Contact test = new Contact();
            var isValidID = false;

            //Act
            var testResult = test.hasValidName();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_Phone_Number_Passes_When_Empty()
        {
            //Arrange
            Contact test = new Contact();
            var isValidID = true;

            //Act
            var testResult = test.hasValidPhone();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_Phone_Number_Passes_When_Home_Phone_Exists()
        {
            //Arrange
            Contact test = new Contact();
            test.Home.Number = "(888) 867-5309";
            var isValidID = true;

            //Act
            var testResult = test.hasValidPhone();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_Phone_Number_Passes_When_Work_Phone_Exists()
        {
            //Arrange
            Contact test = new Contact();
            test.Work.Number = "(888) 867-5309";
            var isValidID = true;

            //Act
            var testResult = test.hasValidPhone();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Contact_Validator_Phone_Number_Passes_When_Cell_Phone_Exists()
        {
            //Arrange
            Contact test = new Contact();
            test.Cell.Number = "(888) 867-5309";
            var isValidID = true;

            //Act
            var testResult = test.hasValidPhone();

            //Assert
            Assert.Equal(testResult, isValidID);
        }
    }
}
