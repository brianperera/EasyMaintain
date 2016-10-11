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

            ClearSession();
            return View(CrewViewModel);
        }

        [HttpPost, Route("/Crew/createNewMember")]
        public PartialViewResult createNewMember([FromBody]Crew Model)
        {
            int finalIndex = (CrewViewModel.CrewList.Count) - 1;
            Model.CrewID = CrewViewModel.CrewList[finalIndex].CrewID + 1;
           // CrewViewModel.CrewList.Add(Model);
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
            //model.PostData = "Test";
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
            Model.CrewID = CrewViewModel.ID;
            CrewViewModel.CrewList[CrewViewModel.currentIndex] = Model;
            ClearSession();
            return PartialView("_CrewModel", CrewViewModel);

        }

        [HttpPost, Route("/Crew/deleteMember")]
        public PartialViewResult deleteMember()
        {

            for (int x = CrewViewModel.currentIndex; x <= CrewViewModel.CrewList.Count - 2; x++)
            {
                int nextIndex = x + 1;
                CrewViewModel.CrewList[x] = CrewViewModel.CrewList[nextIndex];
            }

            int finalIndex = CrewViewModel.CrewList.Count - 1;
            CrewViewModel.CrewList.RemoveAt(finalIndex);

            ClearSession();

            return PartialView("_CrewModel", CrewViewModel);

        }

        [HttpPost, Route("/Crew/EditMember")]
        public PartialViewResult EditMember([FromBody]Crew ID)
        {

            Crew item = CrewViewModel.CrewList.Single(r => r.CrewID == ID.CrewID);
            CrewViewModel.currentIndex = CrewViewModel.CrewList.FindIndex(r => r.CrewID == ID.CrewID);
            CrewViewModel.ID = item.CrewID;
            CrewViewModel.Name = item.Name;
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
            CrewViewModel.ID = 0;
            CrewViewModel.Name = null;
            CrewViewModel.Designation = null;
        }
    }
}
