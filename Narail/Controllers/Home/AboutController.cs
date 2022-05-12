using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers
{
   
    public class AboutController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        public ActionResult Index()
        {
            ViewBag.Title = "Karapınar Medya | Hakkımızda";
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
    }
}