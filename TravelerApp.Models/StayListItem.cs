using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
    public class StayListItem
    { 
        [Display(Name="Lodging Id")]
        public int StayId { get; set; }
        [Display(Name="Lodging Name")]
        public string Name { get; set; }
    }
}
