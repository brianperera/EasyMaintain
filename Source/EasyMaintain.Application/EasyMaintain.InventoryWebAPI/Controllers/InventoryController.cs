using System.Collections.Generic;
using System.Web.Http;
using EasyMaintain.Business;
using EasyMaintain.DTO;
using System.Net;

namespace EasyMaintain.InventoryWebAPI.Controllers
{
    public class InventoryController : ApiController
    {

        InventoryLogic inventoryLogic = new InventoryLogic();

        public InventoryController()
        {

        }

        // GET api/Inventory
        [HttpGet]
        public IEnumerable<Inventory> Get()
        {
            return (IEnumerable<Inventory>)inventoryLogic.GetData();
        }

        // GET api/Inventory/5 
        //[HttpGet]
        //public IHttpActionResult GetID(int id)
        //{
        //    var item = inventoryLogic.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(item);
        //}

        // POST api/Inventory
        [HttpPost]
        public IHttpActionResult Post(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            inventoryLogic.Insert(inventory);

            return CreatedAtRoute("DefaultApi", new { id = inventory.CustomerID }, inventory);
        }

        // PUT api/Inventory/5 
        [HttpPut]
        public IHttpActionResult Put(Inventory customerID, [FromBody]Inventory inventory)
        {
            if (customerID == null || customerID.Equals(0))
            {
                return BadRequest();
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            inventoryLogic.UpdateOne(inventory);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/Inventory/5 
        [HttpDelete]
        public void Delete(int id)
        {
            inventoryLogic.DeleteOne(id);
        }
    }
}
