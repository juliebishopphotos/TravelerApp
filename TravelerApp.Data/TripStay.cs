using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Data
{
    public class TripStay
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey(nameof(Trip))]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey(nameof(Stay))]
        public int StayId { get; set; }
        public virtual Stay Stay { get; set; }
    }
}
