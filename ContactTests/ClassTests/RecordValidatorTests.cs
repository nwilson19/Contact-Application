using NateCRM;
using NateCRM.Classes;
using System;
using Xunit;
using Record = NateCRM.Classes.Record;

namespace Testing
{
    public class RecordValidatorTests
    {
        [Fact]
        public void Record_Validator_Phone_Number_Passes_When_Home_Phone_Exists()
        {
            //Arrange
            Record test = new Record();
            test.Person.Home.Number = "(888) 867-5309";
            var isValidID = true;

            //Act
            var testResult = test.Person.Home.Validate();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Record_Validator_Phone_Number_Fails_When_Home_Phone_Is_Garbage()
        {
            //Arrange
            Record test = new Record();
            test.Person.Home.Number = "(8-8) 8607-53009";
 
            //Act
            var testResult = test.Person.Home.Validate();

            //Assert
            Assert.False(testResult);
        }

        [Fact]
        public void Record_Validator_Phone_Number_Passes_When_Work_Phone_Exists()
        {
            //Arrange
            Record test = new Record();
            test.Person.Work.Number = "(888) 867-5309";
            var isValidID = true;

            //Act
            var testResult = test.Person.Work.Validate();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Record_Validator_Phone_Number_Fails_When_Work_Phone_Is_Garbage()
        {
            //Arrange
            Record test = new Record();
            test.Person.Work.Number = "(8-8) 8607-53009";

            //Act
            var testResult = test.Person.Work.Validate();

            //Assert
            Assert.False(testResult);
        }

        [Fact]
        public void Record_Validator_Phone_Number_Passes_When_Cell_Phone_Exists()
        {
            //Arrange
            Record test = new Record();
            test.Person.Cell.Number = "(888) 867-5309";
            var isValidID = true;

            //Act
            var testResult = test.Person.Cell.Validate();

            //Assert
            Assert.Equal(testResult, isValidID);
        }

        [Fact]
        public void Record_Validator_Phone_Number_Fails_When_Cell_Phone_Is_Garbage()
        {
            //Arrange
            Record test = new Record();
            test.Person.Cell.Number = "(8-8) 8607-53009";

            //Act
            var testResult = test.Person.Cell.Validate();

            //Assert
            Assert.False(testResult);
        }
    }
}
