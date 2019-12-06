using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Soulstice.DATA.EF;

namespace Soulstice.UI.MVC.Controllers
{
    public class ClassesController : Controller
    {
        private SoulsticeEntities db = new SoulsticeEntities();

        // GET: Classes
        public ActionResult Index()
        {
            var classes = db.Classes.Include(x => x.Instructor).Include(x => x.WeekDay);
            return View(classes.ToList());
        }

        //one click to reserve spot for a class
        public ActionResult OneClickRes([Bind(Include = "ReservationID,GymID,ClassID,DateSubmitted")] Reservation reservation, int id)
        {

            reservation.GymID = User.Identity.GetUserId();
            var getDate = DateTime.Now;
            reservation.DateSubmitted = getDate;
            reservation.ClassID = id;
           db.Reservations.Add(reservation);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Classes/Create
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName");
            ViewBag.WeekDayID = new SelectList(db.WeekDays, "WeekDayID", "DayOfWeek");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Create([Bind(Include = "ClassID,ClassName,Description,InstructorID,ReservationLimit,Fee,WeekDayID,Time")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", @class.InstructorID);
            ViewBag.WeekDayID = new SelectList(db.WeekDays, "WeekDayID", "DayOfWeek", @class.WeekDayID);
            return View(@class);
        }

        // GET: Classes/Edit/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", @class.InstructorID);
            ViewBag.WeekDayID = new SelectList(db.WeekDays, "WeekDayID", "DayOfWeek", @class.WeekDayID);
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit([Bind(Include = "ClassID,ClassName,Description,InstructorID,ReservationLimit,Fee,WeekDayID,Time")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", @class.InstructorID);
            ViewBag.WeekDayID = new SelectList(db.WeekDays, "WeekDayID", "DayOfWeek", @class.WeekDayID);
            return View(@class);
        }

        // GET: Classes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Classes/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
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
