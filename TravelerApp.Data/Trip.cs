using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Data
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public virtual ICollection<TripEat> Eats { get; set; } = new List<TripEat>();
        public virtual ICollection<TripSee> Sees { get; set; } = new List<TripSee>();
        public virtual ICollection <TripStay> Stays { get; set; } = new List<TripStay>();  

    }
}
