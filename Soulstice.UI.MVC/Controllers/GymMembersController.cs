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
using Soulstice.UI.MVC.Models;

namespace Soulstice.UI.MVC.Controllers
{
   
    public class GymMembersController : Controller
    {
        private SoulsticeEntities db = new SoulsticeEntities();

        // GET: GymMembers
        [Authorize]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Index()
        {
            var gymMembers = db.GymMembers.Include(g => g.AspNetUser);
            return View(gymMembers.ToList());
        }

        // GET: GymMembers/Details/5
        [Authorize(Roles = "Admin, Staff")]
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


        #region Create Action
        //// GET: GymMembers/Create
        //public ActionResult Create()
        //{
        //    ViewBag.GymID = new SelectList(db.AspNetUsers, "Id", "Email");
        //    return View();
        //}

        //// POST: GymMembers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "GymID,FirstName,LastName,City,State,Phone,GoalDescription,ProfilePic")] GymMember gymMember, HttpPostedFileBase profilePic, RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };


        //        #region Img Upload

        //        string imgName = "default.jpg";

        //        if (profilePic != null)
        //        {
        //            imgName = profilePic.FileName;

        //            string ext = imgName.Substring(imgName.LastIndexOf('.'));

        //            string[] goodExts = { ".jpg", ".jpeg", "gif", ".png" };

        //            if (goodExts.Contains(ext.ToLower()))
        //            {
        //                imgName = Guid.NewGuid() + ext;

        //                profilePic.SaveAs(Server.MapPath("~/Content/img/" + imgName));
        //            }
        //            else
        //            {
        //                imgName = "default.jpg";
        //            }
        //        }

        //        #endregion

        //            #region Custom User Details (GymMember Table)

        //            GymMember newGymMember = new GymMember();
        //            newGymMember.GymID = user.Id;
        //            newGymMember.FirstName = model.FirstName;
        //            newGymMember.LastName = model.LastName;
        //            newGymMember.City = model.City;
        //            newGymMember.State = model.State;
        //            newGymMember.Phone = model.Phone;
        //            newGymMember.GoalDescription = model.GoalDescription;
        //            newGymMember.ProfilePic = imgName;


        //            SoulsticeEntities db = new SoulsticeEntities();
        //            db.GymMembers.Add(newGymMember);
        //            db.SaveChanges();


        //            #endregion

        //     }

        //    ViewBag.GymID = new SelectList(db.AspNetUsers, "Id", "Email", gymMember.GymID);
        //    return View(gymMember);
        //}
        #endregion


        // GET: GymMembers/Edit/5

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

            //gymMember.GymID = User.Identity.GetUserId();

            if (gymMember.GymID == id)
            {
                return View(gymMember);
            }


            return View();
        }

        // POST: GymMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GymID,FirstName,LastName,City,State,Phone,GoalDescription,ProfilePic")] GymMember gymMember, HttpPostedFileBase profilePic)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                //use a default image if none is provided
                string imgName = "default.jpg";

                if (profilePic != null) //your httpPostedFileBase Object that should be added to the action != null
                {
                    imgName = profilePic.FileName;

                    string ext = imgName.Substring(imgName.LastIndexOf('.'));

                    string[] goodExts = { ".jpg", ".jpeg", "gif", ".png" };

                    if (goodExts.Contains(ext.ToLower())) /*&& (profilePic.ContentLength <= 4194304)) *///4mb max asp.net
                    {
                        imgName = Guid.NewGuid() + ext;

                        profilePic.SaveAs(Server.MapPath("~/Content/img/" + imgName));

                    }
                    else
                    {
                        imgName = "default.jpg";
                    }
                }

                gymMember.ProfilePic = imgName;

                #endregion

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
