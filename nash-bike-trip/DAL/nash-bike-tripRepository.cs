using nash_bike_trip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nash_bike_trip.DAL
{
    public class nash_bike_tripRepository
    {
        public nash_bike_tripContext context { get; set; }

        public nash_bike_tripRepository()
        {
            context = new nash_bike_tripContext();
        }

        public int GetTripsCount()
        {
            return context.Trips.Count();
        }

        public List<Trip> GetTrips()
        {
            return context.Trips.ToList<Trip>();
        }

        public void AddTrip(string DepartureTitle, string ArrivalTitle, DateTime TripDate, string TripNotes)
        {
            throw new NotImplementedException();

        }
    }
}