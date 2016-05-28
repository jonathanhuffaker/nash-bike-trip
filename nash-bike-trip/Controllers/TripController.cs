using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nash_bike_trip.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            //return "This is my default action";
            return View();
        }
    }
}