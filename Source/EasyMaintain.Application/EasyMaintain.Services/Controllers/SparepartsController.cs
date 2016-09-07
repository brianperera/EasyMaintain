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

namespace EasyMaintain.Services.Controllers
{
    public class SparePartsController : ApiController
    {
        private EasyMaintainServicesContext db = new EasyMaintainServicesContext();

        // GET api/Spareparts
        [HttpGet]
        public IQueryable<SparePart> SpareParts()
        {

            return db.SpareParts;
        }

        // GET api/Spareparts/5
        [ResponseType(typeof(SparePart))]
        [HttpGet]
        public async Task<IHttpActionResult> SparePart(int id)
        {
            SparePart sparepart = await db.SpareParts.FindAsync(id);
            if (sparepart == null)
            {
                return NotFound();
            }

            return Ok(sparepart);
        }

        // PUT api/Spareparts/5
        [HttpPut]
        public async Task<IHttpActionResult> SparePart(int id, SparePart sparepart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sparepart.SparePartID)
            {
                return BadRequest();
            }

            db.Entry(sparepart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SparePartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Spareparts
        [ResponseType(typeof(SparePart))]
        [HttpPost]
        public async Task<IHttpActionResult> SparePart(SparePart sparepart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpareParts.Add(sparepart);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sparepart.SparePartID }, sparepart);
        }

        // DELETE api/Spareparts/5
        [ResponseType(typeof(SparePart))]
        [HttpDelete]
        public async Task<IHttpActionResult> SparePartDelete(int id)
        {
            SparePart sparepart = await db.SpareParts.FindAsync(id);
            if (sparepart == null)
            {
                return NotFound();
            }

            db.SpareParts.Remove(sparepart);
            await db.SaveChangesAsync();

            return Ok(sparepart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SparePartExists(int id)
        {
            return db.SpareParts.Count(e => e.SparePartID == id) > 0;
        }
    }
}