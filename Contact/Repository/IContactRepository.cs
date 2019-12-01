using System;
using System.Collections.Generic;
using System.Text;

namespace Nate.ContactApp
{
    interface IContactRepository
    {
        int Post(Contact newContact);
        // Post (Create new record)

        int Put(int id, Contact updatedContact);
        //Put (Update a record, return the record's ID)

        List<Contact> Get();
        //Get (Return a list)

        Contact Get(int id);
        //Get( ID ) - return a single record

        void Delete(int id);
        //Delete - set a flag
    }
}
