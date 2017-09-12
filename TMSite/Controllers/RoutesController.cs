using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMSite.Models;

namespace TMSite.Controllers
{
    public class RoutesController : Controller
    {
        private TMDBEntities db = new TMDBEntities();

        // GET: Routes
        public ActionResult Index(string rName)
        {
            //search route

            var RouteList = new List<string>();

            var RouteQuery = from rtname in db.Routes
                             orderby rtname.RouteName
                             select rtname.RouteName;

            RouteList.AddRange(RouteQuery.Distinct());
            ViewBag.rName = new SelectList(RouteList);

            var route = from r in db.Routes
                        select r;

            if(!String.IsNullOrEmpty(rName))
            {
                route = route.Where(a => a.RouteName == rName);
            }


            //var routes = db.Routes.Include(r => r.Driver).Include(r => r.Vehicle);
            //return View(routes.ToList());

            return View(route);
        }

        // GET: Routes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "FirstName");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "RegNumber");
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteID,RouteName,DriverID,VehicleID")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Routes.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "FirstName", route.DriverID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "RegNumber", route.VehicleID);
            return View(route);
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "FirstName", route.DriverID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "RegNumber", route.VehicleID);
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteID,RouteName,DriverID,VehicleID")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "FirstName", route.DriverID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "RegNumber", route.VehicleID);
            return View(route);
        }

        // GET: Routes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Routes.Find(id);
            db.Routes.Remove(route);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
