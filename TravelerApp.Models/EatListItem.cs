using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Models
{
    public class EatListItem
    {
        public int EatId { get; set; }
        public string Name { get; set; }
        public int TripId { get; set; }
    }
}
