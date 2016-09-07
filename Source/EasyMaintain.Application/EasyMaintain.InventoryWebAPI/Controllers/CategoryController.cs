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
    public class CategoryController : ApiController
    {

        public IBusiness CategoryRepo { get; set; }
        public Category category;
        public CategoryController(IBusiness _repo)
        {
            CategoryRepo = _repo;
        }

        // GET api/Category
        [HttpGet]
        public IQueryable<Category> Categories()
        {
            return (IQueryable<Category>)CategoryRepo.GetData();

        }

        // GET api/Category/5
        [ResponseType(typeof(Category))]
        [HttpGet]
        public async Task<IHttpActionResult> Category(Category CategoryID)
        {
            var item = category.Find(CategoryID);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT api/Category/5
        [HttpPut]
        public async Task<IHttpActionResult> Category(Category CategoryID, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Category
        [ResponseType(typeof(Category))]
        [HttpPost]
        public async Task<IHttpActionResult> CategoryInsert(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CategoryRepo.Insert(category);

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // DELETE api/Category/5
        [ResponseType(typeof(Category))]
        [HttpDelete]
        public async Task<IHttpActionResult> CategoryDelete(Category category)
        {

            if (category == null)
            {
                return NotFound();
            }

            CategoryRepo.DeleteOne(category);

            return Ok(category);
        }


    }
}