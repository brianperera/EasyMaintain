using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.Utility;


namespace EasyMaintain.CoreWebMVC.Models.AccountViewModels
{
    public class UserDataModel
    {
        //public UserDataModel() {
        //    Username = SessionUtility.utilityUserdataModel.Username;
        //    ID = SessionUtility.utilityUserdataModel.ID;
        //    Name = SessionUtility.utilityUserdataModel.Name;
        //    Email = SessionUtility.utilityUserdataModel.Email;
        //    PhoneNumber = SessionUtility.utilityUserdataModel.PhoneNumber;
        //}
        public string Username { get; set; }
        public string ID { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
