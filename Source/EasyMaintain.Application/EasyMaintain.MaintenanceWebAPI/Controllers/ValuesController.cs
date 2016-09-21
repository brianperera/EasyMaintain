using EasyMaintain.Business;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace EasyMaintain.MaintenanceWebAPI.Controllers
{
    public class ValuesController : ApiController
    {

        private Maintenance enginetype;

        public IBusiness EngineRepo { get; set; }

        public ValuesController(IBusiness _repo)
        {
            EngineRepo = _repo;

        }
        public ValuesController()
        {

        }
        // GET api/values 
        [HttpGet]
        public IEnumerable<Maintenance> Maintenance()
        {
            return (IEnumerable<Maintenance>)enginetype.GetData();
        }

        // GET api/values/5 
        [HttpGet]
        public IHttpActionResult MaintenanceID([FromBody] Maintenance workID)
        {
            var item = enginetype.Find(workID);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);

            //return "value";
        }

        // POST api/values 
        [HttpPost]
        public IHttpActionResult Maintenance([FromBody]Maintenance maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            EngineRepo.UpdateOne(maintenance);
            return CreatedAtRoute("DefaultApi", new { id = maintenance.WorkID }, maintenance);
        }

        // PUT api/values/5 
        [HttpPut]
        public IHttpActionResult Maintenance(Maintenance workID, [FromBody]Maintenance maintenance)
        {
            if (workID == null || workID.Equals(0))
            {
                return BadRequest();
            }

            else
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            enginetype.Insert(maintenance);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/values/5 
        [HttpDelete]
        public void Delete(Maintenance workID)
        {
            enginetype.DeleteOne(workID);
        }
    }
}
