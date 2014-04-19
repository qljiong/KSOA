using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;
using KSOA.Business;
using KSOA.Common;
using KSOA.Model;
using NPOI.HPSF;

namespace KSOAWeb.Controllers
{
    public class AdminController : BasePageController
    {
        #region 框架页相关
        /// <summary>
        /// 框架页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Admin_KSCustomer user = (Admin_KSCustomer)Session["member"];
            return View(user);
        }
        /// <summary>
        /// 安全退出
        /// </summary>
        /// <returns></returns>
        public JsonResult SafeExit()
        {
            Session.Remove("member");
            //删除cookie
            HttpCookie cookie = Request.Cookies["keeplogin"];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie);
            }

            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 管理页初始显示页
        /// </summary>
        /// <returns></returns>
        public ActionResult Center()
        {
            Admin_KSCustomer user = (Admin_KSCustomer)Session["member"];
            ViewBag.userName = user.CusName;
            siteconfig model = CacheHelper.Get<siteconfig>(DTKeys.CACHE_SITE_CONFIG);
            if (model == null)
            {
                CacheHelper.Insert(DTKeys.CACHE_SITE_CONFIG, loadConfig(Utils.GetXmlMapPath("Configpath")), Utils.GetXmlMapPath("Configpath"));
                model = CacheHelper.Get<siteconfig>(DTKeys.CACHE_SITE_CONFIG);
            }
            return View(model);
        }

        /// <summary>
        /// 获取系统配置信息
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public siteconfig loadConfig(string configFilePath)
        {
            return (siteconfig)SerializationHelper.Load(typeof(siteconfig), configFilePath);
        }
        #endregion

        #region 登陆相关
        //get:/admin/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //post:/admin/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection from)
        {
            string userName = from["txtUserName"] ?? "";
            string userPwd = from["txtUserPwd"] ?? "";

            if (userName.Equals("") || userPwd.Equals(""))
            {
                ViewBag.MsgTip = "请输入用户名或密码";
                return View();
            }
            Admin_KSCustomer result = new Admin_KSCustomerLogic().CheckLogin(userName, userPwd);
            if (result == null)
            {
                ViewBag.MsgTip = "用户名或密码错误";
                return View();
            }
            else
            {
                //保存登陆信息到Session
                Session["member"] = result;
                HttpCookie cookie = new HttpCookie("keeplogin");
                cookie.Expires = DateTime.Now.AddHours(4);
                //保存到Cookie
                cookie.Value = userName;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult Managerpwd()
        {
            Admin_KSCustomer cus = (Admin_KSCustomer)Session["member"];
            if (cus != null)
            {
                ViewBag.msg = Session["mpdMsg"] ?? "";
                Session.Remove("mpdMsg");
                return View(cus);
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Managerpwd(FormCollection form)
        {
            Admin_KSCustomer cus = new Admin_KSCustomer();
            cus.CusName = form["txtUserName"];
            cus.CusPwd = form["txtUserPwd"];
            cus.Oldcuspwd = form["txtoldpwd"];
            cus.RealName = form["txtRealName"] ?? "";
            cus.CusPhoneNum = form["txtTelephone"];
            cus.CusEmail = form["txtEmail"];
            //验证旧密码是否正确
            Admin_KSCustomer result = new Admin_KSCustomerLogic().CheckLogin(cus.CusName, cus.Oldcuspwd);
            if (result != null)
            {
                if (new Admin_KSCustomerLogic().UpdateCusInfo(cus))
                {
                    Session["mpdMsg"] = "更新成功";
                    return RedirectToAction("Managerpwd");
                }
                else
                {
                    Session["mpdMsg"] = "更新失败";
                    return RedirectToAction("Managerpwd");
                }
            }
            Session["mpdMsg"] = "旧登录密码错误";
            return RedirectToAction("Managerpwd");
        }
        #endregion

        #region Excel导入相关
        /// <summary>
        /// 导入投诉源数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ImportExcelByComplain()
        {
            ViewBag.msg = "请选择要上传的Excel文件！";
            List<Admin_CPcompany> cpList = new Admin_CPcompanyLogic().GetCpList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in cpList)
            {
                items.Add(new SelectListItem { Selected = false, Text = item.CPname, Value = item.ID.ToString() });
            }
            ViewBag.CpNameList = items;
            return View();
        }

        /// <summary>
        /// 导入投诉源数据(提交相应)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ImportExcelByComplain(FormCollection form)
        {
            string msg = "";
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files["InputExcel"];
            int cp = Convert.ToInt32(form["cpNameList"]);
            if (file != null && file.ContentLength > 0)
            {
                string fileName = file.FileName;
                //判断文件名字是否包含路径名，如果有则提取文件名
                if (fileName.LastIndexOf("\\") > -1)
                {
                    fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                }
                //判断文件格式，这里要求是JPG格式
                if ((fileName.LastIndexOf('.') > -1 && fileName.Substring(fileName.LastIndexOf('.')).ToUpper() == ".XLS"))
                {
                    string path = Server.MapPath("~/UploadFile/Complain/");
                    try
                    {
                        //重命名
                        fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + fileName;
                        file.SaveAs(path + fileName);
                        if (ReadExcelAndWriteToTable(fileName, cp, KSOAEnum.ImportExcelType.投诉源数据))
                        {
                            msg = "上传失败！";
                        }
                        else
                        {
                            msg = "上传成功！";
                        }

                    }
                    catch (Exception e)
                    {
                        msg = "上传失败,上传文件格式不匹配！   " + e.Message;
                    }
                }
                else
                {
                    msg = "上传的文件格式不符合要求！";
                }
            }
            else
            {
                msg = "上传的文件是空文件！";
            }
            //return RedirectToAction("ImportExcelByComplain");
            return Json(new { result = 1, resultmsg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 导入包月源数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ImportExcelByMonth()
        {
            ViewBag.msg = "请选择要上传的Excel文件！";
            List<Admin_CPcompany> cpList = new Admin_CPcompanyLogic().GetCpList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in cpList)
            {
                items.Add(new SelectListItem { Selected = false, Text = item.CPname, Value = item.ID.ToString() });
            }
            ViewBag.CpNameList = items;
            return View();
        }

        /// <summary>
        /// 导入包月源数据(提交响应)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ImportExcelByMonth(FormCollection form)
        {
            string msg = "";
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files["InputExcel"];
            int cp = Convert.ToInt32(form["cpNameList"]);

            if (file != null && file.ContentLength > 0)
            {
                string fileName = file.FileName;
                //判断文件名字是否包含路径名，如果有则提取文件名
                if (fileName.LastIndexOf("\\") > -1)
                {
                    fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                }
                //判断文件格式，这里要求是JPG格式
                if ((fileName.LastIndexOf('.') > -1 && fileName.Substring(fileName.LastIndexOf('.')).ToUpper() == ".XLS"))
                {
                    string path = Server.MapPath("~/UploadFile/Month/");
                    try
                    {
                        //重命名
                        fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + fileName;
                        file.SaveAs(path + fileName);
                        if (ReadExcelAndWriteToTable(fileName, cp, KSOAEnum.ImportExcelType.包月源数据))
                        {
                            msg = "上传失败！";
                        }
                        else
                        {
                            msg = "上传成功！";
                        }
                    }
                    catch (Exception e)
                    {
                        msg = "上传失败,上传文件格式不匹配！   " + e.Message;
                    }
                }
                else
                {
                    msg = "上传的文件格式不符合要求！";
                }
            }
            else
            {
                msg = "上传的文件是空文件！";
            }
            return Json(new { result = 1, resultmsg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 读取上传的Excel源文件,写入到数据库对应表
        /// </summary>
        /// <param name="excelName"></param>
        public bool ReadExcelAndWriteToTable(string excelName, int CP, KSOAEnum.ImportExcelType type)
        {
            HSSFWorkbook hssfworkbook;
            string path = "";
            if ((int)type == (int)KSOAEnum.ImportExcelType.投诉源数据)
            {
                path = Server.MapPath("/KSOAWeb/UploadFile/Complain/" + excelName);
            }
            if ((int)type == (int)KSOAEnum.ImportExcelType.包月源数据)
            {
                path = Server.MapPath("/KSOAWeb/UploadFile/Month/" + excelName);
            }

            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            bool result = ConvertEcelToTable(hssfworkbook, CP, type);
            return result;
        }

        public bool ConvertEcelToTable(HSSFWorkbook hss, int CP, KSOA.Common.KSOAEnum.ImportExcelType type)
        {
            #region 投诉源数据
            if ((int)type == (int)KSOAEnum.ImportExcelType.投诉源数据)
            {
                ISheet sheet = null;
                List<Admin_ExcelResourceForComplain> listModel = new List<Admin_ExcelResourceForComplain>();
                for (int i = 0; i < hss.Workbook.NumSheets; i++)//循环sheet
                {
                    sheet = hss.GetSheetAt(i);
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                    rows.MoveNext();//跳过首行标题
                    while (rows.MoveNext())
                    {
                        IRow row = (HSSFRow)rows.Current;
                        Admin_ExcelResourceForComplain dr = new Admin_ExcelResourceForComplain();

                        #region FileDateTime投诉归档日期
                        ICell FileDateTime = row.GetCell(0);
                        if (FileDateTime == null)
                        {
                            dr.FileDateTime = new DateTime(1900, 1, 1);
                        }
                        else
                        {
                            dr.FileDateTime = Utils.ConvertStrToDate(FileDateTime.ToString());
                        }
                        #endregion
                        #region UserNumber用户号码
                        ICell UserNumber = row.GetCell(1);
                        if (UserNumber == null)
                        {
                            dr.UserNumber = "00000000000";
                        }
                        else
                        {
                            dr.UserNumber = UserNumber.ToString();
                        }
                        #endregion
                        #region Province省份
                        ICell Province = row.GetCell(2);
                        if (Province == null)
                        {
                            dr.Province = "";
                        }
                        else
                        {
                            dr.Province = Province.ToString();
                        }
                        #endregion
                        #region OrderTime订购日期
                        ICell OrderTime = row.GetCell(3);
                        if (OrderTime == null)
                        {
                            dr.OrderTime = new DateTime(1900, 1, 1);
                        }
                        else
                        {
                            dr.OrderTime = Utils.ConvertStrToDate(OrderTime.ToString());
                        }
                        #endregion
                        #region BusinessName订购业务名称
                        ICell BusinessName = row.GetCell(4);
                        if (BusinessName == null)
                        {
                            dr.BusinessName = "";
                        }
                        else
                        {
                            dr.BusinessName = BusinessName.ToString();
                        }
                        #endregion
                        #region PayAmount支付费用
                        ICell PayAmount = row.GetCell(5);
                        if (BusinessName == null)
                        {
                            dr.PayAmount = 0.0M;
                        }
                        else
                        {
                            dr.PayAmount = Convert.ToDecimal(PayAmount.ToString());
                        }
                        #endregion
                        dr.CPid = CP;
                        dr.SourceLevel = hss.Workbook.GetSheetName(i).Trim();//sheetname
                        listModel.Add(dr);
                    }
                }
                return new Admin_ExcelResourceForComplainLogic().SaveImportDatas(listModel); ;
            }
            #endregion

            #region 包月源数据
            if ((int)type == (int)KSOAEnum.ImportExcelType.包月源数据)
            {
                ISheet sheet = null;
                List<Admin_ExcelResourceForMonth> listModel = new List<Admin_ExcelResourceForMonth>();
                for (int i = 0; i < hss.Workbook.NumSheets; i++)//循环sheet
                {
                    sheet = hss.GetSheetAt(i);
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                    rows.MoveNext();//跳过首行标题
                    while (rows.MoveNext())
                    {
                        IRow row = (HSSFRow)rows.Current;
                        Admin_ExcelResourceForMonth dr = new Admin_ExcelResourceForMonth();

                        #region RowNumber行号
                        ICell RowNumber = row.GetCell(0);
                        if (RowNumber == null)
                        {
                            dr.RowNumber = -1;//未标示行号
                        }
                        else
                        {
                            dr.RowNumber = Convert.ToInt32(RowNumber.ToString());
                        }
                        #endregion
                        #region StatisticsTime统计日期
                        ICell StatisticsTime = row.GetCell(1);
                        if (StatisticsTime == null)
                        {
                            dr.StatisticsTime = new DateTime(1900, 1, 1);
                        }
                        else
                        {
                            dr.StatisticsTime = Utils.ConvertStrToDate(StatisticsTime.ToString());
                        }
                        #endregion
                        #region SingleOpusName单部名称
                        ICell SingleOpusName = row.GetCell(2);
                        if (SingleOpusName == null)
                        {
                            dr.SingleOpusName = "";
                        }
                        else
                        {
                            dr.SingleOpusName = SingleOpusName.ToString();
                        }
                        #endregion
                        #region NotBaoyuePlayNum非包月点播次数
                        ICell NotBaoyuePlayNum = row.GetCell(3);
                        if (NotBaoyuePlayNum == null)
                        {
                            dr.NotBaoyuePlayNum = 0;
                        }
                        else
                        {
                            dr.NotBaoyuePlayNum = Convert.ToInt32(NotBaoyuePlayNum.ToString());
                        }
                        #endregion
                        #region BaoyuePlayNum包月点播次数
                        ICell BaoyuePlayNum = row.GetCell(4);
                        if (BaoyuePlayNum == null)
                        {
                            dr.BaoyuePlayNum = 0;
                        }
                        else
                        {
                            dr.BaoyuePlayNum = Convert.ToInt32(BaoyuePlayNum.ToString());
                        }
                        #endregion
                        #region PayBillPlayNum付费点播次数
                        ICell PayBillPlayNum = row.GetCell(5);
                        if (PayBillPlayNum == null)
                        {
                            dr.PayBillPlayNum = 0;
                        }
                        else
                        {
                            dr.PayBillPlayNum = Convert.ToInt32(PayBillPlayNum.ToString());
                        }
                        #endregion
                        #region FreePlayNum免费点播次数
                        ICell FreePlayNum = row.GetCell(5);
                        if (FreePlayNum == null)
                        {
                            dr.FreePlayNum = 0;
                        }
                        else
                        {
                            dr.FreePlayNum = Convert.ToInt32(FreePlayNum.ToString());
                        }
                        #endregion
                        #region NotBaoyuePayBillPlayNum非包月付费点播次数
                        ICell NotBaoyuePayBillPlayNum = row.GetCell(5);
                        if (FreePlayNum == null)
                        {
                            dr.NotBaoyuePayBillPlayNum = 0;
                        }
                        else
                        {
                            dr.NotBaoyuePayBillPlayNum = Convert.ToInt32(NotBaoyuePayBillPlayNum.ToString());
                        }
                        #endregion

                        dr.CPid = CP;
                        dr.SourceLevel = hss.Workbook.GetSheetName(i).Trim();
                        listModel.Add(dr);
                    }
                }
                return new Admin_ExcelResourceForMonthLogic().SaveImportDatas(listModel); ;
            }
            #endregion
            return false;
        }
        #endregion

        #region 导出Excel文件相关
        void InitializeWorkbook(HSSFWorkbook hssfworkbook)
        {
            ////create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "旷盛";
            hssfworkbook.DocumentSummaryInformation = dsi;

            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "KSOA";
            hssfworkbook.SummaryInformation = si;
        }
        void GenerateData(HSSFWorkbook hssfworkbook, List<ComplainAnalysisList> dataList)
        {
            int tabNum = 1;
            foreach (var item in dataList)
            {
                ISheet sheet1 = hssfworkbook.CreateSheet(item.CpName + tabNum);
                tabNum++;
                IRow titleRow = sheet1.CreateRow(0);
                titleRow.CreateCell(0).SetCellValue("线级");
                titleRow.CreateCell(1).SetCellValue("CP");
                titleRow.CreateCell(2).SetCellValue("省份");
                titleRow.CreateCell(3).SetCellValue("单省分非包月付费用户数");
                titleRow.CreateCell(4).SetCellValue("昨日新增");
                titleRow.CreateCell(5).SetCellValue("今日新增");
                titleRow.CreateCell(6).SetCellValue("遗留");
                titleRow.CreateCell(7).SetCellValue("新增万投比");
                for (int i = 1; i <= item.caList.Count; i++)
                {
                    IRow row = sheet1.CreateRow(i);
                    row.CreateCell(0).SetCellValue(item.SourceLevel);
                    row.CreateCell(1).SetCellValue(item.CpName);
                    row.CreateCell(2).SetCellValue(item.caList[i - 1].privnce);
                    row.CreateCell(3).SetCellValue(item.caList[i - 1].notBaoyuePayUserNum);
                    row.CreateCell(4).SetCellValue(item.caList[i - 1].yesterdayAddNum);
                    row.CreateCell(5).SetCellValue(item.caList[i - 1].AddNum);
                    row.CreateCell(6).SetCellValue(item.caList[i - 1].LeaveNum);
                    row.CreateCell(7).SetCellValue(item.caList[i - 1].proportion);
                }
            }
        }
        MemoryStream GetExcelStream(HSSFWorkbook hssfworkbook)
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }
        public ActionResult ExportExcelToDownLoad(string excelName = "测试")
        {
            ExtentionComplainBag cbag = new ExtentionComplainBag();
            ComplainParam pra = new ComplainParam();
            pra.seltime = DateTime.Now;
            pra.selline = "";
            pra.selkeywords = "";

            cbag = new Admin_ExcelResourceForComplainLogic().GetAnalysisByComplain(this.pageSize, this.page, out this.totalCount, pra);

            string filename = excelName + ".xls";
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
            Response.Clear();

            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            InitializeWorkbook(hssfworkbook);
            GenerateData(hssfworkbook, cbag.list);
            GetExcelStream(hssfworkbook).WriteTo(Response.OutputStream);
            Response.End();
            return new EmptyResult();
        }
        #endregion

        #region CP管理
        /// <summary>
        /// 新增CP
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCP()
        {
            return View();
        }
        /// <summary>
        /// 新增CP
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCP(FormCollection form)
        {
            string cpname = form["CPName"] ?? "";
            if (cpname == "")
            {
                ViewBag.msg = "CP名称不能为空";
                return View();
            }
            else
            {
                Admin_CPcompany acp = new Admin_CPcompany();
                acp.CPname = cpname;
                if (new Admin_CPcompanyLogic().AddCP(acp))
                {
                    ViewBag.msg = "CP添加成功";
                }
                else
                {
                    ViewBag.msg = "CP添加失败";
                }
                return View();
            }

        }

        /// <summary>
        /// 编辑CP信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditCp(int id)
        {
            Admin_CPcompany acp = new Admin_CPcompanyLogic().GetCPbyID(id);
            return View(acp);
        }

        /// <summary>
        /// 更新CP信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditCp(FormCollection form)
        {
            int id = int.Parse(form["cpid"]);
            string cpname = form["cpname"];
            if (new Admin_CPcompanyLogic().UpdateCPbyID(id, cpname))
            {
                ViewBag.msg = "CP更新成功";
            }
            else
            {
                ViewBag.msg = "CP更新失败";
            }
            Admin_CPcompany mm = new Admin_CPcompany();
            return View(mm);
        }

        /// <summary>
        /// 删除Cp
        /// </summary>
        /// <returns></returns>
        public JsonResult DelCP()
        {
            String[] strids = Request["ids"].Split(',');

            int[] arr2 = new int[strids.Length];   //用来存放将字符串转换成int[] 
            for (int i = 0; i < strids.Length; i++)
            {
                arr2[i] = int.Parse(strids[i]);
            }
            new Admin_CPcompanyLogic().DelCP(arr2);

            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 供应商列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CPlist(FormCollection form)
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            ViewBag.DataSource = new Admin_CPcompanyLogic().GetCpList(this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../admin/CPlist", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View();
        }
        #endregion

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

        #region 人员管理
        public ActionResult AddPop()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPop(FormCollection form)
        {
            Admin_KSCustomer aks = new Admin_KSCustomer();
            aks.RealName = form["RealName"];
            aks.CusName = form["CusName"];
            aks.Gender = "Y";
            aks.Age = Convert.ToInt32(form["Age"] == "" ? "0" : form["Age"]);
            aks.CusPwd = form["CusPwd"];
            aks.CusEmail = form["CusEmail"] ?? "";
            aks.CusPhoneNum = form["CusPhoneNum"] ?? "";
            aks.QQ = form["QQ"] ?? "";
            if (new Admin_KSCustomerLogic().AddCusInfo(aks))
            {
                ViewBag.msg = "添加成功!";
            }
            else
            {
                ViewBag.msg = "添加失败!";
            }
            return View();
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="CusName"></param>
        /// <returns></returns>
        public JsonResult CheckCusName()
        {
            String CusName = Request["cusName"];
            var aks = new Admin_KSCustomerLogic().GetCusbyCusName(CusName);
            if (aks == null)
            {
                return Json(new { result = 0 }, JsonRequestBehavior.AllowGet);//不存在
            }
            else
            {
                return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);//存在
            }
        }
        public ActionResult PopList()
        {
            this.pageSize = GetPageSize(15); //每页数量
            this.page = DTRequest.GetQueryInt("page", 1);
            ViewBag.txtKeywords = this.keywords;
            List<Admin_KSCustomer> acplist = new Admin_KSCustomerLogic().GetPopList(this.pageSize, this.page, out this.totalCount);

            //绑定页码
            ViewBag.txtPageNum = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("../admin/PopList", "group_id={0}&keywords={1}&page={2}", this.group_id.ToString(), this.keywords, "__id__");
            ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            return View(acplist);
        }

        [HttpPost]
        public ActionResult PopEdit(FormCollection form)
        {
            int id = Convert.ToInt32(form["aksID"]);
            Admin_KSCustomer aks = new Admin_KSCustomer();
            aks.RealName = form["RealName"];
            aks.CusName = form["CusName"];
            aks.Gender = form["Gender"];
            aks.Age = Convert.ToInt32(form["Age"]);
            aks.CusPwd = form["CusPwd"];
            aks.CusEmail = form["CusEmail"];
            aks.CusPhoneNum = form["CusPhoneNum"];
            aks.QQ = form["QQ"];
            if (new Admin_KSCustomerLogic().EditCusInfo(aks, id))
            {
                Session["peMsg"] = "修改成功!";
            }
            else
            {
                Session["peMsg"] = "修改失败!";
            }
            return RedirectPermanent("../PopEdit/" + id);
        }
        public ActionResult PopEdit(int id)
        {
            Admin_KSCustomer aks = new Admin_KSCustomerLogic().GetCusbyID(id);
            ViewBag.msg = Session["peMsg"] ?? "";
            Session.Remove("peMsg");
            return View(aks);
        }
        public JsonResult PopDel()
        {
            String[] strids = Request["ids"].Split(',');

            int[] arr2 = new int[strids.Length];   //用来存放将字符串转换成int[] 
            for (int i = 0; i < strids.Length; i++)
            {
                arr2[i] = int.Parse(strids[i]);
            }
            bool result = new Admin_KSCustomerLogic().DelCusByID(arr2);
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 投诉管理

        public ActionResult ComplainManage(FormCollection form)
        {
            ExtentionComplainBag cbag = new ExtentionComplainBag();
            if (form.Count != 0 || Request.QueryString.Count != 0)//有选择条件
            {
                ComplainParam pra = new ComplainParam();
                //post请求
                if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    if (form["SelTime"] != "" && form["SelTime"] != null)
                    {
                        pra.seltime = Convert.ToDateTime(form["SelTime"]);
                    }
                    else
                    {
                        pra.seltime = DateTime.Now.AddDays(-1);
                    }
                }
                else if (DTRequest.GetQueryString("seltime") != "")
                {
                    pra.seltime = Convert.ToDateTime(DTRequest.GetQueryString("seltime"));
                }
                else
                {
                    pra.seltime = DateTime.Now.AddDays(-1);
                }

                //post请求
                if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    if (form["SelLine"] != "" && form["SelLine"] != null)
                    {
                        pra.selline = form["SelLine"];
                    }
                    else
                    {
                        pra.selline = "";
                    }
                }
                else if (DTRequest.GetQueryString("SelLine") != "")
                {
                    pra.selline = DTRequest.GetQueryString("SelLine");
                }
                else
                {
                    pra.selline = "";
                }

                //post请求
                if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    if (form["SelKeywords"] != "" && form["SelKeywords"] != null)
                    {
                        pra.selkeywords = form["SelKeywords"];
                    }
                    else
                    {
                        pra.selkeywords = "";
                    }
                }
                else if (DTRequest.GetQueryString("SelKeywords") != "")
                {
                    pra.selkeywords = DTRequest.GetQueryString("SelKeywords");
                }
                else
                {
                    pra.selkeywords = "";
                }

                this.pageSize = GetPageSize(20); //每页数量
                this.page = DTRequest.GetQueryInt("page", 1);
                ViewBag.txtKeywords = this.keywords;
                cbag = new Admin_ExcelResourceForComplainLogic().GetAnalysisByComplain(this.pageSize, this.page, out this.totalCount, pra);
                //绑定页码
                ViewBag.txtPageNum = this.pageSize.ToString();
                string pageUrl = Utils.CombUrlTxt("../admin/ComplainManage", "seltime={0}&selline={1}&selkeywords={2}&page={3}", pra.seltime.ToString(), pra.selline, pra.selkeywords, "__id__");
                ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
                return View(cbag);
            }
            else
            {
                ComplainParam pra = new ComplainParam();
                pra.seltime = DateTime.Now.AddDays(-1);
                pra.selline = "";
                pra.selkeywords = "";

                this.pageSize = GetPageSize(20); //每页数量
                //post请求,点击查询返回第一页
                if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    this.page = 1;
                }
                else
                {
                    this.page = DTRequest.GetQueryInt("page", 1);
                }
                ViewBag.txtKeywords = this.keywords;
                cbag = new Admin_ExcelResourceForComplainLogic().GetAnalysisByComplain(this.pageSize, this.page, out this.totalCount, pra);
                //绑定页码
                ViewBag.txtPageNum = this.pageSize.ToString();
                string pageUrl = Utils.CombUrlTxt("../admin/ComplainManage", "seltime={0}&selline={1}&selkeywords={2}&page={3}", pra.seltime.ToString(), pra.selline, pra.selkeywords, "__id__");
                ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
                return View(cbag);
            }
        }
        #endregion

        #region 包月管理
        public ActionResult MonthManage(FormCollection form)
        {
            ExtentionMonthBag cbag = new ExtentionMonthBag();
            if (form.Count != 0 || Request.QueryString.Count != 0)//有选择条件
            {
                MonthParam pra = new MonthParam();
                //post请求
                if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    if (form["SelTime"] != "" && form["SelTime"] != null)
                    {
                        pra.seltime = Convert.ToDateTime(form["SelTime"]);
                    }
                    else
                    {
                        pra.seltime = new DateTime(1970, 1, 1);
                    }
                }
                else if (DTRequest.GetQueryString("seltime") != "")
                {
                    pra.seltime = Convert.ToDateTime(DTRequest.GetQueryString("seltime"));
                }
                else
                {
                    pra.seltime = new DateTime(1970, 1, 1);
                }

                //post请求
                if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    if (form["selOpusName"] != "" && form["selOpusName"] != null)
                    {
                        pra.selOpusName = form["selOpusName"];
                    }
                    else
                    {
                        pra.selOpusName = "";
                    }
                }
                else if (DTRequest.GetQueryString("selOpusName") != "")
                {
                    pra.selOpusName = DTRequest.GetQueryString("selOpusName");
                }
                else
                {
                    pra.selOpusName = "";
                }

                //post请求
                if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    if (form["selCPName"] != "" && form["selCPName"] != null)
                    {
                        pra.selCPName = form["selCPName"];
                    }
                    else
                    {
                        pra.selCPName = "";
                    }
                }
                else if (DTRequest.GetQueryString("selCPName") != "")
                {
                    pra.selCPName = DTRequest.GetQueryString("selCPName");
                }
                else
                {
                    pra.selCPName = "";
                }

                this.pageSize = GetPageSize(25); //每页数量
                //post请求,点击查询返回第一页
                if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    this.page = 1;
                }
                else
                {
                    this.page = DTRequest.GetQueryInt("page", 1);
                }
                ViewBag.txtKeywords = this.keywords;
                cbag = new Admin_ExcelResourceForMonthLogic().GetMonthList(this.pageSize, this.page, out this.totalCount, pra);
                //绑定页码
                ViewBag.txtPageNum = this.pageSize.ToString();
                string pageUrl = Utils.CombUrlTxt("../admin/MonthManage", "SelTime={0}&selOpusName={1}&selCPName={2}&page={3}", pra.seltime.ToString(), pra.selOpusName, pra.selCPName, "__id__");
                ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
                return View(cbag);
            }
            else
            {
                MonthParam pra = new MonthParam();
                pra.seltime = form["SelTime"] == "" || form["SelTime"] == null ? new DateTime(1970, 1, 1) : Convert.ToDateTime(form["SelTime"]);
                pra.selOpusName = "";
                pra.selCPName = "";

                this.pageSize = GetPageSize(25); //每页数量
                this.page = DTRequest.GetQueryInt("page", 1);
                ViewBag.txtKeywords = this.keywords;
                cbag = new Admin_ExcelResourceForMonthLogic().GetMonthList(this.pageSize, this.page, out this.totalCount, pra);
                //绑定页码
                ViewBag.txtPageNum = this.pageSize.ToString();
                string pageUrl = Utils.CombUrlTxt("../admin/MonthManage", "SelTime={0}&selOpusName={1}&selCPName={2}&page={3}", pra.seltime.ToString(), pra.selOpusName, pra.selCPName, "__id__");
                ViewBag.PageContent = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
                return View(cbag);
            }
        }
        #endregion

        #region 收入统计
        public ActionResult IncomeManage(FormCollection form)
        {
            IncomeAnalysisParam pra = new IncomeAnalysisParam();
            if (form.Count > 0)
            {
                if (form["SelTime"] != "" && form["SelTime"] != null)
                {
                    pra.selTime = Convert.ToDateTime(form["SelTime"] + "-01");
                }
                else
                {
                    pra.selTime = DateTime.Now;
                }
                pra.opusName = form["SelOpusName"];
            }
            ExtentionIncomeAnalysis result = new Admin_ExcelResourceForMonthLogic().GetIncomeAnalysis(this.pageSize, this.page, out this.totalCount, pra);
            return View(result);
        }
        #endregion

        #region 渠道投诉统计
        public ActionResult ChannelComplainManage()
        {
            return View();
        }
        #endregion
    }
}
