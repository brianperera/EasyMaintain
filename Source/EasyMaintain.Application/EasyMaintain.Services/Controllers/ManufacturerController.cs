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
    public class ManufacturerController : ApiController
    {
        private EasyMaintainServicesContext db = new EasyMaintainServicesContext();

        // GET api/Manufacturer
        [HttpGet]
        public IQueryable<Manufacturer> GetManufacturers()
        {
            return db.Manufacturers;
        }

        // GET api/Manufacturer/5
        [ResponseType(typeof(Manufacturer))]
        [HttpGet]
        public async Task<IHttpActionResult> GetManufacturer(int id)
        {
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        // PUT api/Manufacturer/5
        [HttpPut]
        public async Task<IHttpActionResult> PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturer.ManufacturerID)
            {
                return BadRequest();
            }

            db.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
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

        // POST api/Manufacturer
        [ResponseType(typeof(Manufacturer))]
        [HttpPost]
        public async Task<IHttpActionResult> PostManufacturer(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Manufacturers.Add(manufacturer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = manufacturer.ManufacturerID }, manufacturer);
        }

        // DELETE api/Manufacturer/5
        [ResponseType(typeof(Manufacturer))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            db.Manufacturers.Remove(manufacturer);
            await db.SaveChangesAsync();

            return Ok(manufacturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManufacturerExists(int id)
        {
            return db.Manufacturers.Count(e => e.ManufacturerID == id) > 0;
        }
    }
}