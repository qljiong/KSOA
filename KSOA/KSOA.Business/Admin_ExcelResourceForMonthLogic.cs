﻿using KSOA.Model;
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
        public ExtentionMonthBag GetMonthList(int PageSize, int PageIndex, out int totalCount, MonthParam pra)
        {
            var query = from s in _db.Admin_ExcelResourceForMonth
                        join p in _db.Admin_CPcompany on s.CPid equals p.ID
                        where s.IsDelete == false
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


            #region 查询条件过滤
            //cp名称
            if (!string.IsNullOrEmpty(pra.selCPName))//关键词非空
            {
                query = query.Where(s => s.Cpname.Contains(pra.selCPName));
            }
            //作品名称
            if (!string.IsNullOrEmpty(pra.selOpusName))
            {
                query = query.Where(s => s.SingleOpusName.Contains(pra.selOpusName));
            }
            //选择时间
            if (pra.seltime != new DateTime(1970, 1, 1))
            {
                query = query.Where(s => s.StatisticsTime == pra.seltime);
            }
            #endregion
            totalCount = query.Count();
            var cbag = new ExtentionMonthBag();
            if (PageIndex < 0 || PageSize < 0)
            {
                return null;
            }
            if (PageIndex == 1 && PageSize > totalCount)
            {
                cbag.list = query.ToList();
            }
            else if (PageIndex == 1 && PageSize > 0)
            {
                cbag.list = query.Take(PageSize).ToList();
            }
            else
            {
                cbag.list = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            }
            cbag.par = pra;

            return cbag;
        }
    }
}
