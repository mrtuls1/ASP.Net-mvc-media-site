using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class HomeController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Karapınar Medya | 2022";
            return View();
        }
        public ActionResult Slider()
        {
            List<News> news = null;
            int pageLenght = 5;
            news = db.News.OrderByDescending(m => m.id).Take(pageLenght).ToList();
            return View(news);
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult Counter()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        
        int pageLenght = 10;
        public ActionResult News(int? pageNo)
        {
            
            List<News> news = null;

            if (!pageNo.HasValue)
            {
                news = db.News.OrderByDescending(m => m.id).Take(pageLenght).ToList();
                
            }
            else 
            {
                int pageIndex = pageLenght * pageNo.Value;
                news= db.News.OrderByDescending(m => m.id).Skip(pageIndex).Take(pageLenght).ToList();
            }
            
            if(Request.IsAjaxRequest())
            {
                return PartialView("_News", news);
            }

            return View(news);
        }
    }
}