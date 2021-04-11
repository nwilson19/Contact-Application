using NateCRM.Classes;
using System;
using Xunit;

namespace Testing
{
    public class RecordAttributesTests
    {
        [Fact]
        public void NewRecordAttributesHasValidRecordID()
        {
            RecordAttributes TestPerson = new RecordAttributes();

            //Act
            var test = TestPerson.RecordID;

            //Assert
            Assert.True(test >= 0);
        }

        [Fact]
        public void NewRecordAttributesCreatesLiveRecord()
        {
            RecordAttributes TestPerson = new RecordAttributes();

            //Act
            var test = TestPerson.Deleted;

            //Assert
            Assert.False(test);
        }
    }
}
