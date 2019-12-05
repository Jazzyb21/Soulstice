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
    public class InstructorsController : Controller
    {
        private SoulsticeEntities db = new SoulsticeEntities();

        // GET: Instructors
        public ActionResult Index()
        {
            return View(db.Instructors.ToList());
        }

        // GET: Instructors/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Instructor instructor = db.Instructors.Find(id);
        //    if (instructor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(instructor);
        //}

        // GET: Instructors/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,FirstName,LastName,Specialty")] Instructor instructor, HttpPostedFileBase instructorPic)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                //use a default image if none is provided
                string imgName = "default.jpg";

                if (instructorPic != null) //your httpPostedFileBase Object that should be added to the action != null
                {
                    imgName = instructorPic.FileName;

                    string ext = imgName.Substring(imgName.LastIndexOf('.'));

                    string[] goodExts = { ".jpg", ".jpeg", "gif", ".png" };

                    if (goodExts.Contains(ext.ToLower())) /*&& (instructorPic.ContentLength <= 4194304)) *///4mb max asp.net
                    {
                        imgName = Guid.NewGuid() + ext;

                        instructorPic.SaveAs(Server.MapPath("~/Content/img/" + imgName));

                    }
                    else
                    {
                        imgName = "default.jpg";
                    }
                }

                instructor.InstructorPic = imgName;

                #endregion
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }

        // GET: Instructors/Edit/5
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult Edit([Bind(Include = "InstructorID,FirstName,LastName,Specialty")] Instructor instructor, HttpPostedFileBase instructorPic)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                //use a default image if none is provided
                string imgName = "default.jpg";

                if (instructorPic != null) //your httpPostedFileBase Object that should be added to the action != null
                {
                    imgName = instructorPic.FileName;

                    string ext = imgName.Substring(imgName.LastIndexOf('.'));

                    string[] goodExts = { ".jpg", ".jpeg", "gif", ".png" };

                    if (goodExts.Contains(ext.ToLower())) /*&& (instructorPic.ContentLength <= 4194304)) *///4mb max asp.net
                    {
                        imgName = Guid.NewGuid() + ext;

                        instructorPic.SaveAs(Server.MapPath("~/Content/img/" + imgName));

                    }
                    else
                    {
                        imgName = "default.jpg";
                    }
                }

                instructor.InstructorPic = imgName;

                #endregion

                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
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
