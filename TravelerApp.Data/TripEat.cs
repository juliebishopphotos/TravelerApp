using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Data
{
    public class TripEat
    {
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public int EatId { get; set; } 
    }
}
