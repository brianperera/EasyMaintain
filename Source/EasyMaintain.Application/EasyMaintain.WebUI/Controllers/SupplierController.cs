using EasyMaintain.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMaintain.WebUI.Controllers
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