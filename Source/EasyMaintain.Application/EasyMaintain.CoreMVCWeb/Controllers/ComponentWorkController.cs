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
using EasyMaintain.CoreWebMVC.DataEntities;
using System.Net;
using System.IO;
using System.Net.Http.Headers;

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class ComponentWorkController : Controller
    {

        ComponentWorkModel componentWorkViewModel = SessionUtility.utilityComponentWorkModel;
        ComponentModel componentModel = SessionUtility.utilityComponentModel;

        public ActionResult Index()
        {
            componentWorkViewModel.Username = SessionUtility.utilityUserdataModel.Username;
            componentWorkViewModel.ID = SessionUtility.utilityUserdataModel.ID;
            componentWorkViewModel.Name = SessionUtility.utilityUserdataModel.Name;
            componentWorkViewModel.Email = SessionUtility.utilityUserdataModel.Email;
            componentWorkViewModel.PhoneNumber = SessionUtility.utilityUserdataModel.PhoneNumber;
            try
            {
                var uri = "api/Component/Get ";

                List<ComponentWork> componentWorkItems;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionUtility.utilityToken.AccessToken);
                    httpClient.BaseAddress = new Uri("http://localhost:8425");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    componentWorkItems = JsonConvert.DeserializeObject<List<ComponentWork>>(response.Result);
                }
                componentWorkViewModel.ComponentWorkOrders = componentWorkItems;

            }
            catch (AggregateException e)
            {

            }

            //componentWorkViewModel.ComponentWorkOrders[0].Deliverydetails = new DeliveryDetails();
            //componentWorkViewModel.ComponentWorkOrders[1].Deliverydetails = new DeliveryDetails();
            componentWorkViewModel = SessionUtility.utilityComponentWorkModel;
            ClearSession();
            UpdateComponentWorkViewModel();
            return View(componentWorkViewModel);
        }

        [HttpPost, Route("ComponentWork/CreateWorkOrder")]
        public PartialViewResult CreateWorkOrder([FromBody] ComponentWork Model)
        {
            Model.WorkID = (componentWorkViewModel.ComponentWorkOrders.Count) + 1;
            Model.Deliverydetails.DeliveryDetailsId = (componentWorkViewModel.ComponentWorkOrders.Count) + 1;
            //componentWorkViewModel.ComponentWorkOrders.Add(Model);
           
            return PartialView("_Search", componentWorkViewModel);
        }

        public void PostAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            //model.PostData = "Test";
            request.ContentType = "application/json";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }

        [HttpPost, Route("ComponentWork/SaveWorkOrder")]
        //todo
        public PartialViewResult SaveWorkOrder([FromBody] ComponentWork Model)
        {
            Model.WorkID = componentWorkViewModel.WorkID;
            ComponentWork item = componentWorkViewModel.ComponentWorkOrders.Single(r => r.WorkID == Model.WorkID);
            int index = componentWorkViewModel.ComponentWorkOrders.IndexOf(item);
            componentWorkViewModel.ComponentWorkOrders[index] = Model;

            try
            {
                string componentData = JsonConvert.SerializeObject(Model);
                this.PutAsync("http://localhost:8425/api/Component/", componentData);
                componentWorkViewModel.ComponentWorkOrders.Add(Model);
            }
            catch (AggregateException e)
            {
            }
            return PartialView("_Search", componentWorkViewModel);
        }

        [HttpPost, Route("ComponentWork/DeleteWorkOrder")]
        public PartialViewResult DeleteWorkOrder()
        {
            int index = componentWorkViewModel.WorkID - 1;
            ComponentWork item = componentWorkViewModel.ComponentWorkOrders.Single(r => r.WorkID == componentWorkViewModel.WorkID);
            componentWorkViewModel.ComponentWorkOrders.Remove(item);

            try
            {
                string componentData = JsonConvert.SerializeObject(item);
                this.DeleteAsync("http://localhost:8425/api/Component/", componentData);
                //componentWorkViewModel.ComponentWorkOrders.Add(item);
            }
            catch (AggregateException e)
            {
            }

            componentWorkViewModel.ComponentWorkOrders.Remove(item);
            return PartialView("_Search", componentWorkViewModel);
        }


        public PartialViewResult Search()
        {
            return PartialView("_Search", componentWorkViewModel);
        }

        [HttpPost, Route("ComponentWork/ComponentWork/EditWorkOrder")]
        public PartialViewResult EditWorkOrder([FromBody]ComponentWork ID)
        {
            ComponentWork item = componentWorkViewModel.ComponentWorkOrders.Single(r => r.WorkID == ID.WorkID);
            //try
            //{
            //    string componentData = JsonConvert.SerializeObject(ID);
            //    this.PutAsync("http://localhost:8425/api/Component ", componentData);
            //   // componentWorkViewModel.ComponentWorkOrders.Add(ID);
            //}
            //catch (AggregateException e)
            //{
            //}
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



        public void PutAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "PUT";
            //model.PostData = "Test";
            request.ContentType = "application/json";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }

        [HttpPost, Route("/ComponentWork/SaveNewComponent")]
        public PartialViewResult SaveNewComponent([FromBody]Component Model)
        {
            int finalIndex = componentModel.Components.Count - 1;
            if (finalIndex < 0)
            {
                Model.ComponentID = 1;
            }
            else {
                Model.ComponentID = componentModel.Components[finalIndex].ComponentID + 1;
            }

            try
            {

                string componentData = JsonConvert.SerializeObject(Model);

                this.PostAsync("http://localhost:8425/api/ComponentParts/", componentData);
                componentModel.Components.Add(Model);
            }
            catch (AggregateException e)
            {
            }

            return PartialView("_NewComponent", componentModel);

        }



       

        [HttpPost, Route("/componentwork/EditComponent")]
        public PartialViewResult EditComponent([FromBody]Component ID)
        {

            Component item = componentModel.Components.Single(r => r.ComponentID == ID.ComponentID);

            componentModel.ComponentID = item.ComponentID;
            componentModel.Name = item.ComponentName;
            componentModel.Manufacturer = item.Manufacturer;
            componentModel.Description = item.Description;
            componentModel.AdditionalData = item.AdditionalData;
            componentModel.ImagePath = item.ImagePath;
            componentModel.Category = item.Category;

            return PartialView("_NewComponent", componentModel);

        }

        [HttpPost, Route("/componentwork/SaveEditedComponent")]
        public PartialViewResult SaveEditedComponent([FromBody]Component Model)
        {
            Model.ComponentID = componentModel.ComponentID;
            int index = componentModel.Components.FindIndex(r => r.ComponentID == componentModel.ComponentID);
            componentModel.Components[index] = Model;

            componentModel.ComponentID = Model.ComponentID;
            componentModel.Name = Model.ComponentName;
            componentModel.Manufacturer = Model.Manufacturer;
            componentModel.Description = Model.Description;
            componentModel.AdditionalData = Model.AdditionalData;
            componentModel.ImagePath = Model.ImagePath;
            componentModel.Category = Model.Category;


            try
            {
                string componentData = JsonConvert.SerializeObject(Model);
                this.PutAsync("http://localhost:8425/api/ComponentParts/", componentData);

            }
            catch (AggregateException e)
            {
            }

            return PartialView("_NewComponent", componentModel);

        }

        [HttpPost, Route("/componentwork/deleteComponent")]
        public PartialViewResult deleteComponent()
        {


            //Model.ComponentID = componentModel.ComponentID;
            //int index = componentModel.ComponentID - 1;
            //Component test = componentModel.Components.Single(r => r.ComponentID == Model.ComponentID);
            //componentModel.Components.Remove(test);

            int deletingIndex = componentModel.Components.FindIndex(r => r.ComponentID == componentModel.ComponentID);

            for (int x = deletingIndex; x <= componentModel.Components.Count - 2; x++)
            {
                int nextIndex = x + 1;
                componentModel.Components[x] = componentModel.Components[nextIndex];
            }

            int finalIndex = componentModel.Components.Count - 1;
            componentModel.Components.RemoveAt(finalIndex);

            ClearSession();


            try
            {
                string componenetData = JsonConvert.SerializeObject(finalIndex);
                this.DeleteAsync("http://localhost:8425/api/ComponentParts/", componenetData);

            }
            catch (AggregateException e)
            {
            }

            return PartialView("_NewComponent", componentModel);

        }

        public void DeleteAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "Delete";
            //model.PostData = "Test";
            request.ContentType = "application/json";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }


        [HttpPost, Route("/componentwork/cancel")]
        public PartialViewResult cancel()
        {
            ClearSession();

            return PartialView("_NewComponent", componentModel);

        }

        public PartialViewResult NewWorkOrder()
        {
            return PartialView("_NewWorkOrder", componentWorkViewModel);
        }
        public PartialViewResult NewComponent()
        {
            return PartialView("_NewComponent", new ComponentModel());
        }

        public void ClearSession()
        {
            componentModel.ComponentID = 0;
            componentModel.Name = null;
            componentModel.Manufacturer = null;
            componentModel.Description = null;
            componentModel.AdditionalData = null;
            componentModel.ImagePath = null;
            componentModel.Category = null;
        }

        public void UpdateComponentWorkViewModel()
        {
            componentWorkViewModel.Components = SessionUtility.utilityComponentModel;
            componentWorkViewModel.Workshops = SessionUtility.utilityWorkshopModel;
            componentWorkViewModel.token = SessionUtility.utilityToken;
        }
    }
}