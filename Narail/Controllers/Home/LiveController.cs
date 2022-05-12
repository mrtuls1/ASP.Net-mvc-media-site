using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers.Home
{

    [ValidateInput(false)]
    public class LiveController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        public ActionResult Index()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
    }
}