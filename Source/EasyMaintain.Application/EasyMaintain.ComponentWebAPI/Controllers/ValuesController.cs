using EasyMaintain.Business;
using EasyMaintain.Business.Entities;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace EasyMaintain.ComponentWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        public IBusiness ComponentWorkRepo { get; set; }
        public ComponentWork componentWork;

        public ValuesController(IBusiness _repo)
        {
            ComponentWorkRepo = _repo;
        }
        // GET api/ComponentWorkData
        [HttpGet]
        public IEnumerable<ComponentWork> ComponentWorkData()
        {
            return (IEnumerable<ComponentWork>)ComponentWorkRepo.GetData();

        }

        // GET api/ComponentWorkByID/5 

        [HttpGet]
        public IHttpActionResult ComponentWorkByID(ComponentWork workID)
        {
            var item = componentWork.Find(workID);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item); ;
        }
        // POST api/ComponentWorkCreate 
        [HttpPost]
        public IHttpActionResult ComponentWorkCreate([FromBody]ComponentWork componentWork)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ComponentWorkRepo.UpdateOne(componentWork);
            return CreatedAtRoute("DefaultApi", new { id = componentWork.WorkID }, componentWork);
        }

        // PUT api/ComponentWorkInsert/5 
        [HttpPut]
        public IHttpActionResult ComponentWorkInsert(ComponentWork workID, [FromBody]ComponentWork component)
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

            ComponentWorkRepo.Insert(component);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/ComponentWorkDelete/5 
        [HttpDelete]

        public void ComponentWorkDelete(ComponentWork workID)
        {

            ComponentWorkRepo.DeleteOne(workID);
        }
    }
}
