using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nate.ContactApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public List<Contact> Get()
        {
            ContactRepository result = new ContactRepository();
            return result.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            ContactRepository database = new ContactRepository();
            return database.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            ContactRepository database = new ContactRepository();
            database.Post(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact value)
        {
            ContactRepository database = new ContactRepository();
            var recordID = database.Put(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ContactRepository database = new ContactRepository();
            database.Delete(id);
        }
    }
}
