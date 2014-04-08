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
    public class ProPlatformController : Controller
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

        #region 作品购销部分
        /// <summary>
        /// 动漫版权作品购销
        /// </summary>
        /// <returns></returns>
        public ActionResult PurchaseAndSale()
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Bank_Opus> list = new Bank_OpusLogic().GetOpusList(KSOAEnum.OpusType.A, this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../ProPlatform/PurchaseAndSale", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        /// <summary>
        /// 选择作品
        /// </summary>
        /// <returns></returns>
        public ActionResult SelOups()
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Bank_Opus> list = new Bank_OpusLogic().GetOpusList(KSOAEnum.OpusType.A, this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../ProPlatform/PurchaseAndSale", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        [HttpPost]
        public ActionResult SelOups(FormCollection form)
        {
            string keyword = form["txtKeywords"];
            KSOAEnum.OpusType otype = form["OpType"] == "B" ? KSOAEnum.OpusType.B : KSOAEnum.OpusType.S;
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Bank_Opus> list = new Bank_OpusLogic().GetOpusList(keyword, otype, this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../ProPlatform/PurchaseAndSale", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        /// <summary>
        /// 添加作品
        /// </summary>
        /// <returns></returns>
        public ActionResult AddOpus(FormCollection form)
        {
            if (form.Count != 0)
            {
                Bank_Opus wnote = new Bank_Opus();
                wnote.OpTitle = form["OpTitle"];
                wnote.OpBeginTime = Convert.ToDateTime(form["OpBeginTime"]);
                wnote.OpAuthor = form["OpAuthor"];
                wnote.OpType = form["OpType"];
                wnote.AddTime = DateTime.Now;
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Bank_OpusLogic().AddOpus(wnote, aks))
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
        /// 编辑作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditOpus(int id)
        {
            Bank_Opus wn = new Bank_OpusLogic().GetOpusModel(id);
            if (wn == null)
            {
                wn = new Bank_Opus();
            }
            return View(wn);
        }
        /// <summary>
        /// 提交编辑作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditOpus(FormCollection form)
        {
            int id = Convert.ToInt32(form["ntid"]);
            if (form.Count != 0)
            {
                Bank_Opus wnote = new Bank_Opus();
                wnote.OpTitle = form["OpTitle"];
                wnote.OpBeginTime = Convert.ToDateTime(form["OpBeginTime"]);
                wnote.OpAuthor = form["OpAuthor"];
                wnote.OpType = form["OpType"];
                wnote.AddTime = DateTime.Now;
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Bank_OpusLogic().EditOpus(wnote, aks, id))
                {
                    ViewBag.msg = "修改成功";
                }
                else
                {
                    ViewBag.msg = "修改失败";
                }
            }
            return EditOpus(id);
        }
        /// <summary>
        /// 删除作品
        /// </summary>
        /// <returns></returns>
        public JsonResult DelOpus()
        {
            String[] strids = Request["ids"].Split(',');

            int[] arr2 = new int[strids.Length];   //用来存放将字符串转换成int[] 
            for (int i = 0; i < strids.Length; i++)
            {
                arr2[i] = int.Parse(strids[i]);
            }
            new Bank_OpusLogic().DelOpus(arr2);

            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 作品商用部分
        /// <summary>
        /// 添加作品商用信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCommercial(int id)
        {
            Bank_Opus wn = new Bank_OpusLogic().GetOpusModel(id);
            if (wn == null)
            {
                wn = new Bank_Opus();
            }
            return View(wn);
        }
        [HttpPost]
        public ActionResult AddCommercial(FormCollection form)
        {
            int OpusID = -1;
            if (form.Count != 0)
            {
                OpusID = Convert.ToInt32(form["OpusID"]);
                Bank_CommercialOpus wnote = new Bank_CommercialOpus();
                wnote.CompanyName = form["CompanyName"];
                wnote.ChannelAddress = form["ChannelAddress"];
                wnote.CpAddress = form["CpAddress"];
                wnote.OpusID = OpusID;
                wnote.AddTime = DateTime.Now;
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Bank_CommercialOpusLogic().AddCommercialOpus(wnote, aks))
                {
                    ViewBag.msg = "添加成功";
                }
                else
                {
                    ViewBag.msg = "添加失败";
                }
            }
            return AddCommercial(OpusID);
        }
        /// <summary>
        /// 作品商用
        /// </summary>
        /// <returns></returns>
        public ActionResult CommercialOpus()
        {
            this.pageSize = GetPageSize(20); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Bank_CommercialOpus> list = new Bank_CommercialOpusLogic().GetCommercialOpusList(KSOAEnum.OpusType.A, this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../ProPlatform/CommercialOpus", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(list);
        }
        /// <summary>
        /// 编辑作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditCommercialOpus(int id)
        {
            Bank_CommercialOpus wn = new Bank_CommercialOpusLogic().GetCommercialOpusModel(id);
            if (wn == null)
            {
                wn = new Bank_CommercialOpus();
            }
            return View(wn);
        }
        /// <summary>
        /// 提交编辑作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditCommercialOpus(FormCollection form)
        {
            int CommercialOpusID = Convert.ToInt32(form["CommercialOpusID"]);
            int OpusID = Convert.ToInt32(form["OpusID"]);
            if (form.Count != 0)
            {
                Bank_CommercialOpus wnote = new Bank_CommercialOpus();
                wnote.CompanyName = form["CompanyName"];
                wnote.ChannelAddress = form["ChannelAddress"];
                wnote.CpAddress = form["CpAddress"];
                wnote.AddTime = DateTime.Now;
                Admin_KSCustomer aks = (Admin_KSCustomer)Session["member"];
                if (new Bank_CommercialOpusLogic().EditCommercialOpus(wnote, aks, CommercialOpusID))
                {
                    ViewBag.msg = "修改成功";
                }
                else
                {
                    ViewBag.msg = "修改失败";
                }
            }
            return EditCommercialOpus(CommercialOpusID);
        }

        /// <summary>
        /// 删除商用信息
        /// </summary>
        /// <returns></returns>
        public JsonResult DelCommercialOpus()
        {
            String[] strids = Request["ids"].Split(',');

            int[] arr2 = new int[strids.Length];   //用来存放将字符串转换成int[] 
            for (int i = 0; i < strids.Length; i++)
            {
                arr2[i] = int.Parse(strids[i]);
            }
            new Bank_CommercialOpusLogic().DelCommercialOpus(arr2);

            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 原创组部分
        /// <summary>
        /// 原创组
        /// </summary>
        /// <returns></returns>
        public ActionResult OriginalGroup()
        {
            return View();
        }
        #endregion
    }
}
