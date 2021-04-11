using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NateCRM.Classes
{
    public static class RecordValidator
    {
        public static bool IsValid(this Record record)
        {
            var isValidRecord = true;

            isValidRecord = record.ValidateID();

            if (isValidRecord)
                isValidRecord = record.Person.Email.Validate();
            if (isValidRecord)
                isValidRecord = record.ValidateName();
            if (isValidRecord)
                isValidRecord = record.Person.Home.Validate();
            if (isValidRecord)
                isValidRecord = record.Person.Work.Validate();
            if (isValidRecord)
                isValidRecord = record.Person.Cell.Validate();

            return isValidRecord;
        }



        private static bool ValidateName(this Record record)
        {
            var isValidName = true;

            if (record.Person.FirstName.Length == 0 && record.Person.LastName.Length == 0)
                isValidName = false;

            return isValidName;
        }
    }
}
