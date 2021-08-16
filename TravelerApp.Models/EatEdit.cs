using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;

namespace TravelerApp.Models
{
    public class EatEdit
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual RestaurantType RestaurantType { get; set; }
    }
}
