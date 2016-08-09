using EasyMaintain.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMaintain.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult Category()
        {
            return PartialView("Category");
        }

        //Post
        [HttpPost]
        public PartialViewResult Category(CategoryViewModel model)
        {
            //Update logic
            return PartialView("Category", model);
        }
    }
}