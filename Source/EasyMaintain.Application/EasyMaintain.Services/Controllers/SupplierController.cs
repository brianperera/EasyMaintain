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
    public class SupplierController : ApiController
    {
        
        private Supplier supplier;
        public IBusiness SupplierRepo { get; set; }
        public SupplierController(IBusiness _repo)
        {
            SupplierRepo = _repo;
        }

        
        // GET api/Supplier
        [HttpGet]
        public List<Supplier> Suppliers()
        {
            return (List<Supplier>)this.supplier.GetData();
        }

        // GET api/Supplier/5
        [ResponseType(typeof(Supplier))]

        [HttpGet]
        public async Task<IHttpActionResult> Suppliers(Supplier SupplierID)
        {

            //var item = SupplierRepo.Find(SupplierID);
            var item = supplier.Find(SupplierID);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // TODOO
        // PUT api/Supplier/5
        [HttpPut]
        //public async Task<IHttpActionResult> Supplier(Supplier SupplierID, Supplier supplier) //TODO: use the supplier object ID
        //{
        //    //validation
           
        //    if (SupplierID == null || SupplierID.Equals(0))
        //    {
        //        return BadRequest();
        //    }


        //    else
        //        if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //}

        // POST api/Supplier
        [ResponseType(typeof(Supplier))]
        [HttpPost]
        public async Task<IHttpActionResult> Supplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            SupplierRepo.Insert(supplier);

            return CreatedAtRoute("DefaultApi", new { id = supplier.SupplierID }, supplier);
        }

        // DELETE api/Supplier/5
        [ResponseType(typeof(Supplier))]
        [HttpDelete]
        public async Task<IHttpActionResult> SupplierDelete(Supplier SupplierID)
        {

            if (supplier == null)
            {
                return NotFound();
            }

            SupplierRepo.DeleteOne(supplier);

            return Ok(supplier);
        }
    }
}