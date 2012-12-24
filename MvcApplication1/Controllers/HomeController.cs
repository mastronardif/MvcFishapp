using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            mySGClass1 gg = new mySGClass1();
            gg._path = Server.MapPath("~/App_Data/01RFishheads.xls"); ;
            string sss = gg.MyOpenSheet();
            
            ViewData["Message"] = sss;
            return View();
        }

         [HttpPost]
        public ActionResult Calculate()
        {

            mySGClass1 gg = new mySGClass1();
            gg._path = Server.MapPath("~/App_Data/01RFishheads.xls");

            //string F8_value = Request.Form["F8"];
            string F8_value  = (string.IsNullOrEmpty(Request.Form["F8"])  ?      "1" : Request.Form["F8"]);
            string F9_value  = (string.IsNullOrEmpty(Request.Form["F9"])  ?     "60" : Request.Form["F9"]);
            string F10_value = (string.IsNullOrEmpty(Request.Form["F10"]) ? "300000" : Request.Form["F10"]);

            string results = gg.MyGetResults(F8_value, F9_value, F10_value);

            ViewData["Results"] = results;

            string sss = gg.MyOpenSheet();
            ViewData["Message"] = gg.getInput(); //" the input";
            ViewData["F8"]  = F8_value;
            ViewData["F9"]  = F9_value; //" the input";
            ViewData["F10"] = F10_value;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
