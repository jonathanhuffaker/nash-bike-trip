using nash_bike_trip.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nash_bike_trip.Models;

namespace nash_bike_trip.Controllers
{
    public class TripController : Controller
    {
        private nash_bike_tripRepository Repo = new nash_bike_tripRepository();

        // GET: Trip
        public ActionResult Index()
        {
           
            return View(Repo.GetTrips());

        }

        //Get: Trip/Details/5

        public ActionResult Details (int id)
        {
            return View();
        }

        //Get: Trip/Create
        public ActionResult Create()
        {
            return View();
        
        }

        //POST:  Trip/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET:  Trip/Edit/5
        [Authorize]
        public  ActionResult Edit(int id)
        {
            Trip found_trip = Repo.GetTripOrNull(id);
            if (found_trip == null)
            {
                return RedirectToAction("Index");
            }
            return View(found_trip);
        }

        //Post: Trip/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "TripId, DepartureTitle, ArrivalTitle,TripDate,TripNotes")]Trip trip_to_edit)
        {
           if (ModelState.IsValid)

            {

                Repo.EditTrip(trip_to_edit);
            }
            return RedirectToAction("Index");
        }

        // GET: Trip/Delete/5
        //[Authorize]
        public ActionResult Delete (int id)
        {
            Trip found_trip = Repo.GetTripOrNull(id);
            if (found_trip != null)
            {
                Repo.RemoveTrip(id);
            }
            return RedirectToAction("Index");
        }

        //POST: Trip/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //TODO:  Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }

}