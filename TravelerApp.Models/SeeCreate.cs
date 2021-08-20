using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
    public class SeeCreate
    {
        [Display(Name="Attraction Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
