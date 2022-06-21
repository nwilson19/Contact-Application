using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NateCRM.Classes;
using NateCRM.Repository;

namespace NateCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        RecordsRepository database = new RecordsRepository();

        // GET: api/Contact
        [HttpGet]
        public List<Record> Get()
        {
            return database.Get();
        }

        // GET api/Contact/id
        [HttpGet("{id}")]
        public Record Get(int id)
        {
            return database.Get(id);
        }

        // POST api/Contact
        [HttpPost]
        public void Post([FromBody]Record record)
        {
            database.Save(record);
        }

        // PUT api/Contact/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Record record)
        {
            database.Save(id, record);
        }

        // DELETE api/Contact/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            database.Delete(id);
        }
    }
}
