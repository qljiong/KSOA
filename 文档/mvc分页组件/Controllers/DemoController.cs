﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Webdiyer.MvcPagerDemo.Models;
using Webdiyer.WebControls.Mvc;

namespace Webdiyer.MvcPagerDemo.Controllers
{
    public class DemoController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        #region Html Pager

        public ViewResult Basic(int id = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8));
            }
        }

        public ViewResult QueryString(int pageIndex = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(pageIndex, 8));
            }
        }

        public ActionResult CustomRouting(int pageindex = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(pageindex, 8));
            }
        }
        

        public ActionResult UrlParams(int id = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8));
            }
        }

        public ActionResult PageIndexBox(int id = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8));
            }
        }

        public ActionResult ApplyCSS(int id = 1)
        {
            using (var db = new DataContext())
            {
                return View(new PagedList<string>(new string[0], id, 1, 80));
            }
        }

        public ActionResult StoredProcedure(int id = 1)
        {
            using (var db = new DataContext())
            {
                var pageSize = 8;
                var startIndex = (id - 1)*pageSize + 1;
                SqlParameter prmStart = new SqlParameter("@startIndex", startIndex);
                SqlParameter prmEnd = new SqlParameter("@endIndex", startIndex + pageSize);
                SqlParameter prmTotal = new SqlParameter("@totalItems", SqlDbType.Int);
                prmTotal.Direction = ParameterDirection.Output;

                var articles =
                    db.Database.SqlQuery<Article>(
                        "exec [USP_GetPagedArticleList] @startIndex,@endIndex,@totalItems out", prmStart, prmEnd,
                        prmTotal).ToList();
                var totalItems = (int) prmTotal.Value;
                var model = new PagedList<Article>(articles, id, pageSize, totalItems);
                return View(model);
            }
        }

        public ActionResult CustomInfo(int id = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8));
            }
        }


        public ActionResult MultipleMvcPagers(int id = 1,int pageIndex=1)
        {
            using (var db = new DataContext())
            {
                var pageSize = 5;
                List<Tuple<int,string,string>> usrs=new List<Tuple<int, string, string>>();
                var startIndex = (pageIndex - 1) * pageSize + 1;
                for (int i = startIndex; i < pageSize + startIndex; i++)
                {
                    usrs.Add(new Tuple<int, string, string>(i, "会员" + i, "住址" + i));
                }
                
                CustomViewModel model=new CustomViewModel();
                model.Users = new PagedList<Tuple<int, string, string>>(usrs, pageIndex, pageSize, 89);
                model.Articles = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, pageSize);
                return View(model);
            }
        }

        public ActionResult Search(int id = 1, string kword = null)
        {
            using (var db = new DataContext())
            {
                var query = db.Articles.AsQueryable();
                if (!string.IsNullOrWhiteSpace(kword))
                    query = query.Where(a => a.Title.Contains(kword));
                var model = query.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                return View(model);
            }
        }

        public ActionResult ContentPaging(int id, int pageIndex = 1)
        {
            using (var db = new DataContext())
            {
                var art = db.Articles.SingleOrDefault(a => a.ID == id); //获取演示用的长文章
                if (art != null)
                {
                    return View(new PagedArticle(art, pageIndex));
                }
                return new HttpNotFoundResult("找不到指定的文章");
            }
        }

        public ActionResult FirstPageUrl(int id = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8));
            }
        }

        public ActionResult PageSize(int pagesize = 10, int pageindex = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(pageindex, pagesize));
            }
        }

        public ViewResult CombinedMode(int id = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8));
            }
        }

        #endregion

        #region Ajax Pager

        public ActionResult AjaxPaging(int id = 1)
        {
            using (var db = new DataContext())
            {
                var model = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                    return PartialView("_ArticleList", model);
                return View(model);
            }
        }

        public ActionResult AjaxEvents(int id = 1)
        {
            using (var db = new DataContext())
            {
                if (id == 2)
                {
                    Response.StatusCode = 500;
                    return Content("测试用的服务器端错误信息");
                }
                //throw new ApplicationException("测试用的服务器端错误信息");
                var model = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                    return PartialView("_AjaxEvents", model);
                return View(model);
            }
        }

        public ActionResult AjaxInitData(int id = 1)
        {
            using (var db = new DataContext())
            {
                var model = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                    return PartialView("_ArticleList", model);
                return View(model);
            }
        }

        public ActionResult AjaxLoading(int id = 1)
        {
            using (var db = new DataContext())
            {
                var model = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                {
                    System.Threading.Thread.Sleep(2000);
                    return PartialView("_AjaxLoading", model);
                }
                return View(model);
            }
        }

        public ActionResult AjaxPartialLoading(int id = 1)
        {
            using (var db = new DataContext())
            {
                return View(db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8));
            }
        }

        public ActionResult MultipleAjaxPagers(int id = 1,int pageIndex=1)
        {
            using (var db = new DataContext())
            {
                var pageSize = 5;
                List<Tuple<int, string, string>> usrs = new List<Tuple<int, string, string>>();
                var startIndex = (pageIndex - 1) * pageSize + 1;
                for (int i = startIndex; i < pageSize + startIndex; i++)
                {
                    usrs.Add(new Tuple<int, string, string>(i, "会员" + i, "住址" + i));
                }

                CustomViewModel model = new CustomViewModel();
                model.Users = new PagedList<Tuple<int, string, string>>(usrs, pageIndex, pageSize, 89);
                model.Articles = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, pageSize);
                return View(model);
            }
            
        }

        public ActionResult AjaxSearchGet(string title, string author, string source, int id = 1)
        {
            return ajaxSearchGetResult(title, author, source, id);
        }

        public ActionResult AjaxSearchHtmlGet(string title, string author, string source, int id = 1)
        {
            return ajaxSearchGetResult(title, author, source, id);
        }

        private ActionResult ajaxSearchGetResult(string title, string author, string source, int id = 1)
        {
            using (var db = new DataContext())
            {
                var qry = db.Articles.AsQueryable();
                if (!string.IsNullOrWhiteSpace(title))
                    qry = qry.Where(a => a.Title.Contains(title));
                if (!string.IsNullOrWhiteSpace(author))
                    qry = qry.Where(a => a.Author.Contains(author));
                if (!string.IsNullOrWhiteSpace(source))
                    qry = qry.Where(a => a.Source.Contains(source));
                var model = qry.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                    return PartialView("_AjaxSearchGet", model);
                return View(model);
            }
        }

        public ActionResult AjaxSearchPost(int id = 1)
        {
            using (var db = new DataContext())
            {
                var model = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                    return PartialView("_AjaxSearchPost", model);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AjaxSearchPost(string title,string author,string source, int id = 1)
        {
            return ajaxSearchPostResult(title, author, source, id);
        }

        [HttpPost]
        public ActionResult AjaxSearchHtmlPost(string title, string author, string source, int id = 1)
        {
            return ajaxSearchPostResult(title, author, source, id);
        }

        private ActionResult ajaxSearchPostResult(string title,string author,string source, int id = 1)
        {
            using (var db = new DataContext())
            {
                var qry = db.Articles.AsQueryable();
                if (!string.IsNullOrWhiteSpace(title))
                    qry = qry.Where(a => a.Title.Contains(title));
                if (!string.IsNullOrWhiteSpace(author))
                    qry = qry.Where(a => a.Author.Contains(author));
                if (!string.IsNullOrWhiteSpace(source))
                    qry = qry.Where(a => a.Source.Contains(source));
                var model = qry.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                    return PartialView("_AjaxSearchPost", model);
                return View(model);
            }
        }

        public ActionResult AjaxSearchHtmlPost(int id = 1)
        {
            using (var db = new DataContext())
            {
                var model = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                    return PartialView("_AjaxSearchPost", model);
                return View(model);
            }
        }


        public ActionResult AjaxDegradation(int id = 1)
        {
            using (var db = new DataContext())
            {
                var model = db.Articles.OrderByDescending(a => a.PubDate).ToPagedList(id, 8);
                if (Request.IsAjaxRequest())
                    return PartialView("_Degradation", model);
                return View(model);
            }
        }

        #endregion

        #region PagedList and ToPagedList method samples

        public ActionResult Delete(int id = 1)
        {
            List<int> list = HttpContext.Cache["TestList"] as List<int>;
            if (list == null)
            {
                list = Enumerable.Range(1, 12).ToList();
                HttpContext.Cache["TestList"] = list;
            }
            return View(list.ToPagedList(id, 5));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection values)
        {
            if (values["resetList"] != null)
            {
                HttpContext.Cache.Remove("TestList");
                return RedirectToAction("Delete");
            }
            var list = HttpContext.Cache["TestList"] as List<int>;
            if (list == null)
                throw new ApplicationException("无法获取缓存的测试数据，请刷新重试");
            int[] delItems = Array.ConvertAll(values["val"].Split(','), i => int.Parse(i));
            list.RemoveAll(delItems.Contains);
            HttpContext.Cache["TestList"] = list;
            return View(list.ToPagedList(id, 5));
        }

        public ActionResult DataRows(int id=1)
        {
            var pageSize = 8;
            var startIndex = (id - 1) * pageSize + 1;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_GetPagedArticleList", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@startIndex",SqlDbType.Int).Value=startIndex;
            cmd.Parameters.Add("@endIndex",SqlDbType.Int).Value=startIndex + pageSize;
            SqlParameter prmTotal = new SqlParameter("@totalItems", SqlDbType.Int);
            prmTotal.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prmTotal);
            SqlDataAdapter adapter=new SqlDataAdapter(cmd);
            DataTable tbl=new DataTable("Articles");
            adapter.Fill(tbl);
            int totalItems = (int) prmTotal.Value; //要分页的总记录数
            //PagedList构造函数
            PagedList<DataRow> arts=new PagedList<DataRow>(tbl.Select(),id,pageSize,totalItems);
            return View(arts);
        }

        public ActionResult IPagedList(int id=1)
        {
            MyPagedList<int> list=new MyPagedList<int>(Enumerable.Range(1,88),id,5);
            return View(list);
        }

        #endregion
    }
}
