using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Data
{
    public class TripEat
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey(nameof(Trip))] 
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey(nameof(Eat))]
        public int EatId { get; set; }
        public virtual Eat Eat { get; set; }
    }
}
