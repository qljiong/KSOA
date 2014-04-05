using KSOA.Business;
using KSOA.Common;
using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSOAWeb.Controllers
{
    public class DailyWorkController : BasePageController
    {

        #region 分页功能
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int group_id;
        protected string keywords = string.Empty;

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("user_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #endregion

        /// <summary>
        /// 日报管理
        /// </summary>
        /// <returns></returns>
        public ActionResult DailyReport()
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Work_Note> list = new Work_NoteLogic().GetDailyList(KSOAEnum.NoteType.D, this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../admin/DailyReport", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        /// <summary>
        /// 添加日报
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDaily(FormCollection form)
        {
            if (form.Count != 0)
            {
                Work_Note wn = new Work_Note();
                wn.WTitle = form["WTitle"];
                wn.WConetent = form["WConetent"];
                wn.WType = KSOAEnum.NoteType.D.ToString();
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Work_NoteLogic().AddWorkNote(wn, aks))
                {
                    ViewBag.msg = "添加成功";
                }
                else
                {
                    ViewBag.msg = "添加失败";
                }
            }

            return View();
        }

        /// <summary>
        /// 编辑日报(根据ID读取对象)
        /// </summary>
        /// <returns></returns>
        public ActionResult EditDaily(int id)
        {
            Work_Note wn = new Work_NoteLogic().GetWork_NoteModel(id);
            if (wn == null)
            {
                wn = new Work_Note();
            }
            else
            {
                //标记为已阅
                new Work_NoteLogic().UpdateMark(id);
            }
            return View(wn);
        }
        /// <summary>
        /// 周报管理
        /// </summary>
        /// <returns></returns>
        public ActionResult WeekReport()
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Work_Note> list = new Work_NoteLogic().GetDailyList(KSOAEnum.NoteType.W, this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../admin/DailyReport", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        /// <summary>
        /// 添加周报
        /// </summary>
        /// <returns></returns>
        public ActionResult AddWeek(FormCollection form)
        {
            if (form.Count != 0)
            {
                Work_Note wn = new Work_Note();
                wn.WTitle = form["WTitle"];
                wn.WConetent = form["WConetent"];
                wn.WType = KSOAEnum.NoteType.W.ToString();
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Work_NoteLogic().AddWorkNote(wn, aks))
                {
                    ViewBag.msg = "添加成功";
                }
                else
                {
                    ViewBag.msg = "添加失败";
                }
            }

            return View();
        }
        /// <summary>
        /// 月报管理
        /// </summary>
        /// <returns></returns>
        public ActionResult MonthReport()
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Work_Note> list = new Work_NoteLogic().GetDailyList(KSOAEnum.NoteType.M, this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../admin/DailyReport", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        /// <summary>
        /// 添加月报
        /// </summary>
        /// <returns></returns>
        public ActionResult AddMonth(FormCollection form)
        {
            if (form.Count != 0)
            {
                Work_Note wn = new Work_Note();
                wn.WTitle = form["WTitle"];
                wn.WConetent = form["WConetent"];
                wn.WType = KSOAEnum.NoteType.M.ToString();
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Work_NoteLogic().AddWorkNote(wn, aks))
                {
                    ViewBag.msg = "添加成功";
                }
                else
                {
                    ViewBag.msg = "添加失败";
                }
            }

            return View();
        }
        /// <summary>
        /// 公告管理
        /// </summary>
        /// <returns></returns>
        public ActionResult NoticeReport()
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Work_Notice> list = new Work_NoticeLogic().GetNoticeList(this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../admin/DailyReport", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        /// <summary>
        /// 添加公告
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNotice(FormCollection form)
        {
            if (form.Count != 0)
            {
                Work_Notice wn = new Work_Notice();
                wn.NTitle = form["WTitle"];
                wn.NContent = form["WConetent"];
                wn.Nlevel = 1;//form["Nlevel"];
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Work_NoticeLogic().AddNotice(wn, aks))
                {
                    ViewBag.msg = "添加成功";
                }
                else
                {
                    ViewBag.msg = "添加失败";
                }
            }

            return View();
        }

        /// <summary>
        /// 编辑公告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditNotice(int id)
        {
            Work_Notice wn = new Work_NoticeLogic().GetNoticeModel(id);
            if (wn == null)
            {
                wn = new Work_Notice();
            }
            return View(wn);
        }
        /// <summary>
        /// 项目进度管理
        /// </summary>
        /// <returns></returns>
        public ActionResult WorkSchedule()
        {
            return View();
        }
        /// <summary>
        /// 添加项目进度
        /// </summary>
        /// <returns></returns>
        public ActionResult AddWorkSchedule()
        {
            return View();
        }
    }
}
