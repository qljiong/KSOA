using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSOA.Business;

namespace KSOA.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            ViewBag.name = new CustomerLogic().test();
            return View();
        }

    }
}
