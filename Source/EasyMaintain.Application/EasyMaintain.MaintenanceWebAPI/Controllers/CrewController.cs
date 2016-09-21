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
    public class CrewController : ApiController
    {
        private Crew crew;

        public IBusiness CrewRepo { get; set; }

        public CrewController(IBusiness _repo)
        {
            CrewRepo = _repo;

        }

        // GET api/Engine
        [HttpGet]
        public IEnumerable<Crew> Crew()
        {
            return (IEnumerable<Crew>)CrewRepo.GetData();
        }

        // GET api/Engine/5
        [ResponseType(typeof(Crew))]
        [HttpGet]
        public async Task<IHttpActionResult> CrewID(Crew CrewName)
        {
            var item = crew.Find(CrewName);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // PUT api/CrewAdd/5
        [HttpPut]
        public async Task<IHttpActionResult> CrewAdd(Crew CrewName, Crew crew)
        {

            if (CrewName == null || CrewName.Equals(0))
            {
                return BadRequest();
            }

            else
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CrewRepo.Insert(crew);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Engine
        [ResponseType(typeof(Crew))]
        [HttpPost]
        public async Task<IHttpActionResult> CrewUpdate(Crew crew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CrewRepo.UpdateOne(crew);

            return CreatedAtRoute("DefaultApi", new { id = crew.Name }, crew);
        }

        // DELETE api/CrewDelete/5
        [ResponseType(typeof(Maintenance))]
        [HttpDelete]
        public async Task<IHttpActionResult> CrewDelete(Crew crew)
        {

            if (crew == null)
            {
                return NotFound();
            }

            CrewRepo.DeleteOne(crew);

            return Ok(crew);
        }
    }
}