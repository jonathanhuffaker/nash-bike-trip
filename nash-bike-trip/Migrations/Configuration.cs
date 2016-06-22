namespace nash_bike_trip.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<nash_bike_trip.DAL.nash_bike_tripContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(nash_bike_trip.DAL.nash_bike_tripContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //DateTime basetime = DateTime.Now;

            //context.Trips.AddOrUpdate(
            //   trip => trip.DepartureTitle, // Is it in the database already?
            //   new Trip { TripId = 1, DepartureTitle = "617 Whispering Hills Drive, Nasville,TN", ArrivalTitle = "500 Interstate Blvd S, Nashville, TN 37210", TripDate = basetime.AddDays(1), TripNotes = "Took new route to avoid as much traffic on Nolensville"},
            //   new Trip { TripId = 2, DepartureTitle = "Ryman Auditorium", ArrivalTitle = "617 Whispering Hills Drive, Nasville,TN", TripDate = basetime.AddDays(2), TripNotes = "Long trip from downtown to Crieve Hall"},
            //   new Trip { TripId = 3, DepartureTitle = "Bridgestone Arena", ArrivalTitle = "Craft Brewed, Franklin Pike, Nashville, TN", TripDate = basetime.AddHours(2), TripNotes = "Beers after the show. Straight shot" }

            //);
        }
    }
}
