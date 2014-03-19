using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KSOA.Model;

namespace KSOA.Business
{
    public class Admin_ExcelResourceForComplainLogic : DbAccess
    {
        /// <summary>
        /// 批量保存导入的投诉源数据
        /// </summary>
        /// <param name="dt">投诉源数据表集合</param>
        /// <returns></returns>
        public bool SaveImportDatas(List<Admin_ExcelResourceForComplain> ListModel)
        {
            DataAccess.Admin_ExcelResourceForComplain query = null;
            foreach (var Model in ListModel)
            {
                query = new DataAccess.Admin_ExcelResourceForComplain();
                query.FileDateTime = Model.FileDateTime;
                query.UserNumber = Model.UserNumber;
                query.Province = Model.Province;
                query.OrderTime = Model.OrderTime;
                query.BusinessName = Model.BusinessName;
                query.PayAmount = Model.PayAmount;
                query.CPid = Model.CPid;
                query.SourceLevel = Model.SourceLevel;
                query.AddTime = Model.AddTime;
                _db.Admin_ExcelResourceForComplain.AddObject(query);
            }
            int result= _db.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
