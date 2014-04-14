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

        #region 日报部分
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
        /// 删除工作报告信息
        /// </summary>
        /// <returns></returns>
        public JsonResult DelDaily()
        {
            String[] strids = Request["ids"].Split(',');

            int[] arr2 = new int[strids.Length];   //用来存放将字符串转换成int[] 
            for (int i = 0; i < strids.Length; i++)
            {
                arr2[i] = int.Parse(strids[i]);
            }
            new Work_NoteLogic().DelDaily(arr2);

            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 周报部分
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
        #endregion

        #region 月报部分
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
        #endregion

        #region 公告部分
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
        /// 提交编辑公告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditNotice(FormCollection form)
        {
            int id = Convert.ToInt32(form["ntid"]);
            if (form.Count != 0)
            {
                Work_Notice wn = new Work_Notice();
                wn.NTitle = form["WTitle"];
                wn.NContent = form["WConetent"];
                wn.Nlevel = 1;//form["Nlevel"];
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Work_NoticeLogic().EditNotice(wn, aks, id))
                {
                    ViewBag.msg = "修改成功";
                }
                else
                {
                    ViewBag.msg = "修改失败";
                }
            }
            return EditNotice(id);
        }
        /// <summary>
        /// 删除notice
        /// </summary>
        /// <returns></returns>
        public JsonResult Delnotice()
        {
            String[] strids = Request["ids"].Split(',');

            int[] arr2 = new int[strids.Length];   //用来存放将字符串转换成int[] 
            for (int i = 0; i < strids.Length; i++)
            {
                arr2[i] = int.Parse(strids[i]);
            }
            new Work_NoticeLogic().Delnotice(arr2);

            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 项目进度部分
        /// <summary>
        /// 项目进度管理
        /// </summary>
        /// <returns></returns>
        public ActionResult WorkSchedule()
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Work_Schedule> list = new Work_ScheduleLogic().GetScheduleList(this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../DailyWork/WorkSchedule", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        /// <summary>
        /// 添加项目进度
        /// </summary>
        /// <returns></returns>
        public ActionResult AddWorkSchedule(FormCollection form)
        {
            if (form.Count != 0)
            {
                Work_Schedule wn = new Work_Schedule();
                wn.ItemName = form["ItemName"];
                wn.ItemLaunchTime =Convert.ToDateTime(form["ItemLaunchTime"]);
                wn.ItemIntro = form["ItemIntro"]; 
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Work_ScheduleLogic().AddSchedule(wn, aks))
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
        /// 编辑项目进度条目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditSchedule(int id)
        {
            Work_Schedule wn = new Work_ScheduleLogic().GetScheduleModel(id);
            if (wn == null)
            {
                wn = new Work_Schedule();
            }
            return View(wn);
        }
        [HttpPost]
        public ActionResult EditSchedule(FormCollection form)
        {
            int id = Convert.ToInt32(form["ScheduleID"]);
            if (form.Count != 0)
            {
                Work_Schedule wn = new Work_Schedule();
                wn.ItemName = form["ItemName"];
                wn.ItemLaunchTime = Convert.ToDateTime(form["ItemLaunchTime"]);
                wn.ItemIntro = form["ItemIntro"];
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Work_ScheduleLogic().EditSchedule(wn, aks, id))
                {
                    ViewBag.msg = "编辑成功";
                }
                else
                {
                    ViewBag.msg = "编辑失败";
                }
            }
            return EditSchedule(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public JsonResult Delschedule()
        {
            String[] strids = Request["ids"].Split(',');

            int[] arr2 = new int[strids.Length];   //用来存放将字符串转换成int[] 
            for (int i = 0; i < strids.Length; i++)
            {
                arr2[i] = int.Parse(strids[i]);
            }
            new Work_ScheduleLogic().Delschedule(arr2);

            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
