using EasyMaintain.WebUI.Models;
using EasyMaintain.WebUI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMaintain.WebUI.Controllers
{
    public class SparePartsController : Controller
    {
        public SparePartsViewModel SparePartsViewModelSession 
        {
            get
            { 
                if(Session[SessionUtility.SparePartsModel] != null)
                {
                    return (SparePartsViewModel)Session[SessionUtility.SparePartsModel];
                }
                else
                {
                    SparePartsViewModel model = new SparePartsViewModel();
                    SparePartsViewModelSession = model;
                    return model;
                }
            }
            set
            {
                Session[SessionUtility.SparePartsModel] = value;
            }
        }

        public ActionResult Index()
        {
            return View(SparePartsViewModelSession);
        }

        //Get
        [HttpGet]
        public PartialViewResult SpareParts()
        {
            return PartialView("_SpareParts", SparePartsViewModelSession);
        }

        public PartialViewResult AddSparePart(SparePartsViewModel model)
        {
            //Update logic
            SparePartsViewModelSession.SpareParts.Add(new SparePart { SparePartID = 101, Name = model.Name, Description = model.Description });

            return PartialView("_SpareParts", SparePartsViewModelSession);
        }

        //Get
        [HttpGet]
        public PartialViewResult Categories()
        {
            return PartialView("_Categories");
        }

        //Post
        [HttpPost]
        public PartialViewResult AddCategory(CategoryViewModel model)
        {
            return PartialView("_Categories", model);
        }

        //Get
        [HttpGet]
        public PartialViewResult AircraftModels()
        {
            return PartialView("_AircraftModels");
        }

        //Post
        [HttpPost]
        public PartialViewResult AddAircraftModel(AircraftModelModel model)
        {
            return PartialView("_AircraftModels", model);
        }

        //Get
        [HttpGet]
        public PartialViewResult Manufactures()
        {
            return PartialView("_Manufactures");
        }

        //Post
        [HttpPost]
        public PartialViewResult AddManufacturer(ManufacturerViewModel model)
        {
            return PartialView("_Manufactures", model);
        }

        //Get
        [HttpGet]
        public PartialViewResult Suppliers()
        {
            SupplierViewModel vm = new SupplierViewModel();

            for (int i = 0; i < 5; i++)
            {
                vm.SuppliersList.Add(new Supplier()
                {
                    Name = "Supplier " + i,
                    AdditionalData = "Additional Data",
                    Address ="Address" +i,
                    ContactDetails = "Contact Details",
                    Description = "Description",
                    EmailAddress = "Email Address"                    
                });
            }

            return PartialView("_Suppliers", vm);
        }
    }
}
