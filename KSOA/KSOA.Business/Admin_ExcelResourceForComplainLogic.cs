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
        /// 获取制定日期的投诉统计
        /// </summary>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        public ExtentionComplainBag GetAnalysisByComplain(int PageSize, int PageIndex, out int totalCount, ComplainParam pra)
        {
            //统计非包月用户数
            //取出所有数据
            var ComplainTable = from p in _db.Admin_ExcelResourceForComplain select p;
            //取出所有CP数据
            var CPcompanyTable = from p in _db.Admin_CPcompany select p;
            //取出所有地区
            var allArea = from p in ComplainTable group p by p.Province into g select new { g.Key };
            //取出所有CP
            var allCp = from p in ComplainTable join s in CPcompanyTable on p.CPid equals s.ID group p by new { p.CPid, s.CPname, p.SourceLevel } into t select new { t.Key.CPid, t.Key.CPname, t.Key.SourceLevel };
            //非包月付费用户数累计表数据
            var notBaoyue = from p in _db.Admin_NotBaoyuePayBillPlayCount
                            group p by new { p.Province, p.CpID } into g
                            select new
                            {
                                Province = g.Key.Province,
                                CpID = g.Key.CpID,
                                AddNum = g.Sum(p => p.AddNum),
                                LeaveNum = g.Sum(p => p.LeaveNum),
                                NumTotal = g.Sum(p => p.NumTotal)
                            };
            //分析结果实体,用户装载最后的分析结果
            List<ComplainAnalysisList> cpList = new List<ComplainAnalysisList>();
            //循环所有CP分类
            foreach (var item in allCp)
            {
                //筛选出一个cp
                var cpComplain = ComplainTable.Where(s => s.CPid == item.CPid);
                //按地区分组统计
                //1.新增
                var AddPop = from p in cpComplain
                             join s in allCp on p.CPid equals s.CPid
                             where p.OrderTime > pra.seltime
                             group p by p.Province into g
                             select new
                             {
                                 g.Key,
                                 AddCount = g.Count()
                             };

                //2.遗留
                var leavePop = from p in cpComplain
                               join s in allCp on p.CPid equals s.CPid
                               where p.OrderTime <= pra.seltime
                               group p by p.Province into g
                               select new
                               {
                                   g.Key,
                                   AddCount = g.Count()
                               };
                //新增日期的昨天记录
                DateTime praseltime = pra.seltime.AddDays(-1);
                var yesterdayAddPop = from p in cpComplain
                                      join s in allCp on p.CPid equals s.CPid
                                      where p.OrderTime > praseltime
                                      group p by p.Province into g
                                      select new
                                      {
                                          g.Key,
                                          AddCount = g.Count()
                                      };
                //按按cp分类的实体
                ComplainAnalysisList cpModel = new ComplainAnalysisList();
                //3.添加结果到分析结果实体
                foreach (var area in allArea)
                {
                    ComplainAnalysisModel caModel = new ComplainAnalysisModel();
                    cpModel.caList = new List<ComplainAnalysisModel>();
                    cpModel.CpName = item.CPname;
                    cpModel.SourceLevel = item.SourceLevel;

                    caModel.privnce = area.Key;
                    caModel.notBaoyuePayUserNum = notBaoyue.Where(s => s.CpID == item.CPid && s.Province == area.Key).FirstOrDefault() != null ? notBaoyue.Where(s => s.CpID == item.CPid && s.Province == area.Key).FirstOrDefault().NumTotal : 0;
                    caModel.yesterdayAddNum = yesterdayAddPop.Where(s => s.Key == area.Key).FirstOrDefault() != null ? yesterdayAddPop.Where(s => s.Key == area.Key).FirstOrDefault().AddCount : 0;
                    caModel.AddNum = AddPop.Where(s => s.Key == area.Key).FirstOrDefault() != null ? AddPop.Where(s => s.Key == area.Key).FirstOrDefault().AddCount : 0;
                    caModel.LeaveNum = leavePop.Where(s => s.Key == area.Key).FirstOrDefault() != null ? leavePop.Where(s => s.Key == area.Key).FirstOrDefault().AddCount : 0;
                    if (caModel.notBaoyuePayUserNum == 0)
                    {
                        caModel.proportion = 0;
                    }
                    else
                    {
                        caModel.proportion = caModel.AddNum / caModel.notBaoyuePayUserNum * 10000;
                    }

                    cpModel.caList.Add(caModel);
                }
                //添加到列表
                cpList.Add(cpModel);
            }
            var query = cpList.OrderBy(s => s.SourceLevel).ToList();

            #region 查询条件过滤
            //关键词
            if (!string.IsNullOrEmpty(pra.selkeywords))//关键词非空
            {
                query = query.Where(s => s.CpName.Contains(pra.selkeywords)).ToList();
            }
            //线级
            if (pra.selline != "0" && pra.selline != "")//线级选择非空
            {
                string level = pra.selline == "1" ? "一线" : "二线";
                query = query.Where(s => s.SourceLevel.Contains(level)).ToList();
            }
            #endregion

            totalCount = query.Count();
            var cbag = new ExtentionComplainBag();
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

        /// <summary>
        /// 获取渠道投诉统计数据
        /// </summary>
        public ExtentionIncomeAnalysis GetIncomeAnalysis(int PageSize, int PageIndex, out int totalCount, IncomeAnalysisParam pra)
        {
            totalCount = 0;
            return new ExtentionIncomeAnalysis();
        }
    }
}
