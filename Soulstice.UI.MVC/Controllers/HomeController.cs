using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Soulstice.DATA.EF;
using Soulstice.UI.MVC.Models;
using System.Net;
using System.Net.Mail;
using System;

namespace Soulstice.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        SoulsticeEntities db = new SoulsticeEntities();

        [HttpGet]
        public ActionResult Index()
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
        public ActionResult Index([Bind(Include = "ReservationID,GymID,ClassID,DateSubmitted")] Reservation reservation)
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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "This class had reached the maximum number of particpants for this class. Please choose another one.";
                }

              
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", reservation.ClassID);

            return View(reservation);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }
            string message = $"You have recieved an email from {cvm.Name} with a subject of {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: </br> {cvm.Message}";

            MailMessage mm = new MailMessage("admin@coderjaz.com", "jasmyne.boggs@outlook.com", cvm.Subject, message);

            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            mm.ReplyToList.Add(cvm.Email);

            SmtpClient client = new SmtpClient("mail.coderjaz.com");

            client.Credentials = new NetworkCredential("admin@coderjaz.com", "Kw_06391");

            try
            {
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.CustomerMessage = "We are sorry. Your request could not be completed at this time. Please try again later. Error Message: <br/> " + ex.StackTrace;
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }
    }
}
