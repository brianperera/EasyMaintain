using EasyMaintain.DataAccess;
using EasyMaintain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyMaintain.Business
{
    public class InventoryLogic
    {

        public InventoryLogic()
        {

        }

        Inventory mInventory = new Inventory();

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


                result.Add(_inventory);
            }

            return result;
        }


        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public int Insert(object inventory)
        {
            this.mInventory = inventory as Inventory;
            DataProvidor dp = new DataProvidor();
            return dp.AddInventory(mInventory.CustomerID, mInventory.CustomerName, mInventory.CompanyName, mInventory.AdditionalNotes, mInventory.PartsList, mInventory.InvoiceNumber, mInventory.PaymentMethod, mInventory.PaymentNotes, mInventory.BillingAddress, mInventory.BillingName, mInventory.OrderType, mInventory.Deliverydetails);
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="inventory"></param>
        public void DeleteOne(object inventory)
        {
            this.mInventory = inventory as Inventory;

            DataProvidor dp = new DataProvidor();
            dp.DeleteInventory(mInventory.CustomerID);

        }

        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public bool UpdateOne(object inventory)
        {
            this.mInventory = inventory as Inventory;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateInventory(mInventory.CustomerID, mInventory.CustomerName, mInventory.CompanyName, mInventory.AdditionalNotes, mInventory.PartsList, mInventory.InvoiceNumber, mInventory.PaymentMethod, mInventory.PaymentNotes, mInventory.BillingAddress, mInventory.BillingName, mInventory.OrderType, mInventory.Deliverydetails);
        }

        public Inventory Find(int id)
        {
            List<Inventory> result = new List<Inventory>();
            return result
                .Where(e => e.CustomerID.Equals(id))
                .SingleOrDefault();
        }
    }
}
