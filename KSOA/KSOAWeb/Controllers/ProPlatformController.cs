using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSOAWeb.Controllers
{
    public class ProPlatformController : Controller
    {
       /// <summary>
       /// 动漫版权作品购销
       /// </summary>
       /// <returns></returns>
        public ActionResult PurchaseAndSale()
        {
            return View();
        }
        /// <summary>
        /// 作品商用
        /// </summary>
        /// <returns></returns>
        public ActionResult CommercialOpus()
        {
            return View();
        }
        /// <summary>
        /// 原创组
        /// </summary>
        /// <returns></returns>
        public ActionResult OriginalGroup()
        {
            return View();
        }
    }
}
