using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nate.ContactApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        ContactRepository database = new ContactRepository();

        // GET: api/Contact
        [HttpGet]
        public List<Contact> Get()
        {
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
            database.Save(contact);
        }

        // PUT api/Contact/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Contact contact)
        {
            database.Save(id, contact);
        }

        // DELETE api/Contact/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            database.Delete(id);
        }
    }
}
