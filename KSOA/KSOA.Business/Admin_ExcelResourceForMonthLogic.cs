using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Admin_ExcelResourceForMonthLogic : DbAccess
    {
        /// <summary>
        /// 批量保存导入的包月源数据
        /// </summary>
        /// <param name="dt">包月源数据表集合</param>
        /// <returns></returns>
        public bool SaveImportDatas(List<Admin_ExcelResourceForMonth> ListModel)
        {
            DataAccess.Admin_ExcelResourceForMonth query = null;
            foreach (var Model in ListModel)
            {
                query = new DataAccess.Admin_ExcelResourceForMonth();
                query.RowNumber = Model.RowNumber;
                query.StatisticsTime = Model.StatisticsTime;
                query.SingleOpusName = Model.SingleOpusName;
                query.NotBaoyuePlayNum = Model.NotBaoyuePlayNum;
                query.BaoyuePlayNum = Model.BaoyuePlayNum;
                query.PayBillPlayNum = Model.PayBillPlayNum;
                query.FreePlayNum = Model.FreePlayNum;
                query.NotBaoyuePayBillPlayNum = Model.NotBaoyuePayBillPlayNum;
                query.CPid = Model.CPid;
                query.SourceLevel = Model.SourceLevel;
                query.AddTime = Model.AddTime;
                _db.Admin_ExcelResourceForMonth.AddObject(query);
            }
            int result = _db.SaveChanges();
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
