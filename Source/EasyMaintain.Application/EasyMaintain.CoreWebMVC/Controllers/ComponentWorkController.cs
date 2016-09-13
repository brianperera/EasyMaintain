using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class ComponentWorkController : Controller
    {
        
        ComponentWorkModel session = SessionUtility.utilityComponentWorkModel;

        public ActionResult Index()
        {
            session = SessionUtility.utilityComponentWorkModel;
            return View(session);
        }

        [HttpPost, Route("ComponentWork/CreateWorkOrder")]
        public PartialViewResult CreateWorkOrder([FromBody] ComponentWork Model)
        {
            Model.Deliverydetailsmodel = new DeliveryDetailsModel();
            Model.WorkID = (session.ComponentWorkOrders.Count) + 1;
            session.ComponentWorkOrders.Add(Model);

            return PartialView("_Search", session);
        }

        [HttpPost, Route("ComponentWork/SaveWorkOrder")]
        public PartialViewResult SaveWorkOrder([FromBody] ComponentWork Model)
        {
            Model.WorkID = session.WorkID;
            int index = session.WorkID - 1;
            session.ComponentWorkOrders[index] = Model;
            return PartialView("_Search", session);
        }

        public PartialViewResult NewWorkOrder()
        {
            return PartialView("_NewWorkOrder", session);
        }

        public PartialViewResult Search()
        {
            return PartialView("_Search", session);
        }

        [HttpPost, Route("ComponentWork/ComponentWork/EditWorkOrder")]
        public PartialViewResult EditWorkOrder([FromBody]ComponentWork ID)
         {

             ComponentWork item = session.ComponentWorkOrders.Single(r => r.WorkID == ID.WorkID);

             session.WorkID = item.WorkID;
             session.Description = item.Description;
             session.FlightNumber = item.FlightNumber;
             session.WorkshopLocation = item.Location;
             session.CreatedDate = item.CreatedDate;
             session.SerialNumber = item.SerialNumber;
             session.ComponentName = item.Component;
             session.DeliveryDetails = item.Deliverydetails;

            return PartialView("_EditWorkOrder", session);

         }

    }
}