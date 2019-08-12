using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nate.ContactApp
{
    public class ContactRepository : IContactRepository
    {
        public List<Contact> ContactList;
        private string lastSearchString;
        private List<Contact> lastSearch;

        public ContactRepository()
        {
            ContactList = new List<Contact>();
            lastSearchString = string.Empty;
            lastSearch = new List<Contact>();
        }

        // Post (Create new record)
        public void Post(Contact newContact)
        {
            if (newContact.IsValid())
                ContactList.Add(newContact);
        }

        //Put (Update a record)
        public void Put(int id, Contact updatedContact)
        {
            var currentRecord = ContactList.Find(i => i.contactID.Equals(id));
            ContactList.Remove(currentRecord);
            ContactList.Add(updatedContact);
        }

        //Get (Return a list)
        public List<Contact> Get()
        {
            return ContactList;
        }

        //Get( ID ) - return a single record
        public Contact Get(int id)
        {
            return ContactList.Find(i => i.contactID.Equals(id));
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
