using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class EatCreate
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int TripId { get; set; }
    }
}
