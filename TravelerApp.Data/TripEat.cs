﻿using System;
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
        [Required]
        [ForeignKey(nameof(Eat))]
        public int EatId { get; set; }
        public virtual Eat Eat { get; set; }

        [Required]
        [ForeignKey(nameof(Trip))] 
       public int TripId { get; set; }
       public virtual Trip Trip { get; set; }
    }
}