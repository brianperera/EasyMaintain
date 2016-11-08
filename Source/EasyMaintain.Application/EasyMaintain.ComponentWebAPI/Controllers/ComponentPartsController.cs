using EasyMaintain.Business;
using EasyMaintain.DTO;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;


namespace EasyMaintain.ComponentWebAPI.Controllers
{
   public class ComponentPartsController : ApiController
    {
        ComponentsLogic componentLogic = new ComponentsLogic();
        public ComponentPartsController()
        {
        }
        // GET api/ComponentParts
        [HttpGet]
        public IEnumerable<Component> Get()
        {
            return (IEnumerable<Component>)componentLogic.GetData();
        }
        // POST api/ComponentParts
        [HttpPost]
        public IHttpActionResult Post(Component component)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            componentLogic.Insert(component);
            return CreatedAtRoute("DefaultApi", new { id = component.ComponentID }, component);
        }
        // PUT api/ComponentParts/5 
        [HttpPut]
        public IHttpActionResult Put([FromBody]Component component)
        {
            if (component.Equals(0))
            {
                return BadRequest();
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            componentLogic.UpdateOne(component);
            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE api/ComponentParts/5 
        [HttpDelete]
        public void Delete([FromBody]Component id)
        {
            componentLogic.DeleteOne(id);
        }
    }
}
