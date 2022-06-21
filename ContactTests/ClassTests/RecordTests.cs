using NateCRM;
using NateCRM.Classes;
using System;
using Xunit;
using Record = NateCRM.Classes.Record;

namespace Testing
{
    public class RecordTests
    {
        [Fact]
        public void DefaultNewRecordHasValidRecordID()
        {
            Record TestRecord = new Record();

            //Act
            var test = TestRecord.RecordID;

            //Assert
            Assert.True(test >= 0);
        }

        [Fact]
        public void DefaultRecordIDMatchesPersonsRecordID()
        {
            Record TestRecord = new Record();

            //Act
            var test = TestRecord.RecordID;

            //Assert
            Assert.True(test == TestRecord.RecordID);
        }

        [Fact]
        public void DefaultRecordIDMatchesAttributesRecordID()
        {
            Record TestRecord = new Record();

            //Act
            var test = TestRecord.RecordID;

            //Assert
            Assert.True(test == TestRecord.RecordID);
        }

        [Fact]
        public void NewRecordHasValidRecordID()
        {
            Record TestRecord = new Record(5);

            //Act
            var test = TestRecord.RecordID;

            //Assert
            Assert.True(test == 5);
        }

        [Fact]
        public void RecordIDMatchesPersonsRecordID()
        {
            Record TestRecord = new Record(5);

            //Act
            var test = TestRecord.RecordID;

            //Assert
            Assert.True(test == TestRecord.RecordID);
        }

        [Fact]
        public void RecordIDMatchesAttributesRecordID()
        {
            Record TestRecord = new Record(5);

            //Act
            var test = TestRecord.RecordID;

            //Assert
            Assert.True(test == TestRecord.RecordID);
        }

        [Fact]
        public void Record_ID_Validator_Fails_When_RecordID_Less_Than_Zero()
        {
            //Arrange
            Record test = new Record();

            //Act
            test.RecordID = -1;
            var testResult = test.ValidateID();

            //Assert
            Assert.False(testResult);
        }

        [Fact]
        public void Record_ID_Validator_Passes_When_RecordID_Equals_Zero()
        {
            //Arrange
            Record test = new Record();

            //Act
            test.RecordID = 0;
            var testResult = test.ValidateID(); 

            //Assert
            Assert.True(testResult);
        }

        [Fact]
        public void Record_ID_Validator_Passes_When_RecordID_Greater_Than_Zero()
        {
            //Arrange
            Record test = new Record();

            //Act
            test.RecordID = 7854362;
            var testResult = test.ValidateID();

            //Assert
            Assert.True(testResult);
        }

    }
}