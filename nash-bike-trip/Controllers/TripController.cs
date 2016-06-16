using nash_bike_trip.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nash_bike_trip.Controllers
{
    public class TripController : Controller
    {
        private nash_bike_tripRepository Repo = new nash_bike_tripRepository();

        // GET: Trip
        public ActionResult Index()
        {
            ViewBag.Trips = Repo.GetTrips();
            return View();

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
        public  ActionResult Edit(int id)
        {
            return View();
        }

        //Post: Trip/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //TODO:  Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trip/Delete/5
        public ActionResult Delete (int id)
        {
            return View();
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