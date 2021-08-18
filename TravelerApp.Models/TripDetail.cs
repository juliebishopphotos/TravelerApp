using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class TripDetail
    {
        public int TripId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Eat> Eats { get; set; } 
        public ICollection<See> Sees { get; set; }
        public ICollection<Stay> Stays { get; set; }
    }
}
