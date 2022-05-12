using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers.Admin
{
    [Authorize]
    public class PanelController : Controller
    {
        KarapinarMedyaEntities1 db = new KarapinarMedyaEntities1();
        public ActionResult Index(int? id)
        {
           
            return View();
        }
    }
}