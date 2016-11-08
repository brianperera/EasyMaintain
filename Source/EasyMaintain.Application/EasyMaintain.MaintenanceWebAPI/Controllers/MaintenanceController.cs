using EasyMaintain.Business;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using EasyMaintain.DTO;
using System.Net.Http;

namespace EasyMaintain.MaintenanceWebAPI.Controllers
{
    public class MaintenanceController : ApiController
    {
        MaintenanceLogic maintenanceLogic = new MaintenanceLogic();
        public MaintenanceController()
        {
        }
        // GET api/Maintenance
        [Authorize]
        [HttpGet]
        public IEnumerable<Maintenance> Get()
        {
            return (IEnumerable<Maintenance>)maintenanceLogic.GetData();
        }
        // POST api/Maintenance
        [HttpPost]
        public IHttpActionResult Post(Maintenance maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            maintenanceLogic.Insert(maintenance);   
            return CreatedAtRoute("DefaultApi", new { id = 100 }, maintenance);         
        }
        // PUT api/Maintenance/5 
        [HttpPut]
        public IHttpActionResult Put( [FromBody]Maintenance maintenance)
        {
            if (maintenance.WorkID.Equals(0))
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            maintenanceLogic.UpdateOne(maintenance);
            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE api/Maintenance/5 
        [HttpDelete]
        public void Delete([FromBody]Maintenance id)
        {
            maintenanceLogic.DeleteOne(id);
        }
    }
}
