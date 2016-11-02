using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EasyMaintain.CoreWebMVC.Models;
using Microsoft.AspNetCore.Identity;
using EasyMaintain.CoreWebMVC.DataEntities;
using EasyMaintain.CoreWebMVC.Utility;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System.IO;
using EasyMaintain.CoreWebMVC.Models.AccountViewModels;
using System.Net.Http.Headers;

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;

        public IActionResult Index()
        {
            if (SessionUtility.utilityToken.AccessToken == null){
                return View();
            }
            else {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View("Login",new LoginViewModel());
            //return View("Account/Login.cshtml");
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            
            try
            {

                string TokenUri = "http://localhost:8533/token";
                
                using (var client = new HttpClient())
                {
                    var form = new Dictionary<string, string>
               {
                   {"username", model.Email},
                   {"password", model.Password},
                   {"grant_type", "password"},
                   {"client_id", "099153c2625149bc8ecb3e85e03f0022"},
               };
                    var tokenResponse = client.PostAsync(TokenUri, new FormUrlEncodedContent(form)).Result;
                    //var token = tokenResponse.Content.ReadAsStringAsync().Result;  
                    SessionUtility.utilityToken = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                    
                    if (string.IsNullOrEmpty(SessionUtility.utilityToken.Error))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionUtility.utilityToken.AccessToken);
                        string UserdataUri = "http://localhost:8533/api/account/userdata";
                        Task<String> UserdataResponse =  client.GetStringAsync(UserdataUri);
                        SessionUtility.utilityUserdataModel = JsonConvert.DeserializeObject<UserDataModel>(UserdataResponse.Result);
                        return RedirectToAction("Index", "Home", new { area = "" });
                        //return View("Index", SessionUtility.utilityUserdataModel);
                    }
                    else
                    {
                        //Console.WriteLine("Error : {0}", token.Error);
                    }
                }
            }
            catch (AggregateException e)
            {
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View("Register", new RegisterViewModel());
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model, string returnUrl = null)
        {
            
            try
            {

                string Uri = "http://localhost:8533/api/account/register";
                
                using (var client = new HttpClient())
                {
                    var form = new Dictionary<string, string>
               {
                   {"username", model.Username},
                   {"password", model.Password},
                   {"confirmPassword", model.ConfirmPassword},
                   {"Name", model.Name},
                   {"Email", model.Email},
                   {"PhoneNumber", model.PhoneNumber}
               };

                    string AccountData = JsonConvert.SerializeObject(form);

                    this.PostAsync(Uri,AccountData);
                    
                }
            }
            catch (AggregateException e)
            {
            }

            return Redirect("http://localhost:8350/Account/login");
        }


        private void PostAsync(string uri, string data)
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

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
