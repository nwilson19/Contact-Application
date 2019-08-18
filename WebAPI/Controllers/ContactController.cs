using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nate.ContactApp
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        ContactRepository database = new ContactRepository();

        // GET: api/Contact
        [HttpGet]
        public List<Contact> Get()
        {
            GenerateSmallList();
            return database.Get();
        }

        // GET api/Contact/id
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return database.Get(id);
        }

        // POST api/Contact
        [HttpPost]
        public void Post([FromBody]Contact contact)
        {
            database.Post(contact);
        }

        // PUT api/Contact/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Contact contact)
        {
            database.Put(id, contact);
        }

        // DELETE api/Contact/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            database.Delete(id);
        }

        private void GenerateSmallList()
        {
            Contact contact = new Contact();
            contact.contactID = 12;
            contact.email = "newcontact1@gmail.com";
            contact.firstName = "Test";
            contact.lastName = "Contact";
            contact.CellPhone = "(888) 867-5309";
            contact.HomePhone = "(888) 867-5309";
            contact.WorkPhone = "(888) 867-5309";

            Contact contact2 = new Contact();
            contact2.contactID = 100;
            contact2.email = "newcontact12@gmail.com";
            contact2.firstName = "Test";
            contact2.lastName = "Contact 100";
            contact2.CellPhone = "(888) 867-5309";
            contact2.HomePhone = "(888) 867-5309";
            contact2.WorkPhone = "(888) 867-5309";

            Contact contact3 = new Contact();
            contact3.contactID = 1;
            contact3.email = "newcontact1@gmail.net";
            contact3.firstName = "Test";
            contact3.lastName = "Contact";
            contact3.CellPhone = "(888) 867-5309";
            contact3.HomePhone = "(888) 867-5309";
            contact3.WorkPhone = "(888) 867-5309";

            Contact contact4 = new Contact();
            contact4.contactID = 9;
            contact4.email = "newcontact1@gmail.ca";
            contact4.firstName = "Tes";
            contact4.lastName = "Contac";
            contact4.CellPhone = "(888) 867-5309";
            contact4.HomePhone = "(888) 867-5309";
            contact4.WorkPhone = "(888) 867-5309";


            database.Post(contact);
            database.Post(contact2);
            database.Post(contact3);
            database.Post(contact4);
        }
    }
}
