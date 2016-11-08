using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using EasyMaintain.DTO;
using EasyMaintain.Business;
using System.Net;

namespace EasyMaintain.MaintenanceWebAPI.Controllers
{
   public class AircraftmodelController : ApiController
    {
        AircraftModelLogic aircraftModelLogic = new AircraftModelLogic();
        public AircraftmodelController()
        {
        }
        // GET api/Aircraftmodel
        [HttpGet]
        public IEnumerable<AircraftModel> Get()
        {
            return (IEnumerable<AircraftModel>)aircraftModelLogic.GetData();
        }
        // POST api/Aircraftmodel
        [HttpPost]
        public IHttpActionResult Post(AircraftModel aircraftmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            aircraftModelLogic.Insert(aircraftmodel);
            return CreatedAtRoute("DefaultApi", new { id = aircraftmodel.AircraftModelID }, aircraftmodel);
        }
        // PUT api/Aircraftmodel/5 
        [HttpPut]
        public IHttpActionResult Put( [FromBody]AircraftModel aircraft)
        {
            if (aircraft.Equals(0))
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            aircraftModelLogic.UpdateOne(aircraft);
            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE api/Aircraftmodel/5 
        [HttpDelete]
        public void Delete(int id)
        {
            aircraftModelLogic.DeleteOne(id);
        }
    }
}
