using System;
using System.Collections.Generic;
using System.Text;

namespace Nate.ContactApp
{
    interface IContactRepository
    {
        // Post (Create new record)
        void Post(ContactRepository database, Contact newContact);

        //Put (Update a record)
        void Put(ContactRepository database, int id, Contact updatedContact);

        //Get (Return a list)
        List<Contact> Get(ContactRepository database);

        //Get( ID ) - return a single record
        Contact Get(ContactRepository database, int id);

        //Delete - set a flag
        void Delete(ContactRepository database, int id);
    }
}
