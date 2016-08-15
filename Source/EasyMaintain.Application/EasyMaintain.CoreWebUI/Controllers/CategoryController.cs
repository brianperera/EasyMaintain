using EasyMaintain.CoreWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyMaintain.CoreWebUI.Controllers
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