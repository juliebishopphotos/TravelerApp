using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class StayDetail
    {
        public int StayId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public LodgingType TypeOfLodging { get; set; }
    }
}
