using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nate.ContactApp
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> ContactList = new List<Contact>();
        private string lastSearchString;
        private List<Contact> lastSearch;

        public ContactRepository()
        {
            lastSearchString = string.Empty;
            lastSearch = new List<Contact>();
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
                ContactList.Add(newContact);

            return newContact.contactID;
        }

        //Put (Update a record, return the record's ID)
        public int Put(int id, Contact updatedContact)
        {
            var currentRecord = ContactList.Find(i => i.contactID.Equals(id));
            ContactList.Remove(currentRecord);
            ContactList.Add(updatedContact);

            return updatedContact.contactID;
        }

        //Get (Return a list)
        public List<Contact> Get()
        {
            return ContactList;
        }

        //Get( ID ) - return a single record
        public Contact Get(int id)
        {
            // Currently will return null if an invalid id
            // Need to build in some exception handling for cases like this
            var result = ContactList.Find(i => i.contactID.Equals(id));
            return result;
        }

        //Delete - set a flag
        public void Delete(int id)
        {
            ContactList.Find(i => i.contactID.Equals(id)).isActiveRecord = false;
        }

        //Search all fields for matches
        public List<Contact> Filter(string parameter)
        {
            var results = new List<Contact>();

            if (parameter.Contains(lastSearchString) && lastSearchString != string.Empty)
                if(parameter == lastSearchString)
                    results = lastSearch;
                else
                    results = searchAllFields(lastSearch, parameter);
            else   
                results = searchAllFields(ContactList, parameter);

            lastSearch = results;
            lastSearchString = parameter;

            return results;
        }

        private List<Contact> searchAllFields(List<Contact> database, string parameter)
        {
            var searchData =
            from contact in database
            where contact.isActiveRecord && (
            contact.firstName.Contains(parameter) ||
            contact.lastName.Contains(parameter) ||
            contact.email.Contains(parameter) ||
            contact.CellPhone.Contains(parameter) ||
            contact.HomePhone.Contains(parameter) ||
            contact.WorkPhone.Contains(parameter))
            select contact;

            return searchData.ToList();
        }
    }
}
