using nash_bike_trip.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace nash_bike_trip.DAL
{
    public class nash_bike_tripContext : DbContext
    {
        //public nash_bike_tripContext(string connectionString)
        //{
        //    //base.DbContext
        //}
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}