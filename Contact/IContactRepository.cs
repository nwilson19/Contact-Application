using System;
using System.Collections.Generic;
using System.Text;

namespace Nate.ContactApp
{
    interface IContactRepository
    {
        void Post(ContactRepository database, Contact newContact);
        // Post (Create new record)

        void Put(ContactRepository database, int id, Contact updatedContact);
        //Put (Update a record)

        List<Contact> Get(ContactRepository database);
        //Get (Return a list)

        Contact Get(ContactRepository database, int id);
        //Get( ID ) - return a single record

        void Delete(ContactRepository database, int id);
        //Delete - set a flag
    }
}
