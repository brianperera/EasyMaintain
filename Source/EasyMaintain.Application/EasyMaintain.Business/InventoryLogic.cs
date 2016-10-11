using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;
using EasyMaintain.DTO;

namespace EasyMaintain.Business
{
  public class InventoryLogic
    {

        public InventoryLogic()
        {

        }

        InventoryLogic mInventory = new InventoryLogic();

        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>

        public object GetData()
        {
            List<Inventory> result = new List<Inventory>();
            DataProvidor dp = new DataProvidor();

            foreach (DTO.Inventory inventory in dp.GetInventoryData())
            {
                Inventory _inventory = new Inventory();
                _inventory.CustomerID = inventory.CustomerID;
                _inventory.CustomerName = inventory.CustomerName;
                _inventory.CompanyName = inventory.CompanyName;
                _inventory.AdditionalNotes = inventory.AdditionalNotes;
                _inventory.PartsList = inventory.PartsList;
                _inventory.InvoiceNumber = inventory.InvoiceNumber;
                _inventory.PaymentMethod = inventory.PaymentMethod;
                _inventory.PaymentNotes = inventory.PaymentNotes;
                _inventory.BillingAddress = inventory.BillingAddress;
                _inventory.BillingName = inventory.BillingName;
                _inventory.OrderType = inventory.OrderType;
                _inventory.Deliverydetails = inventory.Deliverydetails;
                //_maintenance.FlightModel = maintenance.FlightModel;
                //_maintenance.FlightNumber = maintenance.FlightNumber;
                //_maintenance.Description = maintenance.Description;

                result.Add(_inventory);
            }

            return result;
        }
    }
}
