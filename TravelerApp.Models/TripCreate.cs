using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
     public class TripCreate
    {
        [Display(Name="Trip Name")]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
