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
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        ICollection<Eat> PlacesToEat { get; set; } = new List<Eat>();
        ICollection<See> PlacesToSee { get; set; } = new List<See>();
        ICollection <Stay> PlacesToStay { get; set; } new List<Stay>();

    }
}
