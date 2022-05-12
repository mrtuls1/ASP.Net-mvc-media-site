using Narail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Narail.Controllers
{
    [Authorize]
    public class NewsAddController : Controller
    {

        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        List<News> news = null;

        public ActionResult Index()
        {
            news = db.News.OrderByDescending(m => m.id).ToList();
            return View(news);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> items = (from item in db.NewsCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = item.name,
                                                 Value = item.id.ToString()
                                             }).ToList();
            ViewBag.category = items;
            return View();
        }


        [HttpPost]
        [AllowAnonymous] 
        [ValidateInput(false)]
        public ActionResult Create(News news, HttpPostedFileBase File)
        {
            var authorExist = db.Author.Any(m => m.id == news.id);

            if (authorExist == false)
            {
                var ctg = db.NewsCategory.Where(n => n.id == news.NewsCategory.id).FirstOrDefault();
                news.NewsCategory = ctg;
                news.AddedDate = DateTime.Now;
                news.AddedBy = "Admin";
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    string tamyol = "~/Content/images/users/" + uzanti;
                    img.Resize(1280, 720, false, false);
                    img.Save(Server.MapPath(tamyol));
                    news.Image = "/Content/images/users/" + uzanti;
                }
                db.News.Add(news);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }

            News news = db.News.Find(Id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            News news = db.News.Find(Id);
            return PartialView(news);
        }

        public ActionResult Edit(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return HttpNotFound();

            }

            List<SelectListItem> items = (from item in db.NewsCategory.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.name,
                                              Value = item.id.ToString()
                                          }).ToList();
            ViewBag.category = items;

            News news = db.News.Find(Id);
            return View(news);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Edit(News news, HttpPostedFileBase File)
        {
            if (news != null)
            {
                var changeNews = db.News.Find(news.id);
                changeNews.Header = news.Header;
                changeNews.Subject = news.Subject;
                changeNews.Active = news.Active;
                changeNews.Contents = news.Contents;
                var changeCategory = db.NewsCategory.Where(m=> m.id == news.NewsCategory.id).FirstOrDefault();
                changeNews.Category = changeCategory.id;
                //db.Entry(news).State = System.Data.Entity.EntityState.Modified;
               // db.Entry(news).Property(m => m.AddedBy).IsModified = false;
               // db.Entry(news).Property(m => m.AddedDate).IsModified = false;
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(1280, 720, false, false);
                    string tamyol = "~/Content/images/news/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    changeNews.Image = "/Content/images/news/" + uzanti;
                }
                else
                {
                    changeNews.Image = news.Image;
                }

                
                news.ModifyBy = "Admin";
                news.ModifyDate = DateTime.Now;

            }
            db.SaveChanges();
            return RedirectToAction("Index", "NewsAdd");
        }
    }
}