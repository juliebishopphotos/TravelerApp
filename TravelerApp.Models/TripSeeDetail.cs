using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
    public class TripSeeDetail
    {
        [Display(Name = "Trip Name")]
        public int TripId { get; set; }
        [Display(Name = "Attraction Name")]
        public int SeeId { get; set; }
    }
}
