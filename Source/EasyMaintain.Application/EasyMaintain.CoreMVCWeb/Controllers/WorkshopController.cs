using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;
using EasyMaintain.CoreWebMVC.DataEntities;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class WorkshopController : Controller
    {
        WorkshopModel workshopModel = SessionUtility.utilityWorkshopModel;

        // GET: /<controller>/
        public ActionResult Index()
        {
            workshopModel.Username = SessionUtility.utilityUserdataModel.Username;
            workshopModel.ID = SessionUtility.utilityUserdataModel.ID;
            workshopModel.Name = SessionUtility.utilityUserdataModel.Name;
            workshopModel.Email = SessionUtility.utilityUserdataModel.Email;
            workshopModel.PhoneNumber = SessionUtility.utilityUserdataModel.PhoneNumber;

            try
            {
                var uri = "api/Workshop/Get ";

                List<Workshop> workshopItems;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8961");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    workshopItems = JsonConvert.DeserializeObject<List<Workshop>>(response.Result);
                }
                workshopModel.Workshops = workshopItems;

            }
            catch (AggregateException e)
            {

            }




            workshopModel.token = SessionUtility.utilityToken;
            ClearSession();
            return View(workshopModel);
        }

        [HttpPost, Route("/Workshop/SaveNewWorkshop")]
        public PartialViewResult SaveNewWorkshop([FromBody] Workshop Model)
        {
            int finalIndex = (workshopModel.Workshops.Count) - 1;
            Model.WorkshopID = workshopModel.Workshops[finalIndex].WorkshopID + 1;
          //  workshopModel.Workshops.Add(Model);


            try
            {

                string workshopData = JsonConvert.SerializeObject(Model);

                this.PostAsync("http://localhost:8961/api/Workshop/", workshopData);
                workshopModel.Workshops.Add(Model);
            }
            catch (AggregateException e)
            {
            }

            return PartialView("_Workshop", workshopModel);

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

        [HttpPost, Route("/workshop/LoadWorkshop")]
        public PartialViewResult LoadWorkshop([FromBody]Workshop ID)
        {

            Workshop item = workshopModel.Workshops.Single(r => r.WorkshopID == ID.WorkshopID);

            workshopModel.WorkshopID = item.WorkshopID;
            workshopModel.WorkshopName = item.Name;
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
            workshopModel.WorkshopName = Model.Name;
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
            workshopModel.WorkshopName = null;
            workshopModel.Location = null;
            workshopModel.Address = null;
        }

    }
}
