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



  
        public ActionResult OneClickRes([Bind(Include = "ReservationID,GymID,ClassID,DateSubmitted")] Reservation reservation, int id)
        {

            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();
                GymMember gm = db.GymMembers.Where(x => x.GymID == currentUser).Single();

                //Get count of number of people registered to take a specific class
                var numberPeople = db.Reservations.Where(x => x.ClassID == id).Count();


                //get reservations limit for specific class - good code
                var resLimit = db.Classes.Where(x => x.ClassID == id).Single().ReservationLimit;

                //get list of current classes the user is taking
                var currentUserClasses = db.Reservations.Where(x => x.GymID == gm.GymID);

                //loop thru list of current userclasses
                foreach (var item in currentUserClasses)
                {
                    //compare those classes to the current class the the user is trying to enroll in
                    if (item.ClassID == id)
                    {
                        //if any of the currentUserClasses are really equal to the current class the user is trying to enroll in
                        //display this message in the view
                        ViewBag.GymMember = gm.FirstName;
                        ViewBag.EnrollmentMessage = "You have already signed up for this class.";
                        var classes = db.Classes.Include(x => x.Instructor).Include(x => x.WeekDay);
                        return View("Index", classes.ToList());
                    }
                }

                if (numberPeople < resLimit)
                {
                    //create reservation                 
                    ViewBag.GymMember = gm.FirstName;
                    reservation.GymID = User.Identity.GetUserId();
                    var getDate = DateTime.Now;
                    reservation.DateSubmitted = getDate;
                    reservation.ClassID = id;
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    return View("ReservationConfirmation", reservation);
                }
                else
                {
                    ViewBag.Message = "This class had reached the maximum number of particpants for this class. Please choose another one.";
                    var classes = db.Classes.Include(x => x.Instructor).Include(x => x.WeekDay);
                    return View("Index", classes.ToList());
                }
            }

            //var classes = db.Classes.Include(x => x.Instructor).Include(x => x.WeekDay);
            return View("Index");


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
