using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EasyMaintain.CoreWebMVC.DataEntities;

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class AircraftModelController : Controller
    {
        AircraftModelModel AircraftModelModel = SessionUtility.utilityAircraftModelModel;
        public ActionResult Index()
        {
            AircraftModelModel = SessionUtility.utilityAircraftModelModel;
            ClearSession();
            return View(AircraftModelModel);
        }

        [HttpPost, Route("/AircraftModel/SaveNewAircraft")]
        public PartialViewResult SaveNewAircraft([FromBody]AircraftModel Model)
        {
            int finalIndex = (AircraftModelModel.AircrafModels.Count) - 1;
            Model.AircraftModelID = AircraftModelModel.AircrafModels[finalIndex].AircraftModelID + 1;
            AircraftModelModel.AircrafModels.Add(Model);

            return PartialView("_AircraftModel", AircraftModelModel);

        }

        [HttpPost, Route("/AircraftModel/saveEditedAircraft")]
        public PartialViewResult saveEditedAircraft([FromBody]AircraftModel Model)
        {
            Model.AircraftModelID = AircraftModelModel.AircraftModelID;
            int index = AircraftModelModel.AircraftModelID - 1;
            AircraftModelModel.AircrafModels[index] = Model;

            AircraftModelModel.AircraftModelID = Model.AircraftModelID;
            AircraftModelModel.Name = Model.ModelName;
            AircraftModelModel.Manufacturer = Model.Manufacturer;
            AircraftModelModel.EngineType = Model.EngineType;
            AircraftModelModel.Description = Model.Description;
            AircraftModelModel.AdditionalData = Model.AdditionalData;
            AircraftModelModel.ImagePath = Model.ImagePath;
            AircraftModelModel.Category = Model.Category;

            return PartialView("_AircraftModel", AircraftModelModel);

        }

        [HttpPost, Route("/AircraftModel/EditAircraft")]
        public PartialViewResult EditAircraft([FromBody]AircraftModel ID)
        {

            AircraftModel item = AircraftModelModel.AircrafModels.Single(r => r.AircraftModelID == ID.AircraftModelID);

            AircraftModelModel.AircraftModelID = item.AircraftModelID;
            AircraftModelModel.Name = item.ModelName;
            AircraftModelModel.Manufacturer = item.Manufacturer;
            AircraftModelModel.EngineType = item.EngineType;
            AircraftModelModel.Description = item.Description;
            AircraftModelModel.AdditionalData = item.AdditionalData;
            AircraftModelModel.ImagePath = item.ImagePath;
            AircraftModelModel.Category = item.Category;

            return PartialView("_AircraftModel", AircraftModelModel);

        }

        [HttpPost, Route("/AircraftModel/deleteAircraft")]
        public PartialViewResult deleteAircraft()
        {
            int deletingIndex = AircraftModelModel.AircraftModelID - 1;

            for(int x = deletingIndex; x <= AircraftModelModel.AircrafModels.Count - 2; x++)
            {
                int nextIndex = x + 1;
                AircraftModelModel.AircrafModels[x] = AircraftModelModel.AircrafModels[nextIndex];
            }

            int finalIndex = AircraftModelModel.AircrafModels.Count - 1;
            AircraftModelModel.AircrafModels.RemoveAt(finalIndex);

            ClearSession();

            return PartialView("_AircraftModel", AircraftModelModel);

        }

        [HttpPost, Route("/AircraftModel/cancel")]
        public PartialViewResult cancel()
        {
            ClearSession();

            return PartialView("_AircraftModel", AircraftModelModel);

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

        public void ClearSession()
        {
            AircraftModelModel.AircraftModelID = 0;
            AircraftModelModel.Name = null;
            AircraftModelModel.Manufacturer = null;
            AircraftModelModel.EngineType = null;
            AircraftModelModel.Description = null;
            AircraftModelModel.AdditionalData = null;
            AircraftModelModel.ImagePath = null;
            AircraftModelModel.Category = null;
        }

    }
}