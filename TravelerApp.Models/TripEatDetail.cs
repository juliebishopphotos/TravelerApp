using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
    public class TripEatDetail
    {
        [Display(Name = "Trip Name")]
        public int TripId { get; set; }
        [Display(Name = "Restaurant Name")]
        public int EatId { get; set; }
    }
}
