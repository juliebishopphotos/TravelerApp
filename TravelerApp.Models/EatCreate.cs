using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class EatCreate
    {
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
