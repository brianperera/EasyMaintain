using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EasyMaintain.Business;
using EasyMaintain.Business.Entities;


namespace EasyMaintain.MaintenanceWebAPI.Controllers
{
    public class MaintenanceChecksController : ApiController
    {
        private MaintenanceChecks checks;

        public IBusiness MaintenanceChecksRepo { get; set; }

        public MaintenanceChecksController(IBusiness _repo)
        {
            MaintenanceChecksRepo = _repo;

        }

        // GET api/MaintenanceChecks
        [HttpGet]
        public IEnumerable<MaintenanceChecks> MaintenanceChecks()
        {
            return (IEnumerable<MaintenanceChecks>)MaintenanceChecksRepo.GetData();
        }

        // GET api/MaintenanceChecksID/5
        [ResponseType(typeof(MaintenanceChecks))]
        [HttpGet]
        public async Task<IHttpActionResult> MaintenanceChecksID(MaintenanceChecks checksID)
        {
            var item = checks.Find(checksID);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // PUT api/MaintenanceAdd/5
        [HttpPut]
        public async Task<IHttpActionResult> MaintenanceAdd(MaintenanceChecks MaintenanceCheckID, MaintenanceChecks checks)
        {

            if (MaintenanceCheckID == null || MaintenanceCheckID.Equals(0))
            {
                return BadRequest();
            }

            else
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MaintenanceChecksRepo.Insert(checks);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Engine
        [ResponseType(typeof(MaintenanceChecks))]
        [HttpPost]
        public async Task<IHttpActionResult> MaintenanceUpdate(MaintenanceChecks checks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MaintenanceChecksRepo.UpdateOne(checks);

            return CreatedAtRoute("DefaultApi", new { id = checks.MaintenanceCheckID }, checks);
        }

        // DELETE api/MaintenanceDelete/5
        [ResponseType(typeof(MaintenanceChecks))]
        [HttpDelete]
        public async Task<IHttpActionResult> MaintenanceDelete(MaintenanceChecks checks)
        {

            if (checks == null)
            {
                return NotFound();
            }

            MaintenanceChecksRepo.DeleteOne(checks);

            return Ok(checks);
        }
    }
}