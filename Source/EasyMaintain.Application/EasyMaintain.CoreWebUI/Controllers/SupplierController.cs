using EasyMaintain.CoreWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyMaintain.CoreWebUI.Controllers
{
    public class SupplierController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult Supplier()
        {
            return PartialView("Supplier");
        }

        //Post
        [HttpPost]
        public PartialViewResult Supplier(SupplierViewModel model)
        {
            //Update logic
            return PartialView("Supplier", model);
        }
    }
}