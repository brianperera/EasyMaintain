using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EasyMaintain.Business;
using EasyMaintain.Services.Models;

namespace EasyMaintain.InventoryWebAPI.Controllers
{
    public class SparePartsController : ApiController
    {
        public IBusiness SparePartsRepo { get; set; }
        public SparePart sparepart;
        public SparePartsController(IBusiness _repo)
        {
            SparePartsRepo = _repo;
        }

        // GET api/Spareparts
        [HttpGet]
        public IQueryable<SparePart> SpareParts()
        {

            return (IQueryable<SparePart>)SparePartsRepo.GetData();
        }

        // GET api/Spareparts/5
        [ResponseType(typeof(SparePart))]
        [HttpGet]
        public async Task<IHttpActionResult> SparePart(SparePart SparePartID)
        {
            var item = sparepart.Find(SparePartID);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT api/Spareparts/5
        [HttpPut]
        public async Task<IHttpActionResult> SparePart(SparePart SparePartID, SparePart sparepart)
        {
            if (SparePartID == null || SparePartID.Equals(0))
            {

                return BadRequest();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SparePartsRepo.Insert(sparepart);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Spareparts
        [ResponseType(typeof(SparePart))]
        [HttpPost]
        public async Task<IHttpActionResult> SparePartUpdate(SparePart sparepart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SparePartsRepo.UpdateOne(sparepart);

            return CreatedAtRoute("DefaultApi", new { id = sparepart.SparePartID }, sparepart);
        }

        // DELETE api/Spareparts/5
        [ResponseType(typeof(SparePart))]
        [HttpDelete]
        public async Task<IHttpActionResult> SparePartDelete(Spareparts sparepart)
        {

            if (sparepart == null)
            {
                return NotFound();
            }

            SparePartsRepo.DeleteOne(sparepart);

            return Ok(sparepart);
        }


    }
}