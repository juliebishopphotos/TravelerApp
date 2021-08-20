using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class StayCreate
    {
        [Display(Name="Lodging Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        public LodgingType TypeOfLodging { get; set; }
    }
}
