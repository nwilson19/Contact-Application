using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NateCRM.Classes
{
    public class Record
    {
        public int RecordID;
        public Person Person;
        public RecordAttributes Attributes;

        public Record()
        {
            RecordID = 0;
            Person = new Person(RecordID);
            Attributes = new RecordAttributes(RecordID);
        }

        public Record(int ID)
        {
            RecordID = ID;
            Person = new Person(RecordID);
            Attributes = new RecordAttributes(RecordID);
        }

        public bool ValidateID(Record record)
        {
            var isValidID = true;

            if (record.RecordID < 0)
                isValidID = false;

            return isValidID;
        }
    }
}
