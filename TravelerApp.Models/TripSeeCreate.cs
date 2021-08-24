using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
    public class TripSeeCreate
    {
        [Display(Name="Trip Id")]
        public int TripId { get; set; }
        [Display(Name ="Attraction Id")]
        public int SeeId { get; set; } 
    }
}
