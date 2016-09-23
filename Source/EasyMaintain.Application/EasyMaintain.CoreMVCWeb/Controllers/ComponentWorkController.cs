using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class ComponentWorkController : Controller
    {
        
        ComponentWorkModel componentWorkViewModel = SessionUtility.utilityComponentWorkModel;

        public ActionResult Index()
        {
            componentWorkViewModel = SessionUtility.utilityComponentWorkModel;
            return View(componentWorkViewModel);
        }

        [HttpPost, Route("ComponentWork/CreateWorkOrder")]
        public PartialViewResult CreateWorkOrder([FromBody] ComponentWork Model)
        {

            var uri = "api/Values/ComponentWorkCreate ";

            List<ComponentWork> componentWorkItems;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                componentWorkItems = JsonConvert.DeserializeObject<List<ComponentWork>>(response.Result);
            }
            componentWorkViewModel.ComponentWorkOrders = componentWorkItems;

            Model.Deliverydetailsmodel = new DeliveryDetailsModel();
            Model.WorkID = (componentWorkViewModel.ComponentWorkOrders.Count) + 1;
            componentWorkViewModel.ComponentWorkOrders.Add(Model);

            return PartialView("_Search", componentWorkViewModel);
        }

        [HttpPost, Route("ComponentWork/SaveWorkOrder")]
        //todo
        public PartialViewResult SaveWorkOrder([FromBody] ComponentWork Model)
        {
            Model.WorkID = componentWorkViewModel.WorkID;
            int index = componentWorkViewModel.WorkID - 1;
            componentWorkViewModel.ComponentWorkOrders[index] = Model;
            return PartialView("_Search", componentWorkViewModel);
        }

        public PartialViewResult NewWorkOrder()
        {
            return PartialView("_NewWorkOrder", componentWorkViewModel);
        }
        public PartialViewResult NewComponent()
        {
            return PartialView("_NewComponent", new ComponentModel());
        }

        public PartialViewResult Search()
        {

            var uri = "api/Values/ComponentWorkData ";

            List<ComponentWork> componentWorkItems;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                componentWorkItems = JsonConvert.DeserializeObject<List<ComponentWork>>(response.Result);
            }
            componentWorkViewModel.ComponentWorkOrders = componentWorkItems;
            return PartialView("_Search", componentWorkViewModel);
        }

        [HttpPost, Route("ComponentWork/ComponentWork/EditWorkOrder")]
        public PartialViewResult EditWorkOrder([FromBody]ComponentWork ID)
         {

            var uri = "api/Values/ComponentWorkInsert ";

            List<ComponentWork> componentWorkItems;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                componentWorkItems = JsonConvert.DeserializeObject<List<ComponentWork>>(response.Result);
            }
            componentWorkViewModel.ComponentWorkOrders = componentWorkItems;


            ComponentWork item = componentWorkViewModel.ComponentWorkOrders.Single(r => r.WorkID == ID.WorkID);

            componentWorkViewModel.WorkID = item.WorkID;
            componentWorkViewModel.Description = item.Description;
            componentWorkViewModel.FlightNumber = item.FlightNumber;
            componentWorkViewModel.WorkshopLocation = item.Location;
            componentWorkViewModel.CreatedDate = item.CreatedDate;
            componentWorkViewModel.SerialNumber = item.SerialNumber;
            componentWorkViewModel.ComponentName = item.Component;
            componentWorkViewModel.DeliveryDetails = item.Deliverydetails;

            return PartialView("_EditWorkOrder", componentWorkViewModel);

         }

    }
}