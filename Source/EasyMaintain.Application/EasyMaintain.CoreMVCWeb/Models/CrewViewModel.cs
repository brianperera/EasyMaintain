using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.DataEntities;


namespace EasyMaintain.CoreWebMVC.Models
{
    //public class Crew
    //{
    //    [Key]
    //    public int CrewID { get; set; }
    //    public string Name { get; set; }
    //    public string Designation { get; set; }
    //}

    public class CrewViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        public int currentIndex { get; set; }
        public List<Crew> CrewList { get; set; }
        public CrewViewModel()
        {
            CrewList = new List<Crew>();
            CrewList.Add(new Crew() {CrewID = 1, Name = "Jann", Designation = "Head Mechanic" });
        }
    }
}
