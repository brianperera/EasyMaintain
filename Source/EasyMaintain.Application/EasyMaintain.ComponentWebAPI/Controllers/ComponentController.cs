﻿using EasyMaintain.Business;
using EasyMaintain.DTO;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace EasyMaintain.ComponentWebAPI.Controllers
{
    public class ComponentController : ApiController
    {
       
       ComponentWorkLogic componentWorkLogic = new ComponentWorkLogic();

        public ComponentController()
        {

        }


        // GET api/Component
        [Authorize]
        [HttpGet]
        public IEnumerable<ComponentWork> Get()
        {
            return (IEnumerable<ComponentWork>)componentWorkLogic.GetData();
        }

        // POST api/Component
        [HttpPost]
        public IHttpActionResult Post(ComponentWork componentWork)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            componentWorkLogic.Insert(componentWork);
            return CreatedAtRoute("DefaultApi", new { id = componentWork.WorkID }, componentWork);

        }

        // PUT api/Component/5 
        [HttpPut]
        public IHttpActionResult Put(ComponentWork workID, [FromBody]ComponentWork component)
        {
            if (workID == null || workID.Equals(0))
            {
                return BadRequest();
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            componentWorkLogic.UpdateOne(component);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/Component/5 
        [HttpDelete]
        public void Delete(int id)
        {
            componentWorkLogic.DeleteOne(id);
        }
    }
}
