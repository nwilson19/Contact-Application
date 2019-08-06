using System.Collections.Generic;
using System.Linq;

namespace Nate.ContactApp
{
    public static class ContactsExtensions
    {
        // Post (Create new record)
        public static void Post(this Contacts database, Contact newContact)
        {
            if(newContact.IsValid())
                database.ContactList.Add(newContact);
        }

        //Put (Update a record)
        public static void Put(this Contacts database, int id, Contact updatedContact)
        {
            var currentRecord = database.ContactList.Find(i => i.contactID.Equals(id));
            database.ContactList.Remove(currentRecord);
            database.ContactList.Add(updatedContact);
        }

        //Get (Return a list)
        public static List<Contact> Get(this Contacts database)
        {
            return database.ContactList;
        }

        //Get( ID ) - return a single record
        public static Contact Get(this Contacts database, int id)
        {
            return database.ContactList.Find(i => i.contactID.Equals(id));
        }

        //Delete - set a flag
        public static void Delete(this Contacts database, int id)
        {
            database.ContactList.Find(i => i.contactID.Equals(id)).isActiveRecord = false;
        }

        //Search all fields for matches
        public static List<Contact> Filter(this Contacts database, string parameter)
        {
            var results =
                from contact in database.Get()
                where contact.isActiveRecord && (
                contact.firstName.Contains(parameter) || 
                contact.lastName.Contains(parameter) || 
                contact.email.Contains(parameter) ||
                contact.CellPhone.Contains(parameter) ||
                contact.HomePhone.Contains(parameter) ||
                contact.WorkPhone.Contains(parameter))
                select contact;

            return results.ToList();
        }
    }

}
