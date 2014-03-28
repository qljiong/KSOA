using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSOA.Business;

namespace KSOAWeb.Controllers
{
    public class HomeController : BasePageController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ExplorerComplainInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExplorerComplainInfo(FormCollection form)
        {
            return View();
        }
    }
}
