﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nash_bike_trip.DAL;
using System.Collections.Generic;
using nash_bike_trip.Models;
using Moq;
using System.Linq;
using System.Data.Entity;

namespace nash_bike_trip.Tests.DAL
{
    [TestClass]
    public class nash_bike_tripRepositoryTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }


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
            //Mocking
            List<Trip> datasource = new List<Trip> ();
            Mock<nash_bike_tripContext> mock_context = new Mock<nash_bike_tripContext>();
            Mock<DbSet<Trip>> mock_trips_table = new Mock<DbSet<Trip>>(); //fake trips table

            //Arrange
            nash_bike_tripRepository repo = new nash_bike_tripRepository(mock_context.Object);  //Injects a mocked (fake) nash_bike_tripContext
            var data = datasource.AsQueryable();


            //Tell our fake Dbset to use our datasource like something Queryable
            mock_trips_table.As<IQueryable<Trip>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_trips_table.As<IQueryable<Trip>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_trips_table.As<IQueryable<Trip>>().Setup(m => m.Expression).Returns(data.Expression);
            mock_trips_table.As<IQueryable<Trip>>().Setup(m => m.Provider).Returns(data.Provider);

            //Tell our mocked nash_bike_tripRepositoryContex to use our fully mocked datasource (List<Trip>)
            mock_context.Setup(m => m.Trips).Returns(mock_trips_table.Object);

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