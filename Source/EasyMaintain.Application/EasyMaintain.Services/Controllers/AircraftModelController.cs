using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyMaintain.Business;

namespace EasyMaintain.Services.Controllers
{
    public class AircraftModelController : ApiController
    {
        // GET: api/AircraftModel
        [HttpGet]
        public IEnumerable<string> AircraftModel()
        {


            return new string[] { "value1", "value2" };
        }

        // GET: api/AircraftModel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AircraftModel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AircraftModel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AircraftModel/5
        public void Delete(int id)
        {
        }
    }
}
