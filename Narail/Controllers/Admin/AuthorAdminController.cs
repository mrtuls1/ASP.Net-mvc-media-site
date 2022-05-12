
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
    public class AuthorAdminController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        List<Author> author = null;
        public ActionResult Index()
        {
            author = db.Author.OrderByDescending(m => m.id).ToList();
            return View(author);

        }

        public ActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author author, HttpPostedFileBase File)
        {
            var authorExist = db.Author.Any(m => m.Email == author.Email);

            if (authorExist == false)
            {
                author.AddedDate = DateTime.Now;
                author.AddedBy = "Admin";
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(225, 180, false, false);
                    string tamyol = "~/Content/images/users/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    author.Image = "/Content/images/users/" + uzanti;
                }
                db.Author.Add(author);
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

            Author author = db.Author.Find(Id);
            db.Author.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null || Id==0)
            {
                return HttpNotFound();
            }
            Author author = db.Author.Find(Id);
            return PartialView(author);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            Author author = db.Author.Find(Id);
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author, HttpPostedFileBase File)
        {
            if (author != null)
            {
                db.Entry(author).State = System.Data.Entity.EntityState.Modified;
                db.Entry(author).Property(m => m.AddedBy).IsModified = false;
                db.Entry(author).Property(m => m.AddedDate).IsModified = false;
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(225, 180, false, false);
                    string tamyol = "~/Content/images/users/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    author.Image = "/Content/images/users/" + uzanti;
                }
                else
                {
                    db.Entry(author).Property(m => m.Image).IsModified = false;
                }
                author.ModifyBy = "Admin";
                author.ModifyDate = DateTime.Now;
            }
            db.SaveChanges();           
            return RedirectToAction("Index","AuthorAdmin");
        }

    }
}