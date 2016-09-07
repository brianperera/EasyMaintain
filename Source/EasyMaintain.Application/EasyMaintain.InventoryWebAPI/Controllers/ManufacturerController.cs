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
    public class ManufacturerController : ApiController
    {
        public IBusiness ManufacturerRepo { get; set; }
        public Manufacturer manufacturer;
        public ManufacturerController(IBusiness _repo)
        {

            ManufacturerRepo = _repo;
        }

        // GET api/Manufacturer
        [HttpGet]
        public IQueryable<Manufacturer> Manufacturers()
        {
            return (IQueryable<Manufacturer>)ManufacturerRepo.GetData();
        }

        // GET api/Manufacturer/5
        [ResponseType(typeof(Manufacturer))]
        [HttpGet]
        public async Task<IHttpActionResult> Manufacturer(Manufacturer ManufacturerID)
        {
            var item = manufacturer.Find(ManufacturerID);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT api/Manufacturer/5
        [HttpPut]
        public async Task<IHttpActionResult> Manufacturer(Manufacturer ManufacturerID, Manufacturer manufacturer)
        {

            if (manufacturer == null || ManufacturerID.Equals(0))
            {
               
                    return BadRequest();
                
            }
                if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ManufacturerRepo.Insert(manufacturer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Manufacturer
        [ResponseType(typeof(Manufacturer))]
        [HttpPost]
        public async Task<IHttpActionResult> ManufacturerUpdate(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ManufacturerRepo.UpdateOne(manufacturer);

            return CreatedAtRoute("DefaultApi", new { id = manufacturer.ManufacturerID }, manufacturer);
        }

        // DELETE api/Manufacturer/5
        [ResponseType(typeof(Manufacturer))]
        [HttpDelete]
        public async Task<IHttpActionResult> ManufacturerDelete(Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                return NotFound();
            }
            ManufacturerRepo.DeleteOne(manufacturer);
            return Ok(manufacturer);
        }
    }
}