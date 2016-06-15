﻿using nash_bike_trip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nash_bike_trip.DAL
{
    public class nash_bike_tripRepository
    {
        public nash_bike_tripContext context { get; set; }
        //public IDbSet<ApplicationUser> Users { get}


        public nash_bike_tripRepository()
        {
            //instance of a context

            context = new nash_bike_tripContext();
        }

        public nash_bike_tripRepository(nash_bike_tripContext _context)
        {
            context = _context;
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
            Trip new_trip = new Trip { DepartureTitle = DepartureTitle, ArrivalTitle = ArrivalTitle, TripDate = TripDate, TripNotes = TripNotes };
            context.Trips.Add(new_trip);
            context.SaveChanges();
        }

        public Trip GetTrip(int _trip_id)
        {
            Trip trip;

            try
            {
                trip = context.Trips.First(i => i.TripId == _trip_id);

            } catch (Exception)
            {
                throw new DllNotFoundException();
            }

            return trip; //ConnectMockstoDatastore made this possible
        }

        public void RemoveTrip(int _trip_id)
        {
            Trip some_trip = context.Trips.First(i => i.TripId == _trip_id);

            context.Trips.Remove(some_trip);
            context.SaveChanges();
        }

        public Trip GetTripOrNull(int _trip_id)
        {
            return context.Trips.FirstOrDefault(i => i.TripId == _trip_id);
        }
    }
}