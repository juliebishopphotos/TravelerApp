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
        public ICollection<Eat> PlacesToEat { get; set; }
        public ICollection<See> PlacesToSee { get; set; }
        public ICollection<Stay> PlacesToStay { get; set; }
    }
}
