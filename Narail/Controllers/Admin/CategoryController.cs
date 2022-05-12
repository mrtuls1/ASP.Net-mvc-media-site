
using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers.Admin
{
   
    public class CategoryController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        List<NewsCategory> categories = null;
        [Authorize]
        public ActionResult Index(int? id)
        {
            categories = db.NewsCategory.OrderByDescending(m => m.id).ToList();
            return View(categories);
        }
        [Authorize]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }

            NewsCategory category = db.NewsCategory.Find(Id);
            db.NewsCategory.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Create(NewsCategory category)
        {
            var categoryExist = db.NewsCategory.Any(m => m.id == category.id);

            if (categoryExist == false)
            {
              
                db.NewsCategory.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult LayoutIndex()
        {
            categories = db.NewsCategory.OrderByDescending(m => m.id).ToList();
            return View(categories);
        }

    }
}