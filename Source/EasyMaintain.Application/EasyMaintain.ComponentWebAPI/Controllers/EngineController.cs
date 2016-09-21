using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EasyMaintain.Business;



 namespace EasyMaintain.ComponentWebAPI.Controllers
{
    public class EngineController : ApiController
    {
        private Maintenance enginetype;

        public IBusiness EngineRepo { get; set; }

        public EngineController(IBusiness _repo)
        {
            EngineRepo = _repo;

        }

        // GET api/Engine
        [HttpGet]
        public IEnumerable<Maintenance> EngineTypes()
        {
            return (IEnumerable<Maintenance>)EngineRepo.GetData();
        }

        // GET api/Engine/5
        [ResponseType(typeof(Maintenance))]
        [HttpGet]
        public async Task<IHttpActionResult> EngineTypes(Maintenance EngineTypeID)
        {
            var item = enginetype.Find(EngineTypeID);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // PUT api/Engine/5
        [HttpPut]
        public async Task<IHttpActionResult> MaintenanceAdd(Maintenance EngineTypeID, Maintenance enginetype)
        {

            if (EngineTypeID == null || EngineTypeID.Equals(0))
            {
                return BadRequest();
            }

            else
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            EngineRepo.Insert(enginetype);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Engine
        [ResponseType(typeof(Maintenance))]
        [HttpPost]
        public async Task<IHttpActionResult>  EngineTypeUpdate(Maintenance enginetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EngineRepo.UpdateOne(enginetype);

            return CreatedAtRoute("DefaultApi", new { id = enginetype.WorkID }, enginetype);
        }

        // DELETE api/Engine/5
        [ResponseType(typeof(Maintenance))]
        [HttpDelete]
        public async Task<IHttpActionResult> EngineTypeDelete(Maintenance enginetype)
        {

            if (enginetype == null)
            {
                return NotFound();
            }

            EngineRepo.DeleteOne(enginetype);

            return Ok(enginetype);
        }
    }
}