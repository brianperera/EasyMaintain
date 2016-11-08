using EasyMaintain.CoreWebMVC.DataEntities;
using EasyMaintain.CoreWebMVC.Models.AccountViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.Models
{
    public class RoleViewModel: UserDataModel
    {
        [Required]
        [Display(Name = "Role Name")] 
        public string RoleName { get; set; }

        public int RoleID { get; set; }

        public int currentIndex { get; set; }

        public List<Role> Roles { get; set; }
        public Token token { get; set; }
        
        public RoleViewModel()
        {
            Roles = new List<Role>();
            updateList();
           // Roles.Add(new Role() {RoleID = 1, Name = "Test Role" });
        }

        public void updateList()
        {

            try
            {
                var uri = "api/Roles/GetAllRoles";

                List<Role> rolesList;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8533");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    rolesList = JsonConvert.DeserializeObject<List<Role>>(response.Result);
                }
                Roles = rolesList;

            }
            catch (AggregateException e)
            {

            }

        }




    }
}
