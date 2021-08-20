using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class TripEdit
    {
       [Display(Name="Trip Id")]
       public int TripId { get; set; }
       [Display(Name="Trip Name")]
       public string Name { get; set; }
       public string Location { get; set; }

    }
}
