using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EasyMaintain.DTO;
using EasyMaintain.Business;

namespace EasyMaintain.MaintenanceWebAPI.Controllers
{
    public class CrewController : ApiController
    {
        CrewLogic crewLogic = new CrewLogic();
        public CrewController()
        {
        }

        // GET api/Crew
        [HttpGet]
        public IEnumerable<Crew> Get()
        {
            return (IEnumerable<Crew>)crewLogic.GetData();
        }
        // POST api/Crew
        [HttpPost]
        public IHttpActionResult Post(Crew crew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            crewLogic.Insert(crew);
            return CreatedAtRoute("DefaultApi", new { id = crew.CrewID }, crew);
        }
        // PUT api/Crew/5 
        [HttpPut]
        public IHttpActionResult Put( [FromBody]Crew crew)
        {
            if ( crew.Equals(0))
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            crewLogic.UpdateOne(crew);
            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE api/Crew/5 
        [HttpDelete]
        public void Delete([FromBody] Crew id)
        {
            crewLogic.DeleteOne(id);
        }
    }
}