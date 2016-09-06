using EasyMaintain.WebUI.Models;
using EasyMaintain.WebUI.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class ComponentWorkController : Controller
    {
        
 /*       
        public ComponentWorkModel ComponentWorkModelSession
        {
            get
            {
                if (Session[SessionUtility.ComponentWorkModel] != null)
                {
                    return (ComponentWorkModel)Session[SessionUtility.ComponentWorkModel];
                }
                else
                {
                    ComponentWorkModel model = new ComponentWorkModel();
                    ComponentWorkModelSession = model;
                    return model;
                }
            }
            set
            {
                Session[SessionUtility.ComponentWorkModel] = value;
            }
        }

        */


        // GET: ComponentWork
        public ActionResult Index()
        {
            var componentWorkModel = new ComponentWorkModel();
            return View(componentWorkModel);
        }

        [HttpGet]
        public PartialViewResult CreateWorkOrder(ComponentWorkModel model)
        {
            var componentWorkModel = new ComponentWorkModel();
            componentWorkModel.ComponentWorkOrders.Add(
                new ComponentWork {
                    WorkID = (componentWorkModel.ComponentWorkOrders.Count) + 1,
                    Component = model.ComponentName,
                    CreatedDate = model.CreatedDate,
                    Description = model.Description,
                    Location = model.WorkshopLocation,
                    SerialNumber = model.SerialNumber,
                    FlightNumber = model.FlightNumber
                });

            return PartialView("_Search", componentWorkModel);
        }

        [HttpPost]
        public PartialViewResult SaveEditWorkOrder(ComponentWorkModel model)
        {
            var componentWorkModel = new ComponentWorkModel();

            componentWorkModel.ComponentWorkOrders[0].Component = model.ComponentName;
            componentWorkModel.ComponentWorkOrders[0].Location = model.WorkshopLocation;
            componentWorkModel.ComponentWorkOrders[0].Description = model.Description;

            /* ComponentWorkModelSession.ComponentWorkOrders.Add(
                 new ComponentWork
                 {
                     WorkID = (ComponentWorkModelSession.ComponentWorkOrders.Count) + 1,
                     Component = model.ComponentName,
                     CreatedDate = model.CreatedDate,
                     Description = model.Description,
                     Location = model.WorkshopLocation,
                     SerialNumber = model.SerialNumber,
                     FlightNumber = model.FlightNumber
                 });*/

            return PartialView("_Search", componentWorkModel);
        }

        public PartialViewResult NewWorkOrder()
        {
            var componentWorkModel = new ComponentWorkModel();
            return PartialView("_NewWorkOrder", componentWorkModel);
        }

        public PartialViewResult Search()
        {
            var componentWorkModel = new ComponentWorkModel();
            return PartialView("_Search", componentWorkModel);
        }

       /* public PartialViewResult EditWorkOrder(int WorkID)
        {
            return PartialView("_EditWorkOrder", ComponentWorkModelSession);
        }*/

        public PartialViewResult EditWorkOrder(ComponentWorkModel model)
        {
            var componentWorkModel = new ComponentWorkModel();
            return PartialView("_EditWorkOrder", componentWorkModel);
        }
    }
}