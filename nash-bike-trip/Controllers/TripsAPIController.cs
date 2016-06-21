using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using nash_bike_trip.DAL;
using nash_bike_trip.Models;

namespace nash_bike_trip.Controllers
{
    public class TripsAPIController : ApiController
    {

       
       
        private nash_bike_tripRepository repo = new nash_bike_tripRepository();

        //GET: api/TripsAPI
       public IEnumerable<Trip> Get()

       {
           return repo.GetTrips();
       }

    


        //public object Get()
        //{
        //    var repo = new nash_bike_tripRepository(new nash_bike_tripContext());
        //    var results = repo.GetTrips();
        //    return results;
        //}



    // GET: api/TripsAPI/5
    [ResponseType(typeof(Trip))]
        public IHttpActionResult GetTrip(int id)
        {
            Trip trip = repo.GetTrip(id);
            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // PUT: api/TripsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrip(int id, Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trip.TripId)
            {
                return BadRequest();
            }

            repo.EditTrip(trip);

            //try
            //{
            //    repo.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TripExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return Ok(trip);
        }

        // POST: api/TripsAPI
        [ResponseType(typeof(Trip))]
        public IHttpActionResult PostTrip(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.AddTrip(trip.DepartureTitle, trip.ArrivalTitle, trip.TripDate, trip.TripNotes);
            

            return CreatedAtRoute("DefaultApi", new { id = trip.TripId }, trip);
        }

        // DELETE: api/TripsAPI/5
        [ResponseType(typeof(Trip))]
        public IHttpActionResult DeleteTrip(int id)
        {
            Trip trip = repo.GetTrip(id);
            if (trip == null)
            {
                return NotFound();
            }

            repo.RemoveTrip(trip.TripId);

            return Ok(trip);
        }

      
       // dont see why i would need the below
        //private bool TripExists(int id)
        //{
        //    return repo.GetTripOrNull(id);
        //}
    }
}