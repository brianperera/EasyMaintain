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
    public class EngineController : ApiController
    {
        private EasyMaintainServicesContext db = new EasyMaintainServicesContext();

        // GET api/Engine
        [HttpGet]
        public IQueryable<EngineType> EngineTypes()
        {
            return db.EngineTypes;
        }

        // GET api/Engine/5
        [ResponseType(typeof(EngineType))]
        [HttpGet]
        public async Task<IHttpActionResult> EngineTypes(int id)
        {
            EngineType enginetype = await db.EngineTypes.FindAsync(id);
            if (enginetype == null)
            {
                return NotFound();
            }

            return Ok(enginetype);
        }

        // PUT api/Engine/5
        [HttpPut]
        public async Task<IHttpActionResult> EngineType(int id, EngineType enginetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enginetype.EngineTypeID)
            {
                return BadRequest();
            }

            db.Entry(enginetype).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineTypeExists(id))
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

        // POST api/Engine
        [ResponseType(typeof(EngineType))]
        [HttpPost]
        public async Task<IHttpActionResult> EngineType(EngineType enginetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EngineTypes.Add(enginetype);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = enginetype.EngineTypeID }, enginetype);
        }

        // DELETE api/Engine/5
        [ResponseType(typeof(EngineType))]
        [HttpDelete]
        public async Task<IHttpActionResult> EngineTypeDelete(int id)
        {
            EngineType enginetype = await db.EngineTypes.FindAsync(id);
            if (enginetype == null)
            {
                return NotFound();
            }

            db.EngineTypes.Remove(enginetype);
            await db.SaveChangesAsync();

            return Ok(enginetype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EngineTypeExists(int id)
        {
            return db.EngineTypes.Count(e => e.EngineTypeID == id) > 0;
        }
    }
}