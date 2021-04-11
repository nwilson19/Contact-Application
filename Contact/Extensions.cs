using NateCRM.Classes;
using System;

namespace NateCRM
{
    public static class Extensions
    {
        public static bool IsEqualTo(this Record record, Record record2)
        {
            return (record.Attributes.Deleted == record2.Attributes.Deleted && record.RecordID == record2.RecordID &&
                    record.Person.Email.Address == record2.Person.Email.Address && record.Person.FirstName == record2.Person.FirstName &&
                    record.Person.LastName == record2.Person.LastName && record.Person.Cell.Number == record2.Person.Cell.Number &&
                    record.Person.Home.Number == record2.Person.Home.Number && record.Person.Work.Number == record.Person.Work.Number);
        }

        /// <summary>
        /// Extended version of the string.Contains() method, 
        /// accepting a [StringComparison] object to perform different kind of comparisons
        /// </summary>
        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            return source?.IndexOf(value, comparisonType) >= 0;
        }

        /// <summary>
        /// Extended version of the EmailAddress.Validate() method, 
        /// accepting an [EmailAddress] object to perform different kind of comparisons
        /// </summary>
        public static bool Validate(this EmailAddress EmailAddress)
        {          
            return EmailAddress.Validate(EmailAddress);
        }

        /// <summary>
        /// Extended version of the PhoneNumber.Validate() method, 
        /// accepting an [PhoneNumber] object to perform different kind of comparisons
        /// </summary>
        public static bool Validate(this PhoneNumber Phone)
        {
            return Phone.Validate(Phone);
        }

        /// <summary>
        /// Extended version of the Record.ValidateID() method, 
        /// accepting an [Record] object to check the RecordID
        /// </summary>
        public static bool ValidateID(this Record record)
        {
            return record.ValidateID(record);
        }
    }
}
