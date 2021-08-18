using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Data
{
    public class Eat
    {
        [Key]
        public int EatId { get; set; }  
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<TripEat> TripEats { get; set; } = new List<TripEat>(); 
    }
}
