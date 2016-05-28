using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace nash_bike_trip.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime TripDate { get; set; }
        public string TripNotes { get; set; }


    }

    public class TripDBContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
    }
}