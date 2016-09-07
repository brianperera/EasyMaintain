using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyMaintain.Business;
using System.Threading.Tasks;

namespace EasyMaintain.ComponentWebAPI.Controllers
{
    public class AircraftModelController : ApiController
    {

        public IBusiness AircraftModelRepo { get; set; }
        public AircraftModel aircraftmodel;
        public AircraftModelController(IBusiness _repo)
        {
            AircraftModelRepo = _repo;

        }

        // GET: api/AircraftModel
        [HttpGet]
        public IEnumerable<AircraftModel> AircraftModel()
        {

            return (IEnumerable<AircraftModel>)AircraftModelRepo.GetData();
        }

        // GET: api/AircraftModel/5
        public async Task<IHttpActionResult> AircraftModelByID(AircraftModel AircraftModelID)
        {
            var item = aircraftmodel.Find(AircraftModelID);
            if (item == null)
            {
                return NotFound();

            }
            return Ok(item);
        }

        // POST: api/AircraftModel
        [HttpPost]
        public async Task<IHttpActionResult> Create(AircraftModel aircraft)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AircraftModelRepo.Insert(aircraft);

            return CreatedAtRoute("DefaultApi", new { id = aircraft.AircraftModelID }, aircraft);
        }

        // PUT: api/AircraftModel/5
        [HttpPut]
        public async Task<IHttpActionResult> EngineType(AircraftModel AircraftModelID, AircraftModel aircraft)
        {

            if (AircraftModelID == null || AircraftModelID.Equals(0))
            {
                return BadRequest();
            }

            else
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/AircraftModel/5
        [HttpDelete]
        public async Task<IHttpActionResult> EngineTypeDelete(AircraftModel aircraft)
        {

            if (aircraft == null)
            {
                return NotFound();
            }

            AircraftModelRepo.DeleteOne(aircraft);
           // EngineRepo.DeleteOne(enginetype);

            return Ok(aircraft);
        }
    }
}
