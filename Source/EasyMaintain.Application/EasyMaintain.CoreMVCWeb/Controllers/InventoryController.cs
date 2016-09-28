using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;
using EasyMaintain.DTO;

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

        [HttpPost, Route("/inventory/CreateOrder")]
        public PartialViewResult CreateOrder([FromBody]Inventory Model)
        {
            Model.PartsList = new List<string>();
            Model.PartsList.AddRange(session.PartsList);
            Model.InvoiceNumber = (session.InventoryOrders.Count) + 1;
            //Model.Deliverydetailsmodel = new DeliveryDetailsModel();
            session.InventoryOrders.Add(Model);

            return PartialView("_ManageRequests", session);

        }

        [HttpPost, Route("/inventory/SaveEditedOrder")]
        public PartialViewResult SaveEditedOrder([FromBody]Inventory Model)
        {
            int index = session.InvoiceNumber - 1;
            session.InventoryOrders[index].AdditionalNotes = Model.AdditionalNotes;
            session.InventoryOrders[index].Deliverydetails = Model.Deliverydetails;

            return PartialView("_ManageRequests", session);

        }

        [HttpPost, Route("/inventory/SaveTempData")]
        public void SaveTempData([FromBody] Inventory Model)
        {
            session.CustomerName = Model.CustomerName;
            session.CompanyName = Model.CompanyName;
            session.AdditionalNotes = Model.AdditionalNotes;
            session.PaymentMethod = Model.PaymentMethod;
            session.BillingName = Model.BillingName;
            session.BillingAddress = Model.BillingAddress;
            session.PaymentNotes = Model.PaymentNotes;
            session.Deliverydetails = Model.Deliverydetails;
            session.Deliverydetailsmodel = new DeliveryDetailsModel();
        }

        [HttpPost, Route("/Inventory/AddPart")]
        public PartialViewResult AddPart([FromBody] SparePart Part)
        {
            session.PartsList.Add(Part.Name);
            //session.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewOrder", session);
        }

        [HttpDelete, Route("/Inventory/DeletePart")]
        public PartialViewResult DeletePart([FromBody]SparePart Part)
        {
            var itemToRemove = session.PartsList.Single(r => r == Part.Name);
            session.PartsList.Remove(itemToRemove);
            //session.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewOrder", session);
        }

        [HttpPost, Route("/Inventory/EditOrder")]
        public PartialViewResult EditOrder([FromBody]Inventory ID)
        {

            Inventory item = session.InventoryOrders.Single(r => r.InvoiceNumber == ID.InvoiceNumber);

            session.InvoiceNumber = item.InvoiceNumber;
            session.CustomerName = item.CustomerName;
            session.CompanyName = item.CompanyName;
            session.AdditionalNotes = item.AdditionalNotes;
            session.PartsList = item.PartsList;
            session.Deliverydetails = item.Deliverydetails;

            return PartialView("_EditOrder", session);

        }

        public PartialViewResult Search()
        {
            return PartialView("_Search", session);
        }

        public PartialViewResult ManageRequests()
        {
            sessionClear();
            return PartialView("_ManageRequests", session);
        }

        public PartialViewResult NewOrder()
        {
            sessionClear();
            return PartialView("_NewOrder", session);
        }

        public PartialViewResult NewRestockOrder()
        {
            return PartialView("_NewRestockOrder", session);
        }

        public void sessionClear()
        {
            session.CustomerName = null;
            session.CompanyName = null;
            session.AdditionalNotes = null;
            session.BillingAddress = null;
            session.BillingName = null;
            session.PaymentMethod = null;
            session.PaymentNotes = null;
            session.ActiveTab = SessionUtility.Frame_1;
            session.CustomerName = null;
            session.PartsList.Clear();
        }

    }
}
