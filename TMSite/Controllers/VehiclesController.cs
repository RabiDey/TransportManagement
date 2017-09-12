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
    public class VehiclesController : Controller
    {
        private TMDBEntities db = new TMDBEntities();

        // GET: Vehicles
        public ActionResult Index(string vName, string sortOrder)
        {

            ViewBag.MOTExpDate = sortOrder == "Date1" ? "date_desc1" : "Date1";
            ViewBag.InsExpDate = sortOrder == "Date2" ? "date_desc2" : "Date2";
            ViewBag.ServiceDate = sortOrder == "Date3" ? "date_desc3" : "Date3";

            var vehicle = from v in db.Vehicles
                          select v;

            switch (sortOrder)
            {
                case "date_desc1":
                    vehicle = vehicle.OrderByDescending(v => v.MOTExpiryDate);
                    break;
                case "date_desc2":
                    vehicle = vehicle.OrderByDescending(v => v.InsuranceExpiryDate);
                    break;
                case "date_desc3":
                    vehicle = vehicle.OrderByDescending(v => v.ServiceDueDate);
                    break;

            }
               


            var VehicleList = new List<string>();

            var VehicleQuery = from vhname in db.Vehicles
                             orderby vhname.RegNumber
                             select vhname.RegNumber;

            VehicleList.AddRange(VehicleQuery.Distinct());
            ViewBag.vName = new SelectList(VehicleList);

            //var vehicle = from v in db.Vehicles
            //              select v;

            if (!String.IsNullOrEmpty(vName))
            {
                vehicle = vehicle.Where(a => a.RegNumber == vName);
            }


            return View(vehicle);


            //return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleID,RegNumber,RegDate,Make,Model,FuelType,MOTExpiryDate,InsuranceExpiryDate,LastServicedDate,ServiceDueDate,CurrentMileage,FuelCardNumber")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleID,RegNumber,RegDate,Make,Model,Colour,FuelType,WarrantyYears,MOTExpiryDate,InsuranceExpiryDate,LastServicedDate,ServiceDueDate,CurrentMileage,RoadSideCover,FuelCardNumber")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
