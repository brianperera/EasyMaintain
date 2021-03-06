﻿using EasyMaintain.CoreWebMVC.DataEntities;
using EasyMaintain.CoreWebMVC.Models.AccountViewModels;
using EasyMaintain.CoreWebMVC.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.Models
{
    public class UsersViewModel: UserDataModel
    {
        [Required]
        [Display(Name = "First Name")] 
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public Role Role { get; set; }

        public int UserID { get; set; }
        public string Id { get; set; }

        public string LoginUsername { get; set; }
        public string LoginID { get; set; }

        public string LoginName { get; set; }

        public string LoginEmail { get; set; }

        public string LoginPhoneNumber { get; set; }

        public int currentIndex { get; set; }

        public List<Users> Users { get; set; }
        public Token token { get; set; }

        public List<Role> Roles { get; set; }


        //public UsersViewModel()
        //{
        //    Users = new List<Users>();
        //     updateUserList();

        //    Users.Add(new Users()
        //    {
        //        UserID = 1,
        //        FirstName = "Test Role",
        //      // Roles = new Role()
        //    });
        //    //Roles = SessionUtility.utilityRoleModel.Roles;
        //}


        public void updateRoles()
        {
            Roles = SessionUtility.utilityRoleModel.Roles;
        }


        public void updateUserList()
        {
            try
            {
                var uri = "api/User/Userdata ";

                List<Users> userList;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8533");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    userList = JsonConvert.DeserializeObject<List<Users>>(response.Result);
                }
                //Users = userList;

            }
            catch (AggregateException e)
            {

            }
        }



    }
}
