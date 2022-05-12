using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers.Home
{
    public class CategoryPageController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        
        int pageLenght = 10;
        [HttpGet]
        public ActionResult Index(int? pageNo)
        {
            List<News> news = null;
            
         
            
            if (!pageNo.HasValue)
            {
                news = db.News.OrderByDescending(m => m.id).Take(pageLenght).ToList();
                Session["page"] = RouteData.Values["id"];

            }
            else
            {
                int pageIndex = pageLenght * pageNo.Value;
                news = db.News.OrderByDescending(m => m.id).Skip(pageIndex).Take(pageLenght).ToList();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_News",news);
            }
            return View(news);
        }

    }
}