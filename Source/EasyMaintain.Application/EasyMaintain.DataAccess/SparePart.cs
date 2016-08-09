//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyMaintain.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class SparePart
    {
        public SparePart()
        {
            this.Inventories = new HashSet<Inventory>();
            this.SparePart_AircraftModel = new HashSet<SparePart_AircraftModel>();
            this.SparePart_Manufacturer = new HashSet<SparePart_Manufacturer>();
            this.SparePart_Supplier = new HashSet<SparePart_Supplier>();
        }
    
        public int SparePartID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string SparePartName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }
        public string Name { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<SparePart_AircraftModel> SparePart_AircraftModel { get; set; }
        public virtual ICollection<SparePart_Manufacturer> SparePart_Manufacturer { get; set; }
        public virtual ICollection<SparePart_Supplier> SparePart_Supplier { get; set; }
    }
}