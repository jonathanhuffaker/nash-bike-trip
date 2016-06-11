using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nash_bike_trip.DAL;
using System.Collections.Generic;
using nash_bike_trip.Models;

namespace nash_bike_trip.Tests.DAL
{
    [TestClass]
    public class nash_bike_tripRepositoryTest
    {
        [TestMethod]
        public void RepoEnsureICanCreateInstance()
        {
            nash_bike_tripRepository repo = new nash_bike_tripRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureIsUsingContext()
        {
            //Arrange
            nash_bike_tripRepository repo = new nash_bike_tripRepository();

            //Act

            //Assert
            Assert.IsNotNull(repo.context);

        }

        [TestMethod]
        public void RepoEnsureThereAreNoTrips()
        {
            //Arrange
            nash_bike_tripRepository repo = new nash_bike_tripRepository();

            //Act
            List<Trip> list_of_trips = repo.GetTrips();
            List<Trip> expected = new List<Trip>();

            //Assert
            Assert.AreEqual(expected.Count, list_of_trips.Count);

        }

        [TestMethod]
        public void RepoEnsureTripCountIsZero()
        {
            nash_bike_tripRepository repo = new nash_bike_tripRepository();

            //Act
            int expected = 0;
            int actual = repo.GetTripsCount();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepoEnsureICanAddTrip()
        {

            nash_bike_tripRepository repo = new nash_bike_tripRepository();

            //Act
            repo.AddTrip("515 Fairlane Drive, Nashville, TN 37210", "500 interstate blvd", DateTime.Now, "just adding a trip");
            //Assert
            int actual = repo.GetTripsCount();
            int expected = 1;

            Assert.AreEqual(expected, actual);

        }
    }
}
