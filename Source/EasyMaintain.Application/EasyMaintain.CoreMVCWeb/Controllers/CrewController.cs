using System;
using System.Collections.Generic;
using System.Linq;
using EasyMaintain.CoreWebMVC.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Utility;
using EasyMaintain.CoreWebMVC.DataEntities;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreMVCWeb.Controllers
{
    public class CrewController : Controller
    {
        CrewViewModel CrewViewModel = SessionUtility.utilityCrewViewModel;

        // GET: /<controller>/
        public ActionResult Index()
        {
           CrewViewModel.Username = SessionUtility.utilityUserdataModel.Username;
           CrewViewModel.ID = SessionUtility.utilityUserdataModel.ID;
           CrewViewModel.Name = SessionUtility.utilityUserdataModel.Name;
            CrewViewModel.Email = SessionUtility.utilityUserdataModel.Email;
            CrewViewModel.PhoneNumber = SessionUtility.utilityUserdataModel.PhoneNumber;
            try
            {
                var uri = "api/Crew/Get ";

                List<Crew> crewItems;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8961");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    crewItems = JsonConvert.DeserializeObject<List<Crew>>(response.Result);
                }
                CrewViewModel.CrewList = crewItems;

            }
            catch (AggregateException e)
            {

            }
            CrewViewModel.token = SessionUtility.utilityToken;
            ClearSession();
            return View(CrewViewModel);
        }

        [HttpPost, Route("/Crew/createNewMember")]
        public PartialViewResult createNewMember([FromBody]Crew Model)
        {
            int finalIndex = (CrewViewModel.CrewList.Count) - 1;
            Model.CrewID = CrewViewModel.CrewList[finalIndex].CrewID + 1;
            try
            {
                string crewData = JsonConvert.SerializeObject(Model);

                this.PostAsync("http://localhost:8961/api/Crew/", crewData);
                CrewViewModel.CrewList.Add(Model);
            }
            catch (AggregateException e)
            {
            }
            return PartialView("_CrewModel", CrewViewModel);
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

        [HttpPost, Route("/Crew/saveEditedMember")]
        public PartialViewResult saveEditedMember([FromBody]Crew Model)
        {
            Model.CrewID = CrewViewModel.CrewID;
            CrewViewModel.CrewList[CrewViewModel.currentIndex] = Model;
            ClearSession();
            try
            {
                string maintenanceData = JsonConvert.SerializeObject(Model);
                this.PutAsync("http://localhost:8961/api/Crew/", maintenanceData);
            }
            catch (AggregateException e)
            {
            }
            return PartialView("_CrewModel", CrewViewModel);
        }
        public void PutAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "Put";
            request.ContentType = "application/json";
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
        [HttpPost, Route("/Crew/deleteMember")]
        public PartialViewResult deleteMember()
        {
            int index = CrewViewModel.CrewID - 1;
            Crew item = CrewViewModel.CrewList.Single(r => r.CrewID == CrewViewModel.CrewID);
            CrewViewModel.CrewList.Remove(item);           
            ClearSession();
            try
            {
                string crewData = JsonConvert.SerializeObject(item);
                this.DeleteAsync("http://localhost:8961/api/Crew/", crewData);
            }
            catch (AggregateException e)
            {
            }
            return PartialView("_CrewModel", CrewViewModel);
        }
        public void DeleteAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "Delete";  
            request.ContentType = "application/json";
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
        [HttpPost, Route("/Crew/EditMember")]
        public PartialViewResult EditMember([FromBody]Crew ID)
        {
            Crew item= CrewViewModel.CrewList.Single(r => r.CrewID == ID.CrewID);
            CrewViewModel.CrewID = item.CrewID;
            CrewViewModel.CrewName = item.Name;
            CrewViewModel.Designation = item.Designation;

            return PartialView("_CrewModel", CrewViewModel);
        }
        [HttpPost, Route("/Crew/cancel")]
        public PartialViewResult cancel()
        {
            ClearSession();
            return PartialView("_CrewModel", CrewViewModel);
        }
        public void ClearSession()
        {
            CrewViewModel.CrewID = 0;
            CrewViewModel.CrewName = null;
            CrewViewModel.Designation = null;
        }
    }
}
