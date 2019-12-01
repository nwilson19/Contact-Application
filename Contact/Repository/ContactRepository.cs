using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nate.ContactApp
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> ContactList = new List<Contact>();

        public ContactRepository()
        {
        }

        // Save Function name to hide the HTTP verbs for saving
        public int Save(Contact newContact)
        {
            return Post(newContact);
        }

        public int Save(int id, Contact newContact)
        {
            return Put(id, newContact);
        }

        // Post (Create new record)
        public int Post(Contact newContact)
        {
            if (newContact.IsValid())
            {
                if (ContactList.Exists(i => i.ContactID.Equals(newContact.ContactID)))
                    Put(newContact.ContactID, newContact);
                else
                    ContactList.Add(newContact);
            }

            return newContact.ContactID;
        }

        //Put (Update a record, return the record's ID)
        public int Put(int id, Contact updatedContact)
        {
            var currentRecord = ContactList.Find(i => i.ContactID.Equals(id));
            ContactList.Remove(currentRecord);
            ContactList.Add(updatedContact);

            return updatedContact.ContactID;
        }

        //Get (Return a list)
        public List<Contact> Get()
        {
            var results = new List<Contact>();
            foreach(Contact contact in ContactList)
                if (contact.IsActiveRecord)
                    results.Add(contact);
            return results;
        }

        //Get( ID ) - return a single record
        public Contact Get(int id)
        {
            // Currently will return null if an invalid id
            // Need to build in some exception handling for cases like this
            return ContactList.Find(i => i.ContactID.Equals(id));
        }

        //Delete - set a flag
        public void Delete(int id)
        {
            ContactList.Find(i => i.ContactID.Equals(id)).IsActiveRecord = false;
        }
    }
}
