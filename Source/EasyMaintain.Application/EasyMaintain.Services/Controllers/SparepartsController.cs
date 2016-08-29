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
    public class SparepartsController : ApiController
    {
        private EasyMaintainServicesContext db = new EasyMaintainServicesContext();

        // GET api/Spareparts
        public IQueryable<SparePart> GetSpareParts()
        {
            var spareparts = from b in db.SpareParts
                             select new SparePart()
                             {

                                 SparePartID = b.SparePartID,
                                 Category = b.Category,
                                 SparePartName = b.SparePartName,
                                 Description = b.Description
                             };


            return db.SpareParts;
        }

        // GET api/Spareparts/5
        [ResponseType(typeof(SparePart))]
        public async Task<IHttpActionResult> GetSparePart(int id)
        {
            SparePart sparepart = await db.SpareParts.FindAsync(id);
            if (sparepart == null)
            {
                return NotFound();
            }

            return Ok(sparepart);
        }

        // PUT api/Spareparts/5
        public async Task<IHttpActionResult> PutSparePart(int id, SparePart sparepart)
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
        public async Task<IHttpActionResult> PostSparePart(SparePart sparepart)
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
        public async Task<IHttpActionResult> DeleteSparePart(int id)
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