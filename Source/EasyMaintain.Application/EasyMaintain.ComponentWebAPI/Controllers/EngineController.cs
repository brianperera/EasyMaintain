using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EasyMaintain.Business;

namespace EasyMaintain.Services.Controllers
{
    public class EngineController : ApiController
    {
        private EngineType enginetype;

        public IBusiness EngineRepo { get; set; }
        public EngineType engine_type;

        public EngineController(IBusiness _repo)
        {
            EngineRepo = _repo;

        }

        // GET api/Engine
        [HttpGet]
        public IEnumerable<EngineType> EngineTypes()
        {
            return (IEnumerable<EngineType>)EngineRepo.GetData();
        }

        // GET api/Engine/5
        [ResponseType(typeof(EngineType))]
        [HttpGet]
        public async Task<IHttpActionResult> EngineTypes(EngineType EngineTypeID)
        {
            var item = engine_type.Find(EngineTypeID);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // PUT api/Engine/5
        [HttpPut]
        public async Task<IHttpActionResult> EngineType(EngineType EngineTypeID, EngineType enginetype)
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
        [ResponseType(typeof(EngineType))]
        [HttpPost]
        public async Task<IHttpActionResult> EngineType(EngineType enginetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EngineRepo.UpdateOne(enginetype);

            return CreatedAtRoute("DefaultApi", new { id = enginetype.EngineTypeID }, enginetype);
        }

        // DELETE api/Engine/5
        [ResponseType(typeof(EngineType))]
        [HttpDelete]
        public async Task<IHttpActionResult> EngineTypeDelete(EngineType enginetype)
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