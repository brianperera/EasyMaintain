﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EasyMaintain.CoreWebMVC.DataEntities;
using EasyMaintain.CoreWebMVC.Models.AccountViewModels;

namespace EasyMaintain.CoreWebMVC.Models
{
    //[Table("ComponentWork")]
    //public class ComponentWork
    //{
    //    [Key]
    //    public int WorkID { get; set; }
    //    public string Component { get; set; }
    //    public string SerialNumber { get; set; }
    //    public string FlightNumber { get; set; }
    //    public string Description { get; set; }
    //  //  public DeliveryDetailsModel Deliverydetailsmodel { get; set; }
    //    public DeliveryDetails Deliverydetails { get; set; }

    //    public string CreatedDate { get; set; }
    //    public string Location { get; set; }
    //}

    public class ComponentWorkModel: UserDataModel
    {
        [Required]
        [Display(Name = "Component Name")]
        public string ComponentName { get; set; }

        [Required]
        [Display(Name = "Work Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Required]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Required]
        [Display(Name = "Workshop")]
        public string WorkshopLocation { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public string CreatedDate { get; set; }

        public int WorkID { get; set; }

        public static int CurrentID { get; set; }

        public WorkshopModel Workshops { get; set; }

        public List<string> DeliveryMethods { get; set; }
        public DeliveryDetailsModel DeliveryDetailModel { get; set; }
        public DeliveryDetails DeliveryDetails { get; set; }
        public ComponentModel Components { get; set; }


        public List<ComponentWork> ComponentWorkOrders { get; set; }
        public Token token { get; set; }
        public ComponentWorkModel() {
            
            DeliveryDetailModel = new DeliveryDetailsModel();
            DeliveryDetails = new DeliveryDetails();
            Workshops = new WorkshopModel(); 
            ComponentWorkOrders = new List<ComponentWork> {
                new ComponentWork
                {
                    WorkID = 1,
                    Component = "Trubine",
                    Deliverydetails = new DeliveryDetails() {DeliveryDate = "21/06/2016" },
                    Location = "Detroit",
                    SerialNumber = "101020"
                }
            };

            DeliveryMethods = new List<string>();
            DeliveryMethods.Add("Pick Up");
            DeliveryMethods.Add("USPS");
            DeliveryMethods.Add("DHL");

            DateTime dateTime = DateTime.UtcNow.Date;
            CreatedDate = dateTime.ToString("dd/MM/yyyy");
        }


    }
}