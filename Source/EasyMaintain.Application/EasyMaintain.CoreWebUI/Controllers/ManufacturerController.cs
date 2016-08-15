using EasyMaintain.CoreWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyMaintain.CoreWebUI.Controllers
{
    public class ManufacturerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult Manufacturer()
        {
            return PartialView("Manufacturer");
        }

        //Post
        [HttpPost]
        public PartialViewResult Manufacturer(ManufacturerViewModel model)
        {
            //Update logic
            return PartialView("Manufacturer", model);
        }
    }
}