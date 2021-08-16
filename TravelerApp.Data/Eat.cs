using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Data
{
    public class Eat
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Location { get; set; }

        [ForeignKey(nameof(RestaurantType))]
        public int RestaurantId { get; set; }
        public virtual RestaurantType RestaurantType { get; set; }
    }
}
