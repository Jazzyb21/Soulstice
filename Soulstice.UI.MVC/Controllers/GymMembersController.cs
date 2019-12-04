using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Soulstice.DATA.EF;

namespace Soulstice.UI.MVC.Controllers
{
    public class GymMembersController : Controller
    {
        private SoulsticeEntities db = new SoulsticeEntities();

        // GET: GymMembers
        [Authorize]
        public ActionResult Index()
        {
            var gymMembers = db.GymMembers.Include(g => g.AspNetUser);
            return View(gymMembers.ToList());
        }

        // GET: GymMembers/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymMember gymMember = db.GymMembers.Find(id);
            if (gymMember == null)
            {
                return HttpNotFound();
            }
            return View(gymMember);
        }

        // GET: GymMembers/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.GymID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: GymMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult Create([Bind(Include = "GymID,FirstName,LastName,City,State,Phone,GoalDescription,ProfilePic")] GymMember gymMember)
        {
            if (ModelState.IsValid)
            {
                db.GymMembers.Add(gymMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GymID = new SelectList(db.AspNetUsers, "Id", "Email", gymMember.GymID);
            return View(gymMember);
        }

        // GET: GymMembers/Edit/5
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymMember gymMember = db.GymMembers.Find(id);
            if (gymMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.GymID = new SelectList(db.AspNetUsers, "Id", "Email", gymMember.GymID);
            return View(gymMember);
        }

        // POST: GymMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult Edit([Bind(Include = "GymID,FirstName,LastName,City,State,Phone,GoalDescription,ProfilePic")] GymMember gymMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gymMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GymID = new SelectList(db.AspNetUsers, "Id", "Email", gymMember.GymID);
            return View(gymMember);
        }

        // GET: GymMembers/Delete/5
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymMember gymMember = db.GymMembers.Find(id);
            if (gymMember == null)
            {
                return HttpNotFound();
            }
            return View(gymMember);
        }

        // POST: GymMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            GymMember gymMember = db.GymMembers.Find(id);
            db.GymMembers.Remove(gymMember);
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
