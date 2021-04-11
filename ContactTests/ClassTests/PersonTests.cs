using NateCRM.Classes;
using System;
using Xunit;

namespace Testing
{
    public class PersonTests
    {
        [Fact]
        public void NewPersonHasValidRecordID()
        {
            Person TestPerson = new Person();

            //Act
            var test = TestPerson.RecordID;

            //Assert
            Assert.True(test >= 0);
        }

        [Fact]
        public void NewPersonHasValidFirstName()
        {
            Person TestPerson = new Person();

            //Act
            var test = TestPerson.FirstName;

            //Assert
            Assert.Equal("", test);
        }

        [Fact]
        public void NewPersonHasValidMiddleName()
        {
            Person TestPerson = new Person();

            //Act
            var test = TestPerson.MiddleName;

            //Assert
            Assert.Equal("", test);
        }

        [Fact]
        public void NewPersonHasValidLastName()
        {
            Person TestPerson = new Person();

            //Act
            var test = TestPerson.LastName;

            //Assert
            Assert.Equal("", test);
        }
    }
}
