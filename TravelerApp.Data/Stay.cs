using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerApp.Data
{
    public enum LodgingType
    {
        [Display(Name = "Hotel")]
        Hotel,
        [Display(Name = "Airbnb")]
        Airbnb,
        [Display(Name = "Bed and Breakfast")]
        BedAndBreakfast,
        [Display(Name = "Motel")]
        Motel,
        [Display(Name = "Hostel")]
        Hostel,
        [Display(Name = "Cabin")]
        Cabin,
        [Display(Name = "Camping")]
        Camping,
        [Display(Name = "Inn")]
        Inn,
        [Display(Name = "Other")]
        Other,
    }
    public class Stay
    {
        [Key]
        public int StayId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public LodgingType TypeOfLodging { get; set; }

        public virtual ICollection<TripStay> TripStays { get; set; } = new List<TripStay>();  
    }
}
