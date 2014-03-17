using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSOA.Business;

namespace KSOAWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.name = new Admin_KSCustomerLogic().test();
            return View();
        }

    }
}
