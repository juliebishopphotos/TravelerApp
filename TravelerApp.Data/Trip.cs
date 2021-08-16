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
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public virtual ICollection<Eat> PlacesToEat { get; set; } = new List<Eat>();
        public virtual ICollection<See> PlacesToSee { get; set; } = new List<See>();
        public virtual ICollection <Stay> PlacesToStay { get; set; } = new List<Stay>();

    }
}
