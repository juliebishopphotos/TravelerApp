using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
    public class TripStayCreate
    {
        [Display(Name="Trip Id")]
        public int TripId { get; set; }
        [Display(Name="Lodging Id")]
        public int StayId { get; set; } 
    }
}
