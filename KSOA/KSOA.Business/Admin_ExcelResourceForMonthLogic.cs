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

        /// <summary>
        /// 获取包月数据列表
        /// </summary>
        /// <returns></returns>
        public List<Admin_ExcelResourceForMonth> GetMonthList(int PageSize, int PageIndex, out int totalCount, int cpid, DateTime findTime)
        {
            var query = from s in _db.Admin_ExcelResourceForMonth
                        join p in _db.Admin_CPcompany on s.CPid equals p.ID
                        where s.IsDelete == false && s.CPid == cpid
                        orderby s.StatisticsTime
                        select new Admin_ExcelResourceForMonth
                            {
                                RowNumber = s.RowNumber,
                                Cpname = p.CPname,
                                StatisticsTime = s.StatisticsTime,
                                SingleOpusName = s.SingleOpusName,
                                NotBaoyuePlayNum = s.NotBaoyuePlayNum,
                                BaoyuePlayNum = s.BaoyuePlayNum,
                                PayBillPlayNum = s.PayBillPlayNum,
                                FreePlayNum = s.FreePlayNum,
                                NotBaoyuePayBillPlayNum = s.NotBaoyuePayBillPlayNum,
                                CPid = s.CPid,
                                SourceLevel = s.SourceLevel,
                                AddTime = s.AddTime
                            };
            totalCount = query.Count();
            var list = new List<Admin_ExcelResourceForMonth>();
            if (PageIndex < 0 || PageSize < 0)
            {
                return null;
            }
            if (PageIndex == 1 && PageSize > totalCount)
            {
                list = query.ToList();
            }
            else if (PageIndex == 1 && PageSize > 0)
            {
                list = query.Take(PageSize).ToList();
            }
            else
            {
                list = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            }
            return list;
        }
    }
}
