using EasyMaintain.CoreWebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyMaintain.CoreWebMVC.Controllers
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
            return PartialView("_Categories");
        }

        //Post
        [HttpPost]
        public PartialViewResult Category(CategoryViewModel model)
        {
            //Update logic
            return PartialView("_Categories", model);
        }
    }
}