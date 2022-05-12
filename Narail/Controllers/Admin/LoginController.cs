using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Narail.Controllers
{
    public class LoginController : Controller
    {

        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        public ActionResult Index(string Email, string Password)
        {
            if (Email == null)
            {
                return View();
            }
            else
            {
                var user = db.Author.FirstOrDefault(m => m.Email == Email && m.Password == Password);
                if (user != null)
                {
                    user.LastEntry =user.EntryDate;
                    user.EntryDate = DateTime.Now; 
                    Session["User"] = user.id;
                    Session["NameSurname"] = user.NameSurname;
                    Session["Email"] = user.Email;
                    Session["Image"] = user.Image;
                    Session["LastEntry"] = user.LastEntry;
                    if (user.Role == "Admin")
                    {
                        Session["Admin"] = "Admin";
                    }
                    FormsAuthentication.SetAuthCookie(user.NameSurname,false);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Panel");
                }
                else
                {
                    ViewBag.Error = "Kullanıcı Adı veya Şifre Hatalı";
                    return View();

                }
            }
        }

        public ActionResult Logout(int? id)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}