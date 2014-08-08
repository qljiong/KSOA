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
        /// 获取制定日期的投诉统计(菜单:分省投诉万投比)
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
            //取出投诉表与cp表关联的所有CP
            var allCp = from p in ComplainTable join s in CPcompanyTable on p.CPid equals s.ID group p by new { p.CPid, s.CPname, p.SourceLevel } into t select new { t.Key.CPid, t.Key.CPname, t.Key.SourceLevel };
            //非包月付费用户数累计表数据(按cp和省份分组)
            var notBaoyue = from p in _db.Admin_NotBaoyuePayBillPlayCount
                            group p by new { p.Province, p.CpID } into g
                            select new
                            {
                                Province = g.Key.Province,
                                CpID = g.Key.CpID,
                                AddNum = g.Sum(p => p.AddNum),//新增
                                LeaveNum = g.Sum(p => p.LeaveNum),//遗留
                                NumTotal = g.Sum(p => p.NumTotal)//单省分非包月付费用户数
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
        /// 获取渠道投诉统计数据(未完成)
        /// </summary>
        public ExtentionChannelComplainAnalysis GetChannelAnalysisComplain(int PageSize, int PageIndex, out int totalCount, ChannelComplainParam pra)
        {
            totalCount = 0;
            ////0.查询条件 作品名,月份
            //if (pra.selmonth == null || pra.selmonth.ToString() == "0001/1/1 0:00:00")
            //{
            //    pra.selmonth=DateTime.Now;//当月
            //}
            pra.selmonth = new DateTime(2014, 3, 1);
            //1.查询所有当月作品,及该作品的非包月付费用户数
            var MonthSource = from q in _db.Admin_ExcelResourceForMonth where q.StatisticsTime.Month == pra.selmonth.Month && q.StatisticsTime.Year == pra.selmonth.Year group q by q.SingleOpusName into g select new { g.Key, NotBaoyuePayBillPlayNum = g.Sum(s => s.NotBaoyuePayBillPlayNum) };

            //2.循环计算查取对应作品的数据
            List<ChannelComplainResult> resultList = new List<ChannelComplainResult>();
            ChannelComplainResult result;
            foreach (var item in MonthSource)
            {
                result = new ChannelComplainResult();
                result.notMonthPayCusNum = item.NotBaoyuePayBillPlayNum;
                result.OpusName = item.Key;
            }
            //3.填入查询结果对象
            //return new ExtentionChannelComplainAnalysis();


            return new ExtentionChannelComplainAnalysis();
        }

        #region 分CP投诉万投比(即投诉统计)(进行中)
        /// <summary>
        ///获取制定日期的分CP投诉万投比(即投诉统计)
        /// </summary>
        /// <param name="tm"></param>
        public ExtentionCbag GetGroupByCPAnalysis(int PageSize, int PageIndex, out int totalCount, DateTime tm)
        {
            //取出所有数据
            var ComplainTable = from p in _db.Admin_ExcelResourceForComplain select p;
            //取出所有CP数据
            var CPcompanyTable = from p in _db.Admin_CPcompany select p;
            //取出投诉表与cp表关联的所有CP(按cp和城市线级分组)
            var allCp = from p in ComplainTable join s in CPcompanyTable on p.CPid equals s.ID group p by new { p.CPid, s.CPname } into t select new { t.Key.CPid, t.Key.CPname };
            //非包月付费用户数累计表数据(按CP分组)
            var notBaoyue = from p in _db.Admin_NotBaoyuePayBillPlayCount
                            where p.AddTime <= tm
                            group p by new { p.CpID } into g
                            select new
                            {
                                CpID = g.Key.CpID,
                                AddNum = g.Sum(p => p.AddNum),//新增
                                LeaveNum = g.Sum(p => p.LeaveNum),//遗留
                                NumTotal = g.Sum(p => p.NumTotal)//非包月付费用户数
                            };
            //当前查询时间的前一天的数据
            DateTime lastTime = tm.AddDays(-1);
            var lastnotBaoyue = from p in _db.Admin_NotBaoyuePayBillPlayCount
                                where p.AddTime <= lastTime
                                group p by new { p.CpID } into g
                                select new
                                {
                                    CpID = g.Key.CpID,
                                    AddNum = g.Sum(p => p.AddNum),//新增
                                    LeaveNum = g.Sum(p => p.LeaveNum),//遗留
                                    NumTotal = g.Sum(p => p.NumTotal)//非包月付费用户 数
                                };
            //按按cp分类的分析结果
            List<ComplainAnalysisSearchResult> cpList = new List<ComplainAnalysisSearchResult>();
            ComplainAnalysisSearchResult rmodel = null;
            //循环所有CP分类
            foreach (var item in allCp)//循环按cp分组得出的cp列表
            {
                //筛选出一个cp
                var cpComplain = ComplainTable.Where(s => s.CPid == item.CPid);
                //按地区分组统计
                //1.一线新增
                var flAddPop = (from p in cpComplain
                                join s in allCp on p.CPid equals s.CPid
                                where p.OrderTime > tm && p.CPid == item.CPid && p.SourceLevel.Contains("一线")
                                select s.CPid).Count();
                //1.1二线新增
                var sdAddPop = (from p in cpComplain
                                join s in allCp on p.CPid equals s.CPid
                                where p.OrderTime > tm && p.CPid == item.CPid && p.SourceLevel.Contains("二线")
                                select s.CPid).Count();

                //2.一线遗留
                var flleavePop = (from p in cpComplain
                                  join s in allCp on p.CPid equals s.CPid
                                  where p.OrderTime <= tm && p.CPid == item.CPid && p.SourceLevel.Contains("一线")
                                  select s.CPid).Count();
                //2.1二线遗留
                var sdleavePop = (from p in cpComplain
                                  join s in allCp on p.CPid equals s.CPid
                                  where p.OrderTime <= tm && p.CPid == item.CPid && p.SourceLevel.Contains("二线")
                                  select s.CPid).Count();
                //新增日期的昨天记录(一线)
                DateTime praseltime = tm.AddDays(-1);
                var flyesterdayAddPop = (from p in cpComplain
                                         join s in allCp on p.CPid equals s.CPid
                                         where p.OrderTime > praseltime && p.CPid == item.CPid && p.SourceLevel.Contains("一线")
                                         select s.CPid).Count();
                //新增日期的昨天记录(二线)
                var sdyesterdayAddPop = (from p in cpComplain
                                         join s in allCp on p.CPid equals s.CPid
                                         where p.OrderTime > praseltime && p.CPid == item.CPid && p.SourceLevel.Contains("二线")
                                         select s.CPid).Count();

                //一线总
                var flzong = flAddPop + flleavePop;//一线新增+一线遗留

                //二线总
                var sdzong = sdAddPop + sdleavePop;//二线新增+二线遗留

                //一线-非包月付费用户数
                var flnbpNum = notBaoyue.Where(s => s.CpID == item.CPid).FirstOrDefault() != null ? notBaoyue.Where(s => s.CpID == item.CPid).FirstOrDefault().NumTotal : 0;
                //(昨日)一线-非包月付费用户数(用于计算一线(昨日)新增万投比)
                var lastflnbpNum = lastnotBaoyue.Where(s => s.CpID == item.CPid).FirstOrDefault() != null ? lastnotBaoyue.Where(s => s.CpID == item.CPid).FirstOrDefault().NumTotal : 0;
                //一线新增万投比
                double fladdwtb = 0;
                if (flnbpNum != 0)
                {
                    fladdwtb = flAddPop / flnbpNum * 10000;
                }

                //二线新增万投比
                double sdaddwtb = 0;
                if (flnbpNum != 0)
                {
                    sdaddwtb = sdAddPop / flnbpNum * 10000;
                }
                

                //一线(昨日)新增万投比
                double lastfladdwtb = 0;
                if (lastflnbpNum != 0)
                {
                    lastfladdwtb = sdyesterdayAddPop / lastflnbpNum * 10000;
                }

                //二线(昨日)新增万投比
                double lastsdaddwtb = 0;
                if (lastflnbpNum != 0)
                {
                    lastsdaddwtb = flyesterdayAddPop / lastflnbpNum * 10000;
                }

                //一线全网万投比
                double flallwtb = 0;
                if (flallwtb != 0)
                {
                    flallwtb = flzong / flnbpNum * 10000;
                }
                //二线全网万投比
                double sdallwtb = 0;
                if (sdallwtb != 0)
                {
                    sdallwtb = sdzong / flnbpNum * 10000;
                }

                rmodel = new ComplainAnalysisSearchResult();
                rmodel.cpname = item.CPname;
                rmodel.nbpNum = flnbpNum;
                rmodel.yesterdayflAddPop = flyesterdayAddPop;
                rmodel.flAddPop = flAddPop;
                rmodel.flleaveNum = flleavePop;
                rmodel.flCount = flzong;
                rmodel.flytproportion = fladdwtb;
                rmodel.flproportion = flallwtb;
                rmodel.yesterdaysdAddPop = sdyesterdayAddPop;
                rmodel.sdAddPop = sdAddPop;
                rmodel.sdleaveNum = sdleavePop;
                rmodel.sdCount = sdzong;
                rmodel.sdytproportion=lastsdaddwtb;
                rmodel.sdtdproportion=sdaddwtb;
                rmodel.sdproportion = sdallwtb;

                //添加到列表
                cpList.Add(rmodel);
            }
            var query = cpList.OrderBy(s => s.cpname).ToList();


            totalCount = query.Count();
            var cbag = new List<ComplainAnalysisSearchResult>();
            var bagResult= new ExtentionCbag();
            
            if (PageIndex < 0 || PageSize < 0)
            {
                return null;
            }
            if (PageIndex == 1 && PageSize > totalCount)
            {
                bagResult.cbag = query.ToList();
            }
            else if (PageIndex == 1 && PageSize > 0)
            {
                bagResult.cbag = query.Take(PageSize).ToList();
            }
            else
            {
                bagResult.cbag = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            }
            bagResult.SelTime = tm;
            return bagResult;
        }
        
        #endregion
    }
}
