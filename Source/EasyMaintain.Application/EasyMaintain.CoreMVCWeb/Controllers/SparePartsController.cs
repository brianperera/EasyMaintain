using EasyMaintain.CoreWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class SparePartsController : Controller
    {
        public IActionResult Index()
        {
            var sparePartsViewModel = new SparePartsViewModel();
            return View(sparePartsViewModel);
        }

        //Get
        [HttpGet]
        public PartialViewResult SpareParts()
        {
            var sparePartsViewModel = new SparePartsViewModel();

            return PartialView("_SpareParts", sparePartsViewModel);
        }

        public ViewResult AddSparePart(SparePartsViewModel model)
        {
            var sparePartsViewModel = new SparePartsViewModel();

            //Update logic
            sparePartsViewModel.SpareParts.Add(new SparePart { SparePartID = 101, Name = model.Name, Description = model.Description });

            return View("Index", sparePartsViewModel);
        }

        
        [HttpGet]
        public PartialViewResult check(string componentName)
        {
            var sparePartsViewModel = new SparePartsViewModel();

            //Update logic
            sparePartsViewModel.SpareParts.Add(new SparePart { SparePartID = 22, Name = componentName, Description = "" });

            return PartialView("_SpareParts", sparePartsViewModel);
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
            return PartialView("_AircraftModels",new AircraftModelModel());
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
