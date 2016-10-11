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

        //  private MaintenanceLogic maintenanceLogic;

        MaintenanceLogic maintenanceLogic = new MaintenanceLogic();


        //public IBusiness EngineRepo { get; set; }

        //public MaintenanceController(IBusiness _repo)
        //{
        //    EngineRepo = _repo;

        //}
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

        // GET api/Maintenance/5 
        //public IHttpActionResult GetID(int id)
        //{
        //    var item = maintenanceLogic.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(item);
        //}

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
            //return CreatedAtRoute("DefaultApi", new { id = maintenance.WorkID }, maintenance);
        }

        // PUT api/Maintenance/5 
        [HttpPut]
        public IHttpActionResult Put(Maintenance workID, [FromBody]Maintenance maintenance)
        {
            if (workID == null || workID.Equals(0))
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
        public void Delete(int id)
        {
            maintenanceLogic.DeleteOne(id);
        }
    }
}
