using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;
using EasyMaintain.CoreWebMVC.DataEntities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class WorkshopController : Controller
    {
        WorkshopModel workshopModel = SessionUtility.utilityWorkshopModel;

        // GET: /<controller>/
        public ActionResult Index()
        {
            ClearSession();
            return View(workshopModel);
        }

        [HttpPost, Route("/Workshop/SaveNewWorkshop")]
        public PartialViewResult SaveNewWorkshop([FromBody]Workshop Model)
        {
            int finalIndex = (workshopModel.Workshops.Count) - 1;
            Model.WorkshopID = workshopModel.Workshops[finalIndex].WorkshopID + 1;
            workshopModel.Workshops.Add(Model);

            return PartialView("_Workshop", workshopModel);

        }

        [HttpPost, Route("/workshop/LoadWorkshop")]
        public PartialViewResult LoadWorkshop([FromBody]Workshop ID)
        {

            Workshop item = workshopModel.Workshops.Single(r => r.WorkshopID == ID.WorkshopID);

            workshopModel.WorkshopID = item.WorkshopID;
            workshopModel.Name = item.Name;
            workshopModel.Location = item.Location;
            workshopModel.Address = item.Address;


            return PartialView("_Workshop", workshopModel);

        }

        [HttpPost, Route("/workshop/saveEditedWorkshop")]
        public PartialViewResult saveEditedWorkshop([FromBody]Workshop Model)
        {
            Model.WorkshopID = workshopModel.WorkshopID;
            int index = workshopModel.Workshops.FindIndex(r => r.WorkshopID == workshopModel.WorkshopID);
            workshopModel.Workshops[index] = Model;

            workshopModel.WorkshopID = Model.WorkshopID;
            workshopModel.Name = Model.Name;
            workshopModel.Location = Model.Location;
            workshopModel.Address = Model.Address;

            return PartialView("_Workshop", workshopModel);

        }


        [HttpPost, Route("/workshop/deleteWorkshop")]
        public PartialViewResult deleteWorkshop()
        {
            int deletingIndex = workshopModel.Workshops.FindIndex(r => r.WorkshopID == workshopModel.WorkshopID);

            for (int x = deletingIndex; x <= workshopModel.Workshops.Count - 2; x++)
            {
                int nextIndex = x + 1;
                workshopModel.Workshops[x] = workshopModel.Workshops[nextIndex];
            }

            int finalIndex = workshopModel.Workshops.Count - 1;
            workshopModel.Workshops.RemoveAt(finalIndex);

            ClearSession();

            return PartialView("_Workshop", workshopModel);


        }

        [HttpPost, Route("/workshop/cancel")]
        public PartialViewResult cancel()
        {
            ClearSession();

            return PartialView("_Workshop", workshopModel);

        }

        public void ClearSession()
        {
            workshopModel.WorkshopID = 0;
            workshopModel.Name = null;
            workshopModel.Location = null;
            workshopModel.Address = null;
        }

    }
}
