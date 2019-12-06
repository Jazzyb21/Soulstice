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
    public class ReservationsController : Controller
    {
        private SoulsticeEntities db = new SoulsticeEntities();

        // GET: Reservations    
        [Authorize(Roles ="Admin, Staff")]
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Class).Include(r => r.GymMember);
            return View(reservations.ToList());
        }

        #region Details Action
        //// GET: Reservations/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Reservation reservation = db.Reservations.Find(id);
        //    if (reservation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(reservation);
        //}
        #endregion

        [Authorize(Roles = "Member, Admin")]
        public ActionResult GymMemberReservation()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "selectClass");
            string currentUser = User.Identity.GetUserId();

            if (!string.IsNullOrEmpty(currentUser) && User.IsInRole("Member"))
            {
                GymMember gm = db.GymMembers.Where(x => x.GymID == currentUser).Single();

                ViewBag.GymMember = $"Hi, {gm.FirstName}!";
            }         
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member, Admin")]
        public ActionResult GymMemberReservation([Bind(Include = "ReservationID,GymID,ClassID,DateSubmitted")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                //Get count of number of people registered to take a specific class
                var numberPeople = db.Reservations.Where(x => x.ClassID == reservation.ClassID).Count();

        
                //get reservations limit for specific class - good code
                var resLimit = db.Classes.Where(x => x.ClassID == reservation.ClassID).Single().ReservationLimit;


                if (numberPeople < resLimit)
                {
                    //    //create reservation
                    reservation.GymID = User.Identity.GetUserId();
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Classes");
                }
                else
                {
                    ViewBag.Message = "This class had reached the maximum number of particpants for this class. Please choose another one.";
                }

            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", reservation.ClassID);

            return View(reservation);
        }

        // GET: Reservations/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "selectClass");

                ViewBag.GymID = new SelectList(db.GymMembers, "GymID", "FullName");
           
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ReservationID,GymID,ClassID,DateSubmitted")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", reservation.ClassID);
            ViewBag.GymID = new SelectList(db.GymMembers, "GymID", "FirstName", reservation.GymID);
            return View(reservation);
        }

        #region Edit Get and Post Actions
        //// GET: Reservations/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Reservation reservation = db.Reservations.Find(id);
        //    if (reservation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", reservation.ClassID);
        //    ViewBag.GymID = new SelectList(db.GymMembers, "GymID", "FirstName", reservation.GymID);
        //    return View(reservation);
        //}

        //// POST: Reservations/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ReservationID,GymID,ClassID")] Reservation reservation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(reservation).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", reservation.ClassID);
        //    ViewBag.GymID = new SelectList(db.GymMembers, "GymID", "FirstName", reservation.GymID);
        //    return View(reservation);
        //}
        #endregion


        // GET: Reservations/Delete/5
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
