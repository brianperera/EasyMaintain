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

        [HttpGet]
        public PartialViewResult CreateWorkOrder(ComponentWorkModel model)
        {
            /*session.ComponentWorkOrders.Add(
                new ComponentWork {
                    WorkID = (session.ComponentWorkOrders.Count) + 1,
                    Component = model.ComponentName,
                    CreatedDate = model.CreatedDate,
                    Description = model.Description,
                    Location = model.WorkshopLocation,
                    SerialNumber = model.SerialNumber,
                    FlightNumber = model.FlightNumber
                });*/

            return PartialView("_Search", session);
        }

        [HttpPost]
        public PartialViewResult SaveEditWorkOrder(ComponentWorkModel model)
        {
            session.ComponentWorkOrders[0].Component = model.ComponentName;
            session.ComponentWorkOrders[0].Location = model.WorkshopLocation;
            session.ComponentWorkOrders[0].Description = model.Description;
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

         public PartialViewResult EditWorkOrder(string WorkID)
         {

             ComponentWork item = session.ComponentWorkOrders.Single(r => r.WorkID == Int32.Parse(WorkID));

             session.WorkID = item.WorkID;
             session.Description = item.Description;
             session.FlightNumber = item.FlightNumber;
             session.WorkshopLocation = item.Location;
             session.CreatedDate = item.CreatedDate;
             session.SerialNumber = item.SerialNumber;
             session.ComponentName = item.Component;
             session.Deliverydetails = item.Deliverydetails;

            return PartialView("_EditWorkOrder", session);

         }

        public PartialViewResult EditWorkOrder(ComponentWorkModel model)
        {
            return PartialView("_EditWorkOrder", session);
        }
    }
}