using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGOrganicos.Data;

namespace TGOrganicos.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataLinq db = new DataLinq();
            
            return View(db.Produtos.Take(4).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}