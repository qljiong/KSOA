using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KSOA.Business;
using KSOA.Model;

namespace KSOAWeb.Controllers
{
    public class BasePageController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ////控制器基类验证,是否登录
            if (Session["member"] == null && !System.Web.HttpContext.Current.Request.Path.Contains("login") && !System.Web.HttpContext.Current.Request.Path.Equals("/KSOAWeb/"))
            {
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["keeplogin"];
                if (cookie == null)
                {
                    filterContext.Result = Redirect(String.Format("~/admin/login.html", Request.Url.PathAndQuery));//跳转到登录页
                }
                else
                {
                    Admin_KSCustomer aks = new Admin_KSCustomerLogic().GetCusbyCusName(cookie.Value);
                    Session["member"] = aks;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}