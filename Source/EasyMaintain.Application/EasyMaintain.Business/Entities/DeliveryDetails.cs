using EasyMaintain.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business.Entities
{
   public class DeliveryDetails:IBusiness
    {
        DeliveryDetails mDeliveryDetails;
        
        public int DeliveryDetailsId { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryMethod { get; set; }
        public string PersonInCharge { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddtionalNotes { get; set; }




        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
        public object GetData()
        {

            List<DeliveryDetails> result = new List<DeliveryDetails>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.Models.DeliveryDetails deliveryDetails in dp.GetdeliveryDetailsData())
            {
                DeliveryDetails _deliveryDetails = new DeliveryDetails();
                _deliveryDetails.DeliveryDetailsId = deliveryDetails.DeliveryDetailsId;
                _deliveryDetails.DeliveryDate = deliveryDetails.DeliveryDate;
                _deliveryDetails.DeliveryMethod = deliveryDetails.DeliveryMethod;
                _deliveryDetails.PersonInCharge = deliveryDetails.PersonInCharge;
                _deliveryDetails.AddressLine1 = deliveryDetails.AddressLine1;
                _deliveryDetails.AddressLine2 = deliveryDetails.AddressLine2;
                _deliveryDetails.City = deliveryDetails.City;
                _deliveryDetails.State = deliveryDetails.State;
                _deliveryDetails.AddtionalNotes = deliveryDetails.AddtionalNotes;
                result.Add(_deliveryDetails);
            }

            return result;

        }

        public int Save(object record)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="Delivery Details"></param>
        /// <returns></returns>
        public int Insert(object deliveryDetails)
        {
            this.mDeliveryDetails = deliveryDetails as DeliveryDetails;
            DataProvidor dp = new DataProvidor();
            return dp.AddDeliveryDetails(mDeliveryDetails.DeliveryDetailsId.ToString(), mDeliveryDetails.DeliveryDate, mDeliveryDetails.DeliveryMethod, mDeliveryDetails.PersonInCharge, mDeliveryDetails.AddressLine1, mDeliveryDetails.AddressLine2, mDeliveryDetails.City,mDeliveryDetails.State,mDeliveryDetails.AddtionalNotes);
        }
        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="deliveryDetails"></param>
        public void DeleteOne(object deliveryDetails)
        {
            this.mDeliveryDetails = deliveryDetails as DeliveryDetails;

            DataProvidor dp = new DataProvidor();
            dp.DeleteDeliveryDetails(mDeliveryDetails.DeliveryDetailsId.ToString());
        }
        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="deliveryDetails"></param>
        /// <returns></returns>
        public bool UpdateOne(object deliveryDetails)
        {
            this.mDeliveryDetails = deliveryDetails as DeliveryDetails;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateDeliveryDetails(mDeliveryDetails.DeliveryDetailsId.ToString(), mDeliveryDetails.DeliveryDate, mDeliveryDetails.DeliveryMethod, mDeliveryDetails.PersonInCharge, mDeliveryDetails.AddressLine1, mDeliveryDetails.AddressLine2, mDeliveryDetails.City, mDeliveryDetails.State, mDeliveryDetails.AddtionalNotes);
        }

        public DeliveryDetails Find(object deliveryDetailsID)
        {
            List<DeliveryDetails> result = new List<DeliveryDetails>();
            return result
                .Where(e => e.DeliveryDetailsId.Equals(DeliveryDetailsId))
                .SingleOrDefault();
        }
    }
}
