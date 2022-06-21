using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NateCRM.Classes
{
    public class RecordAttributes
    {
        public int RecordID;
        public bool Deleted;

        public RecordAttributes()
        {
            RecordID = 0;
            Deleted = false;
        }
        public RecordAttributes(int ID)
        {
            RecordID = ID;
            Deleted = false;
        }
    }
}
