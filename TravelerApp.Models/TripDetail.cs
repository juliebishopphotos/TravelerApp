using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class TripDetail
    {
        [Display(Name="Trip Id")]
        public int TripId { get; set; }
        [Display(Name="Trip Name")]
        public string Name { get; set; }
        [Display(Name="Location")]
        public string Location { get; set; }
        public ICollection<EatListItem> Eats { get; set; } 
        public ICollection<SeeListItem> Sees { get; set; } 
        public ICollection<StayListItem> Stays { get; set; } 
    }
}
