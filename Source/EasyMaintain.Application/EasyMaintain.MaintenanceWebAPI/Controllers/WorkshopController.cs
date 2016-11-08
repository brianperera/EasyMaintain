using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using EasyMaintain.Business;
using EasyMaintain.DTO;
using System.Net;

namespace EasyMaintain.MaintenanceWebAPI.Controllers
{
    public class WorkshopController: ApiController
    {


        WorkshopLogic workshopLogic = new WorkshopLogic();

        public WorkshopController()
        {

        }

        // GET api/Workshop
        [HttpGet]
        public IEnumerable<Workshop> Get()
        {
            return (IEnumerable<Workshop>)workshopLogic.GetData();
        }

        //GET api/Workshop/5 
        //public IHttpActionResult GetID(int id)
        //{
        //    var item = workshopLogic.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(item);
        //}



        // POST api/Workshop
        [HttpPost]
        public IHttpActionResult Post(Workshop workshop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            workshopLogic.Insert(workshop);

            return CreatedAtRoute("DefaultApi", new { id = workshop.WorkshopID }, workshop);
        }


        // PUT api/Workshop/5 
        [HttpPut]
        public IHttpActionResult Put( [FromBody]Workshop workshop)
        {
            if ( workshop.WorkshopID.Equals(0))
            {
                return BadRequest();
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            workshopLogic.UpdateOne(workshop);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/Workshop/5 
        [HttpDelete]
        public void Delete([FromBody] Workshop id)
        {
            workshopLogic.DeleteOne(id);
        }
    }
}
