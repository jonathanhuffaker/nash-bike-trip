using System;
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

        //Mocking
        List<Trip> datasource { get; set; }
        Mock<nash_bike_tripContext> mock_context { get; set; }
        Mock<DbSet<Trip>> mock_trips_table { get; set; } //fake trips table
        nash_bike_tripRepository repo { get; set; }
        IQueryable<Trip> data { get; set; }  //Turns List<Trip> into something we can query with Linq


        [TestInitialize]
        public void Initialize()
        {
            datasource = new List<Trip>();
            mock_context = new Mock<nash_bike_tripContext>();
            mock_trips_table = new Mock<DbSet<Trip>>(); //fake polls table

            repo = new nash_bike_tripRepository(mock_context.Object); // Injects mocked (fake) VotrContext
            data = datasource.AsQueryable();
        }

        [TestCleanup]
        public void Cleanup()
        {
            datasource = null;
        }

        void ConnectMocksToDatastore() //Utility method
        {
            var data = datasource.AsQueryable();


            //Tell our fake Dbset to use our datasource like something Queryable
            mock_trips_table.As<IQueryable<Trip>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_trips_table.As<IQueryable<Trip>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_trips_table.As<IQueryable<Trip>>().Setup(m => m.Expression).Returns(data.Expression);
            mock_trips_table.As<IQueryable<Trip>>().Setup(m => m.Provider).Returns(data.Provider);

            //Tell our mocked nash_bike_tripRepositoryContex to use our fully mocked datasource (List<Trip>)
            mock_context.Setup(m => m.Trips).Returns(mock_trips_table.Object);

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
            //nash_bike_tripRepository repo = new nash_bike_tripRepository();

            //Act

            //Assert
            Assert.IsNotNull(repo.context);

        }

        [TestMethod]
        public void RepoEnsureThereAreNoTrips()
        {

            ConnectMocksToDatastore();

            //Act
            List<Trip> list_of_trips = repo.GetTrips();
            List<Trip> expected = new List<Trip>();

            //Assert
            Assert.AreEqual(expected.Count, list_of_trips.Count);

        }

        [TestMethod]
        public void RepoEnsureTripCountIsZero()
        {
            //nash_bike_tripRepository repo = new nash_bike_tripRepository();

            ConnectMocksToDatastore();

            //Act
            int expected = 0;
            int actual = repo.GetTripsCount();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepoEnsureICanAddTrip()
        {

            ConnectMocksToDatastore();

            //Hijack the call to the Trips.Add method and put it in the list using the list's Add method.
            mock_trips_table.Setup(m => m.Add(It.IsAny<Trip>())).Callback((Trip trip) => datasource.Add(trip));

            //Act
            repo.AddTrip("515 Fairlane Drive, Nashville, TN 37210", "500 interstate blvd", DateTime.Now, "just adding a trip");
            //Assert
            int actual = repo.GetTripsCount();
            int expected = 1;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RepoEnsureICanNotFindOrNull()
        {
            //Arrange

            Trip trip_in_db = new Trip { TripId = 1, DepartureTitle = "Some Title", ArrivalTitle = "Some place you are arriving", TripDate = DateTime.Now, TripNotes = " tripnote trip note note note trip"};
            Trip trip_in_db_2 = new Trip { TripId = 2, DepartureTitle = "Some Title2", ArrivalTitle = "Second place you are arriving2", TripDate = DateTime.Now, TripNotes = " trip2note trip2 note2 note2 note2 trip2" };
            datasource.Add(trip_in_db);
            datasource.Add(trip_in_db_2);

            datasource.Remove(trip_in_db_2);

            ConnectMocksToDatastore();

            //act
            Trip found_trip = repo.GetTripOrNull(5);

            //Assert
            Assert.IsNull(found_trip);


        }


        //no longer need the below since i have "RepoEnsureICanNotFindOrNull" above
        //[TestMethod]
        //[ExpectedException(typeof(NotFoundException))]
        //public void RepoEnsureICanNotFind()
        //{
        //    //Arrange
        //    Trip trip_in_db = new Trip { TripId = 1, DepartureTitle = "Some Title", ArrivalTitle = "Some place you are arriving", TripDate = DateTime.Now, TripNotes = " tripnote trip note note note trip" };
        //    Trip trip_in_db_2 = new Trip { TripId = 2, DepartureTitle = "Some Title2", ArrivalTitle = "Second place you are arriving2", TripDate = DateTime.Now, TripNotes = " trip2note trip2 note2 note2 note2 trip2" };
        //    datasource.Add(trip_in_db);
        //    datasource.Add(trip_in_db_2);

        //    datasource.Remove(trip_in_db_2);

        //    ConnectMocksToDatastore();

        //    //Act
        //    repo.GetTrip(5);

        //}

        [TestMethod]
        public void RepoEnsureICanDeleteTrip()
        {
            //Arrange
            Trip trip_in_db = new Trip { TripId = 1, DepartureTitle = "Some Title", ArrivalTitle = "Some place you are arriving", TripDate = DateTime.Now, TripNotes = " tripnote trip note note note trip" };
            Trip trip_in_db_2 = new Trip { TripId = 2, DepartureTitle = "Some Title2", ArrivalTitle = "Second place you are arriving2", TripDate = DateTime.Now, TripNotes = " trip2note trip2 note2 note2 note2 trip2" };
            datasource.Add(trip_in_db);
            datasource.Add(trip_in_db_2);

            ConnectMocksToDatastore();
            mock_trips_table.Setup(m => m.Remove(It.IsAny<Trip>())).Callback((Trip trip) => datasource.Remove(trip));

            //Act
            repo.RemoveTrip(1);

            //Assert
            int expected_count = 1;
            Assert.AreEqual(expected_count, repo.GetTripsCount());
            //^check repo to see why i used "get trips" as opposed to "GetTrip"

            try
            {
                repo.GetTrip(1);
                Assert.Fail();
            } catch (Exception) { }

        }

        [TestMethod]
        public void RepoEnsureICanGetATrip()
        {
            Trip trip_in_db = new Trip { TripId = 1, DepartureTitle = "Some Title", ArrivalTitle = "Some place you are arriving", TripDate = DateTime.Now, TripNotes = " tripnote trip note note note trip" };
            Trip trip_in_db_2 = new Trip { TripId = 2, DepartureTitle = "Some Title2", ArrivalTitle = "Second place you are arriving2", TripDate = DateTime.Now, TripNotes = " trip2note trip2 note2 note2 note2 trip2" };
            datasource.Add(trip_in_db);
            datasource.Add(trip_in_db_2);

            ConnectMocksToDatastore();

            //Act
            Trip found_trip = repo.GetTrip(1);

            //Assert 
            Assert.IsNotNull(found_trip);
            Assert.AreEqual(trip_in_db, found_trip);
        }
    }
}
