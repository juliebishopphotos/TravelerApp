using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
    public class SeeDetail
    {
        [Display(Name="Attraction Id")]
        public int SeeId { get; set; }
        [Display(Name="Attraction Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
