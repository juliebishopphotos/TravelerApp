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

        public virtual ICollection<Eat> Eats { get; set; } = new List<Eat>();
        public virtual ICollection<See> Sees { get; set; } = new List<See>();
        public virtual ICollection <Stay> Stays { get; set; } = new List<Stay>(); 

    }
}
