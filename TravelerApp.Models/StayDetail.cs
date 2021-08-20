using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class StayDetail
    {
        [Display(Name="Lodging Id")]
        public int StayId { get; set; }
        [Display(Name="Lodging Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        [Display(Name="Type")]
        public LodgingType TypeOfLodging { get; set; }
    }
}
