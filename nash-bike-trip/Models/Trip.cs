using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace nash_bike_trip.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Required]
        public string DepartureTitle { get; set; }

        [Required]
        public string ArrivalTitle { get; set; }

        [Required]
        public DateTime TripDate { get; set; }
        public string TripNotes { get; set; }

        public virtual ICollection<Option> Options { get; set;}


    }

 
}