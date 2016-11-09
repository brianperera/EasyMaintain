using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;
using EasyMaintain.CoreWebMVC.DataEntities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http.Headers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class InventoryController : Controller
    {
        // GET: /<controller>/

        InventoryViewModel inventoryViewModel = SessionUtility.utilityInventoryViewModel;
        // GET: /<controller>/
        public ActionResult Index()
        {
            inventoryViewModel.Username = SessionUtility.utilityUserdataModel.Username;
            inventoryViewModel.ID = SessionUtility.utilityUserdataModel.ID;
            inventoryViewModel.Name = SessionUtility.utilityUserdataModel.Name;
            inventoryViewModel.Email = SessionUtility.utilityUserdataModel.Email;
            inventoryViewModel.PhoneNumber = SessionUtility.utilityUserdataModel.PhoneNumber;

            try
            {
                var uri = "api/Inventory/Get ";

                List<Inventory> inventoryItems;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionUtility.utilityToken.AccessToken);
                    httpClient.BaseAddress = new Uri("http://localhost:8103");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    inventoryItems = JsonConvert.DeserializeObject<List<Inventory>>(response.Result);
                }
                inventoryViewModel.InventoryOrders = inventoryItems;

            }
            catch (AggregateException e)
            {

            }

            //var maintenanceViewModel = new MaintenanceViewModel();
            //inventoryViewModel = SessionUtility.utilityInventoryViewModel;
            inventoryViewModel.token = SessionUtility.utilityToken;
            return View(inventoryViewModel);
        }

        [HttpPost, Route("/inventory/CreateOrder")]
        public PartialViewResult CreateOrder([FromBody]Inventory Model)
        {
            Model.PartsList = new List<string>();
            Model.PartsList.AddRange(inventoryViewModel.PartsList);
            Model.InvoiceNumber = (inventoryViewModel.InventoryOrders.Count) + 1;
            //Model.Deliverydetailsmodel = new DeliveryDetailsModel();
            //inventoryViewModel.InventoryOrders.Add(Model);

            try
            {

                string inventoryData = JsonConvert.SerializeObject(Model);

                this.PostAsync("http://localhost:8103/api/Inventory/", inventoryData);
                inventoryViewModel.InventoryOrders.Add(Model);
            }
            catch (AggregateException e)
            {
            }



            return PartialView("_ManageRequests", inventoryViewModel);

        }

        public void PostAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }

        [HttpPost, Route("/inventory/SaveEditedOrder")]
        public PartialViewResult SaveEditedOrder([FromBody]Inventory Model)
        {
            //int index = inventoryViewModel.InvoiceNumber - 1;
            Inventory item = inventoryViewModel.InventoryOrders.Single(r => r.CustomerID == inventoryViewModel.CustomerID);
            int index = inventoryViewModel.InventoryOrders.IndexOf(item);
            inventoryViewModel.InventoryOrders[index].AdditionalNotes = Model.AdditionalNotes;
            inventoryViewModel.InventoryOrders[index].Deliverydetails = Model.Deliverydetails;
            Model = inventoryViewModel.InventoryOrders[index];
            Model.CustomerID = inventoryViewModel.CustomerID;

            try
            {

                string inventoryData = JsonConvert.SerializeObject(Model);

                this.PutAsync("http://localhost:8103/api/Inventory/", inventoryData);
               // inventoryViewModel.InventoryOrders.Add(Model);
            }
            catch (AggregateException e)
            {
            }

            return PartialView("_ManageRequests", inventoryViewModel);

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



       [HttpPost, Route("/inventory/DeleteOrder")]
        public PartialViewResult DeleteOrder()
        {
            //int index = inventoryViewModel.InvoiceNumber - 1;
            Inventory item = inventoryViewModel.InventoryOrders.Single(r => r.CustomerID == inventoryViewModel.CustomerID);

            try
            {
                string inventoryData = JsonConvert.SerializeObject(item);
                this.DeleteAsync("http://localhost:8103/api/Inventory/", inventoryData);
              
            }
            catch (AggregateException e)
            {
            }

            inventoryViewModel.InventoryOrders.Remove(item);
            return PartialView("_ManageRequests", inventoryViewModel);

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

        [HttpPost, Route("/inventory/SaveTempData")]
        public void SaveTempData([FromBody] Inventory Model)
        {
            inventoryViewModel.CustomerName = Model.CustomerName;
            inventoryViewModel.CompanyName = Model.CompanyName;
            inventoryViewModel.AdditionalNotes = Model.AdditionalNotes;
            inventoryViewModel.PaymentMethod = Model.PaymentMethod;
            inventoryViewModel.BillingName = Model.BillingName;
            inventoryViewModel.BillingAddress = Model.BillingAddress;
            inventoryViewModel.PaymentNotes = Model.PaymentNotes;
            inventoryViewModel.Deliverydetails = Model.Deliverydetails;
            inventoryViewModel.Deliverydetailsmodel = new DeliveryDetailsModel();
        }

        [HttpPost, Route("/Inventory/AddPart")]
        public PartialViewResult AddPart([FromBody] SparePart Part)
        {
            //inventoryViewModel.PartsList.Add(Part.Name);
            //session.ActiveTab = SessionUtility.Frame_3;

            try
            {

                string sparePartData = JsonConvert.SerializeObject(Part);

                this.PostAsync("http://localhost:8103/api/Spareparts/", sparePartData);
                inventoryViewModel.PartsList.Add(Part.Name);
            }
            catch (AggregateException e)
            {
            }




            return PartialView("_NewOrder", inventoryViewModel);
        }

        [HttpDelete, Route("/Inventory/DeletePart")]
        public PartialViewResult DeletePart([FromBody]SparePart Part)
        {
            var itemToRemove = inventoryViewModel.PartsList.Single(r => r == Part.Name);
            //inventoryViewModel.PartsList.Remove(itemToRemove);


            //    using (HttpClient httpClient = new HttpClient())
            //    {
            //        httpClient.BaseAddress = new Uri("http://localhost:8103");
            //        Task<String> response = httpClient.GetStringAsync(uri);
            //        inventoryItems = JsonConvert.DeserializeObject<List<Inventory>>(response.Result);
            //    }
            //    inventoryViewModel.InventoryOrders = inventoryItems;

            //}
            //    catch (AggregateException e)
            //    {
            //    }

            string url = "api/Spareparts/delete";

            WebRequest request = WebRequest.Create(url);
            request.Method= "DELETE";
            inventoryViewModel.PartsList.Remove(itemToRemove);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //session.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewOrder", inventoryViewModel);
        }

        [HttpPost, Route("/Inventory/EditOrder")]
        public PartialViewResult EditOrder([FromBody]Inventory ID)
        {

            Inventory item = inventoryViewModel.InventoryOrders.Single(r => r.CustomerID == ID.CustomerID);

            inventoryViewModel.CustomerID = item.CustomerID;
            inventoryViewModel.InvoiceNumber = item.InvoiceNumber;
            inventoryViewModel.CustomerName = item.CustomerName;
            inventoryViewModel.CompanyName = item.CompanyName;
            inventoryViewModel.AdditionalNotes = item.AdditionalNotes;
            if (item.PartsList != null)
            {
                inventoryViewModel.PartsList = item.PartsList;
            }
            else
            {
                inventoryViewModel.PartsList = new List<string>();
            }

            inventoryViewModel.Deliverydetails = item.Deliverydetails;

            return PartialView("_EditOrder", inventoryViewModel);

        }

        public PartialViewResult Search()
        {
            return PartialView("_Search", inventoryViewModel);
        }

        public PartialViewResult ManageRequests()
        {
            try
            {
                var uri = "api/Inventory/Get ";

                List<Inventory> inventoryItems;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8103");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    inventoryItems = JsonConvert.DeserializeObject<List<Inventory>>(response.Result);
                }
                
                inventoryViewModel.InventoryOrders = inventoryItems;
                
            }
            catch (AggregateException e)
            {

            }

            sessionClear();
            return PartialView("_ManageRequests", inventoryViewModel);
        }

        public PartialViewResult NewOrder()
        {
            sessionClear();
            return PartialView("_NewOrder", inventoryViewModel);
        }

        public PartialViewResult NewRestockOrder()
        {
            return PartialView("_NewRestockOrder", inventoryViewModel);
        }

        public void sessionClear()
        {
            inventoryViewModel.CustomerName = null;
            inventoryViewModel.CompanyName = null;
            inventoryViewModel.AdditionalNotes = null;
            inventoryViewModel.BillingAddress = null;
            inventoryViewModel.BillingName = null;
            inventoryViewModel.PaymentMethod = null;
            inventoryViewModel.PaymentNotes = null;
            inventoryViewModel.ActiveTab = SessionUtility.Frame_1;
            inventoryViewModel.CustomerName = null;

            if (inventoryViewModel.PartsList != null) {
                inventoryViewModel.PartsList.Clear();
            }
        }

    }
}
