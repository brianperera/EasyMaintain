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
    public class AircraftModelController : ApiController
    {
        private EasyMaintainServicesContext db = new EasyMaintainServicesContext();

        // GET api/AircraftModel
        [HttpGet]
        public IQueryable<AircraftModel> GetAircraftModels()
        {
            return db.AircraftModels;
        }

        // GET api/AircraftModel/5
        [ResponseType(typeof(AircraftModel))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAircraftModel(int id)
        {
            AircraftModel aircraftmodel = await db.AircraftModels.FindAsync(id);
            if (aircraftmodel == null)
            {
                return NotFound();
            }

            return Ok(aircraftmodel);
        }

        // PUT api/AircraftModel/5
        [HttpPut]
        public async Task<IHttpActionResult> PutAircraftModel(int id, AircraftModel aircraftmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aircraftmodel.AircraftModelID)
            {
                return BadRequest();
            }

            db.Entry(aircraftmodel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftModelExists(id))
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

        // POST api/AircraftModel
        [ResponseType(typeof(AircraftModel))]
        [HttpPost]
        public async Task<IHttpActionResult> PostAircraftModel(AircraftModel aircraftmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AircraftModels.Add(aircraftmodel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aircraftmodel.AircraftModelID }, aircraftmodel);
        }

        // DELETE api/AircraftModel/5
        [ResponseType(typeof(AircraftModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAircraftModel(int id)
        {
            AircraftModel aircraftmodel = await db.AircraftModels.FindAsync(id);
            if (aircraftmodel == null)
            {
                return NotFound();
            }

            db.AircraftModels.Remove(aircraftmodel);
            await db.SaveChangesAsync();

            return Ok(aircraftmodel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AircraftModelExists(int id)
        {
            return db.AircraftModels.Count(e => e.AircraftModelID == id) > 0;
        }
    }
}