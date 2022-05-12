using Narail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Narail.Controllers.Admin
{
    [Authorize]
    [ValidateInput(false)]
    public class SettingsController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        //List<Settings> news = null;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GeneralSettings()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }

        [HttpPost]
        public ActionResult GeneralSettings(Settings settings)
        {
            if (settings != null)
            {
                var changeSettings = db.Settings.Find(1);
                changeSettings.SiteHeader = settings.SiteHeader;
                changeSettings.SiteDescription = settings.SiteDescription;
                changeSettings.SiteAcces = settings.SiteAcces;
            }
            db.SaveChanges();
            return RedirectToAction("GeneralSettings", "Settings");
        }

        [HttpGet]
        public ActionResult ContactSettings()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }

        [HttpPost]
       
        public ActionResult ContactSettings(Settings settings, HttpPostedFileBase File)
        {
            if (settings != null)
            {
                var changeSettings = db.Settings.Find(1);
                changeSettings.ContactAdress = settings.ContactAdress;
                changeSettings.ContactPhone=settings.ContactPhone;
                changeSettings.ContactEmail = settings.ContactEmail;
                changeSettings.AboutImage = settings.AboutImage;
                changeSettings.AboutText = settings.AboutText;
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(600, 600, false, false);
                    string tamyol = "~/Content/images/other/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    changeSettings.AboutImage = "/Content/images/other/" + uzanti;
                }
            }

            db.SaveChanges();
            return RedirectToAction("ContactSettings", "Settings");
        }

        [HttpGet]
        
        public ActionResult SocialMedia()
        {
            
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }

        [HttpPost]
        
        public ActionResult SocialMedia(Settings settings)
        {
            if (settings != null)
            {
                var changeSettings = db.Settings.Find(1);
                changeSettings.FacebookLink = settings.FacebookLink;
                changeSettings.InstagramLink = settings.InstagramLink;
                changeSettings.TwitterLink = settings.TwitterLink;
                changeSettings.Linledin= settings.Linledin;
                changeSettings.YoutubeLink = settings.YoutubeLink;

            }
            db.SaveChanges();
            return RedirectToAction("SocialMedia", "Settings");
        }



        public ActionResult Youtube()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
        [HttpPost]
        public ActionResult Youtube(Settings settings)
        {
            if (settings != null)
            {
                var changeSettings = db.Settings.Find(1);
                changeSettings.YoutubeLiveLink = settings.YoutubeLiveLink;
                
            }
            db.SaveChanges();
            return RedirectToAction("Youtube", "Settings");
        }
        public ActionResult CompanySettings()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }
        [HttpPost]
        public ActionResult CompanySettings(Settings settings, HttpPostedFileBase File, HttpPostedFileBase File2, HttpPostedFileBase File3)
        {
            if (settings != null)
            {
                var changeSettings = db.Settings.Find(1);
                changeSettings.CompanyName = settings.CompanyName;
                changeSettings.CompanySlogan = settings.CompanySlogan;
                changeSettings.FounderName1 = settings.FounderName1;
                changeSettings.FounderName2 = settings.FounderName2;
                
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                     img.Resize(250, 50, false, false);
                    string tamyol = "~/Content/images/other/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    changeSettings.CompanyLogo = "/Content/images/other/" + uzanti;
                }
                if (File2 != null)
                {
                    FileInfo fileinfo = new FileInfo(File2.FileName);
                    WebImage img = new WebImage(File2.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(75, 75, false, false);
                    string tamyol = "~/Content/images/other/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    changeSettings.FounderImage1 = "/Content/images/other/" + uzanti;
                }
                if (File3 != null)
                {
                    FileInfo fileinfo = new FileInfo(File3.FileName);
                    WebImage img = new WebImage(File3.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(75, 75, false, false);
                    string tamyol = "~/Content/images/other/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    changeSettings.FounderImage2 = "/Content/images/other/" + uzanti;
                }
            }

            db.SaveChanges();
            return RedirectToAction("CompanySettings", "Settings");
        }

        public ActionResult SeoSettings()
        {
            Settings settings = db.Settings.Find(1);
            return View(settings);
        }

        [HttpPost]
        public ActionResult SeoSettings(Settings settings)
        {
            if (settings != null)
            {
                var changeSettings = db.Settings.Find(1);
                changeSettings.Seo = settings.Seo;

            }
            db.SaveChanges();
            return RedirectToAction("SeoSettings", "Settings");
        }
        public ActionResult MenuSettings()
        {
            return View();
        }
    }
}