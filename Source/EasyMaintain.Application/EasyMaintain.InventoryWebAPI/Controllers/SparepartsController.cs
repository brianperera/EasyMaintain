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
using EasyMaintain.DTO;
using EasyMaintain.Business;

namespace EasyMaintain.InventoryWebAPI.Controllers
{
    public class SparePartsController : ApiController
    {
        SparePartLogic sparePartLogic = new SparePartLogic();

        public SparePartsController()
        {

        }
        // GET api/Spareparts
        [HttpGet]
        public IEnumerable<SparePart> Get()
        {

            return (IEnumerable<SparePart>)sparePartLogic.GetData();
        }

        // GET api/Spareparts/5
        //[HttpGet]
        //public IHttpActionResult GetID(int id)
        //{
        //    var item = sparePartLogic.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(item);
        //}

        // PUT api/Spareparts/5
        [HttpPut]
        public IHttpActionResult Put(SparePart sparePartID, [FromBody]SparePart sparePart)
        {
            if (sparePartID == null || sparePartID.Equals(0))
            {
                return BadRequest();
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            sparePartLogic.UpdateOne(sparePart);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Spareparts
        [HttpPost]
        public IHttpActionResult Post(SparePart sparePart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            sparePartLogic.Insert(sparePart);

            return CreatedAtRoute("DefaultApi", new { id = sparePart.SparePartID }, sparePart);
        }


        // DELETE api/Spareparts/5
        [HttpDelete]
        public void Delete(int id)
        {
            sparePartLogic.DeleteOne(id);
        }


    }
}