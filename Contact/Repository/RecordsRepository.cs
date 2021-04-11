using NateCRM.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NateCRM.Repository
{
    public class RecordsRepository
    {
        private static List<Record> Records = new List<Record>();

        public RecordsRepository()
        {
        }

        // Save (Create a new record)
        public int Save(Record newRecord)
        {
            if (newRecord.IsValid())
            {
                if (Records.Exists(i => i.RecordID.Equals(newRecord.RecordID)))
                    Save(newRecord.RecordID, newRecord);
                else
                    Records.Add(newRecord);
            }

            return newRecord.RecordID;
        }

        // Save (Update a record, return the record's ID)
        public int Save(int id, Record UpdatedRecord)
        {
            var currentRecord = Records.Find(i => i.RecordID.Equals(id));
            Records.Remove(currentRecord);
            Records.Add(UpdatedRecord);

            return UpdatedRecord.RecordID;
        }

        //Get (Return a list)
        public List<Record> Get()
        {
            var results = new List<Record>();
            foreach (Record record in Records)
                if (record.Attributes.Deleted == false)
                    results.Add(record);
            return results;
        }

        //Get( ID ) - return a single record
        public Record Get(int id)
        {
            // Currently will return null if an invalid id
            // Need to build in some exception handling for cases like this
            return Records.Find(i => i.RecordID.Equals(id));
        }

        //Delete - set a flag
        public void Delete(int id)
        {
            Records.Find(i => i.RecordID.Equals(id)).Attributes.Deleted = true;
        }
    }
}
