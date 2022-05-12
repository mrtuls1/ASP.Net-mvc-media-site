using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class ContactController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        public ActionResult Index()
        {
            ViewBag.Title = "Karapınar Medya | İletişim";
            return View();
        }
        public ActionResult Message(string nameSurname, string email,string phone,string subject,string message)
        {
                Feedback feedback = new Feedback();
                feedback.NameSurname = nameSurname;
                feedback.Email = email;
                feedback.Phone = phone;
                feedback.Subject = subject;
                feedback.Message = message;
                feedback.AddedDate = DateTime.Now;
                db.Feedback.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");       
        }

        public ActionResult ContactInformation()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
        public ActionResult SocialMedyaLayout()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }

        public ActionResult SocialMedyaLayout2()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
        public ActionResult ContactLayout()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
        public ActionResult SiteLogo()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
        public ActionResult FooterLayout()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
        public ActionResult Seo()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
    }
}