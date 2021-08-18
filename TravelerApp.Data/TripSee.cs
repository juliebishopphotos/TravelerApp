using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Data
{
    public class TripSee
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey(nameof(Trip))]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey(nameof(See))]
        public int SeeId { get; set; }
        public virtual See See { get; set; }
    }
}
