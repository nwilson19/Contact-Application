using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nate.ContactApp
{
    public class ContactRepository
    {
        public List<Contact> ContactList;

        public ContactRepository()
        {
            ContactList = new List<Contact>();
        }

        // Post (Create new record)
        public void Post(ContactRepository database, Contact newContact)
        {
            if (newContact.IsValid())
                database.ContactList.Add(newContact);
        }

        //Put (Update a record)
        public void Put(ContactRepository database, int id, Contact updatedContact)
        {
            var currentRecord = database.ContactList.Find(i => i.contactID.Equals(id));
            database.ContactList.Remove(currentRecord);
            database.ContactList.Add(updatedContact);
        }

        //Get (Return a list)
        public List<Contact> Get(ContactRepository database)
        {
            return database.ContactList;
        }

        //Get( ID ) - return a single record
        public Contact Get(ContactRepository database, int id)
        {
            return database.ContactList.Find(i => i.contactID.Equals(id));
        }

        //Delete - set a flag
        public  void Delete(ContactRepository database, int id)
        {
            database.ContactList.Find(i => i.contactID.Equals(id)).isActiveRecord = false;
        }

        //Search all fields for matches
        public  List<Contact> Filter(ContactRepository database, string parameter)
        {
            var results =
                from contact in database.Get(database)
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
