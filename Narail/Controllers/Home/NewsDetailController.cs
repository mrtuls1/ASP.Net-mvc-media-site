using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class NewsDetailController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();


        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Index(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            News news = db.News.Find(Id);
            return View(news);
        }


    }
}