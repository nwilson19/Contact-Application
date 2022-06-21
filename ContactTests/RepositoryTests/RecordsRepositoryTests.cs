using NateCRM;
using NateCRM.Classes;
using NateCRM.Repository;
using System;
using System.Collections.Generic;
using Xunit;
using Record = NateCRM.Classes.Record;

namespace Testing
{
    public class RecordsRepositoryTests
    {
        [Fact]
        public void Records_Constructor_returns_empty_List()
        {
            RecordsRepository testRecordsList = new RecordsRepository();
            List<Record> testValue = new List<Record>();
            var testList = testRecordsList.Get();

            Assert.Equal(testList, testValue);
        }

        [Fact]
        public void Get_using_ID_Returns_Valid_Record()
        {
            var testContainer = GenerateSmallList();

            //Act
            var testRecord = testContainer.Get(2);

            //Assert
            Assert.Equal(2, testRecord.RecordID);
        }

        [Fact]
        public void Get_using_Invalid_ID_Returns_null()
        {
            var testContainer = GenerateSmallList();

            //Act
            var testRecord = testContainer.Get(88);

            //Assert
            Assert.Null(testRecord);
        }

        [Fact]
        public void Get_returns_expected_list()
        {
            var records = GenerateSmallList();
            var newList = records.Get();

            foreach (Record record in newList)
            {
                var testRecord = records.Get(record.RecordID);
                Assert.True(record.IsEqualTo(testRecord));
            }
        }

        [Fact]
        public void Save_adds_new_record_successfully()
        {
            //Arrange
            RecordsRepository testContainer = GenerateSmallList();

            //Act
            var testRecord = testContainer.Get(1);

            //Assert
            Assert.Equal(1, testRecord.RecordID);
        }

        [Fact]
        public void Delete_flags_correct_contact_as_inactive()
        {
            RecordsRepository testContainer = GenerateSmallList();

            testContainer.Delete(2);
            var record = testContainer.Get(2);
            var record2 = testContainer.Get(3);
            var record3 = testContainer.Get(1);

            Assert.True(record.Attributes.Deleted);
            Assert.False(record2.Attributes.Deleted);
            Assert.False(record3.Attributes.Deleted);
        }

        [Fact]
        public void Save_updates_the_correct_record()
        {
            RecordsRepository testContainer = GenerateSmallList();

            Record newRecord = new Record(2);
            newRecord.Person.FirstName = "New";
            newRecord.Person.LastName = "Contact";

            testContainer.Save(newRecord.RecordID, newRecord);
            var testRecord = testContainer.Get(newRecord.RecordID);

            Assert.True(newRecord.IsEqualTo(testRecord));
        }

        private static RecordsRepository GenerateSmallList()
        {
            RecordsRepository testContainer = new RecordsRepository();

            Record record1 = new Record(12);
            record1.Person.FirstName = "Test";
            record1.Person.LastName = "Contact";
/*            contact.ContactID = 12;
            contact.Email.Address = "newcontact1@gmail.com";
            contact.FirstName = "Test";
            contact.LastName = "Contact";
            contact.Cell.Number = "(888) 867-5309";
            contact.Home.Number = "(888) 867-5309";
            contact.Work.Number = "(888) 867-5309";*/

            Record record2 = new Record(100);
            record2.Person.FirstName = "Test";
            record2.Person.LastName = "Contact 100";
/*            contact2.ContactID = 100;
            contact2.Email.Address = "newcontact12@gmail.com";
            contact2.FirstName = "Test";
            contact2.LastName = "Contact 100";
            contact2.Cell.Number = "(888) 867-5309";
            contact2.Home.Number = "(888) 867-5309";
            contact2.Work.Number = "(888) 867-5309";*/

            Record record3 = new Record(1);
            record3.Person.FirstName = "Test";
            record3.Person.LastName = "Contact";
/*            contact3.ContactID = 1;
            contact3.Email.Address = "newcontact1@gmail.net";
            contact3.FirstName = "Test";
            contact3.LastName = "Contact";
            contact3.Cell.Number = "(888) 867-5309";
            contact3.Home.Number = "(888) 867-5309";
            contact3.Work.Number = "(888) 867-5309";*/

            Record record4 = new Record(9);
            record4.Person.FirstName = "Tes";
            record4.Person.LastName = "Contac";
/*            contact4.ContactID = 9;
            contact4.Email.Address = "newcontact1@gmail.ca";
            contact4.FirstName = "Tes";
            contact4.LastName = "Contac";
            contact4.Cell.Number = "(888) 867-5309";
            contact4.Home.Number = "(888) 867-5309";
            contact4.Work.Number = "(888) 867-5309";*/

            testContainer.Save(record1);
            testContainer.Save(record2);
            testContainer.Save(record3);
            testContainer.Save(record4);

            return testContainer;
        }
    }
}
