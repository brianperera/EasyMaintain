using EasyMaintain.CoreWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyMaintain.CoreWebUI.Controllers
{
    public class EngineTypeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult EngineType()
        {
            return PartialView("EngineType");
        }

        //Post
        [HttpPost]
        public PartialViewResult EngineType(EngineTypeViewModel model)
        {
            //Update logic
            return PartialView("EngineType", model);
        }
    }
}