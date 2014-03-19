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

namespace KSOAWeb.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

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
            string userPwd = from["txtUserName"] ?? "";

            if (userName.Equals("") || userPwd.Equals(""))
            {
                ViewBag.MsgTip = "请输入用户名或密码";
                return View();
            }
            int result = new Admin_KSCustomerLogic().CheckLogin(userName, userPwd);
            if (result == 0)
            {
                ViewBag.MsgTip = "请输入用户名或密码";
                return View();
            }
            //登陆成功
            if (result == 1)
            {
                //保存登陆信息到Session

                return RedirectToAction("Index");
            }
            ViewBag.MsgTip = "登陆异常,请重试!";
            return View();
        }
        #endregion

        public ActionResult Managerpwd()
        {
            return View();
        }

        #region Excel导入相关
        /// <summary>
        /// 导入投诉源数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ImportExcelByComplain()
        {
            ViewBag.message = "请选择要上传的Excel文件！";
            return View();
        }

        /// <summary>
        /// 导入投诉源数据(提交相应)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportExcelByComplain(FormCollection form)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files["InputExcel"];
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
                        ReadExcelAndWriteToTable(fileName, KSOAEnum.ImportExcelType.投诉源数据);
                        ViewBag.message = "上传成功！";
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                else
                {
                    ViewBag.message = "上传的文件格式不符合要求！";
                }
            }
            else
            {
                ViewBag.message = "上传的文件是空文件！";
            }
            return View("ImportExcelByComplain");
        }

        /// <summary>
        /// 导入包月源数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ImportExcelByMonth()
        {
            return View();
        }

        /// <summary>
        /// 导入包月源数据(提交响应)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportExcelByMonth(FormCollection form)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files["InputExcel"];
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
                        ReadExcelAndWriteToTable(fileName, KSOAEnum.ImportExcelType.包月源数据);
                        ViewBag.message = "上传成功！";
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                else
                {
                    ViewBag.message = "上传的文件格式不符合要求！";
                }
            }
            else
            {
                ViewBag.message = "上传的文件是空文件！";
            }
            return View("ImportExcelByMonth");
        }

        /// <summary>
        /// 读取上传的Excel源文件,写入到数据库对应表
        /// </summary>
        /// <param name="excelName"></param>
        public bool ReadExcelAndWriteToTable(string excelName, KSOAEnum.ImportExcelType type)
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
            bool result = ConvertEcelToTable(hssfworkbook, type);
            return result;
        }

        public bool ConvertEcelToTable(HSSFWorkbook hss, KSOA.Common.KSOAEnum.ImportExcelType type)
        {
            #region 投诉源数据
            if ((int)type == (int)KSOAEnum.ImportExcelType.投诉源数据)
            {
                ISheet sheet = hss.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                List<Admin_ExcelResourceForComplain> listModel = new List<Admin_ExcelResourceForComplain>();
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
                    dr.CPid = 0;
                    dr.SourceLevel = "一线";
                    listModel.Add(dr);
                }
                return new Admin_ExcelResourceForComplainLogic().SaveImportDatas(listModel); ;
            } 
            #endregion

            if ((int)type == (int)KSOAEnum.ImportExcelType.包月源数据)
            {
                ISheet sheet = hss.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                List<Admin_ExcelResourceForMonth> listModel = new List<Admin_ExcelResourceForMonth>();
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
                        dr.BaoyuePlayNum =Convert.ToInt32(BaoyuePlayNum.ToString());
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

                    dr.CPid = 0;
                    dr.SourceLevel = "一线";
                    listModel.Add(dr);
                }
                return new Admin_ExcelResourceForMonthLogic().SaveImportDatas(listModel); ;
            }
            return false;
        }
        #endregion
    }
}
