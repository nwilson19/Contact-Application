using System;
using System.Collections.Generic;
using System.Text;

namespace Nate.ContactApp
{
    interface IContactRepository
    {
        void Post(Contact newContact);
        // Post (Create new record)

        void Put(int id, Contact updatedContact);
        //Put (Update a record)

        List<Contact> Get();
        //Get (Return a list)

        Contact Get(int id);
        //Get( ID ) - return a single record

        void Delete(int id);
        //Delete - set a flag
    }
}
