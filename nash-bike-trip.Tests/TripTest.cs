using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nash_bike_trip.Models;

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
    }
}
