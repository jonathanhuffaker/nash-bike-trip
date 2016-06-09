using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nash_bike_trip.Models;
using nash_bike_trip.DAL;

namespace nash_bike_trip.Tests
{
    [TestClass]
    public class TripTest
    {
        [TestMethod]
        public void TripEnsureICanCreateAnInstance()
        {
            Trip t = new Trip();
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void TripEnsureICanSaveATrip()
        {
            //Arrange
            nash_bike_tripContext context = new nash_bike_tripContext();
            Trip t = new Trip();

            //Act
            context.Trips.Add(t);
            context.SaveChanges();

            //Assert

            Assert.AreEqual(1, context.Trips.Add(t));


        }
    }
}
