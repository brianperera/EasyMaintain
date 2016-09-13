using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class InventoryController : Controller
    {
        // GET: /<controller>/
        InventoryViewModel session = SessionUtility.utilityInventoryViewModel;
        // GET: /<controller>/
        public ActionResult Index()
        {
            //var maintenanceViewModel = new MaintenanceViewModel();
            session = SessionUtility.utilityInventoryViewModel;
            return View(session);
        }

        public PartialViewResult CreateOrder(Inventory Model)
        {

            // Model.CheckItems = session.CheckItems;
            //Model.CrewMembers = session.CrewMembers;
            Model.InvoiceNumber = (session.InventoryOrders.Count) + 1;
            Model.Deliverydetails = new DeliveryDetails();
            Model.Deliverydetailsmodel = new DeliveryDetailsModel();
            session.InventoryOrders.Add(Model);

            return PartialView("_Search", session);

          /*  session.InventoryOrders.Add(
                new Inventory
                {
                    InvoiceNumber = (session.InventoryOrders.Count) + 1,
                    CustomerName = model.CustomerName,
                    CompanyName = model.CompanyName,
                    AdditionalNotes = model.AdditionalNotes,
                    PaymentMethod = model.PaymentMethod,
                    PaymentNotes = model.PaymentNotes,
                    BillingAddress = model.BillingAddress,
                    BillingName = model.BillingName,
                    OrderType = "normal",
                    Deliverydetails = model.Deliverydetails
                });

            return PartialView("_Search", session);*/
        }
        public PartialViewResult Search()
        {
            return PartialView("_Search", session);
        }

        public PartialViewResult ManageRequests()
        {
            return PartialView("_ManageRequests", session);
        }

        public PartialViewResult NewOrder()
        {
            return PartialView("_NewOrder", session);
        }

        public PartialViewResult NewRestockOrder()
        {
            return PartialView("_NewRestockOrder", session);
        }

    }
}
