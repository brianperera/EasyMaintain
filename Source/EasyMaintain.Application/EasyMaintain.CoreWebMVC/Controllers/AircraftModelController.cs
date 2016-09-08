using EasyMaintain.CoreWebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class AircraftModelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult AircraftModel()
        {
            return PartialView("AircraftModel");
        }

        //Post
        [HttpPost]
        public PartialViewResult AircraftModel(AircraftModelModel model)
        {
            //Update logic
            return PartialView("AircraftModel", model);
        }
    }
}