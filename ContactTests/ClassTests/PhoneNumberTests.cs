using NateCRM;
using NateCRM.Classes;
using System;
using Xunit;

namespace Testing
{
    public class PhoneNumberTests
    {
        [Fact]
        public void New_Phone_Number_Begins_As_Null()
        {
            PhoneNumber TestNumber = new PhoneNumber();

            //Act
            var test = TestNumber.Number;

            //Assert
            Assert.True(test == null);
        }

        [Fact]
        public void Phone_Number_Removes_Formatting_Properly()
        {
            PhoneNumber TestNumber = new PhoneNumber();

            //Act
            TestNumber.Number = "(800) 123-9876";

            //Assert
            Assert.True(TestNumber.Number == "8001239876");
        }

        [Fact]
        public void Phone_Number_Is_Valid_When_Empty()
        {
            //Arrange
            PhoneNumber test = new PhoneNumber();

            //Act
            var testResult = test.Validate();

            //Assert
            Assert.True(testResult);
        }

        [Fact]
        public void Phone_Number_Is_Invalid_When_Garbage()
        {
            //Arrange
            PhoneNumber test = new PhoneNumber();
            test.Number = "(10-) 1-2-310";

            //Act
            var testResult = test.Validate();

            //Assert
            Assert.False(testResult);
        }

    }
}