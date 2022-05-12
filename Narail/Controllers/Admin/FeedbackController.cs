using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers.Admin
{
    [Authorize]
    public class FeedbackController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        List<Feedback> feedback = null;
        public ActionResult Index()
        {
           
            feedback = db.Feedback.OrderByDescending(m => m.id).ToList();
            return View(feedback);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }

            Feedback feedback = db.Feedback.Find(Id);
            db.Feedback.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            Feedback feedback = db.Feedback.Find(Id);
            return PartialView(feedback);
        }
    }

}