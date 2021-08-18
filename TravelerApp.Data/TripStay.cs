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
        [Required]
        [ForeignKey(nameof(Stay))]
        public int StayId { get; set; }
        public virtual Stay Stay { get; set; }

        [Required]
        [ForeignKey(nameof(Trip))]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
