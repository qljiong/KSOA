using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Model
{
    /// <summary>
    /// 投诉分析查询辅助
    /// </summary>
    public class ComplainParam
    {
        /// <summary>
        /// 选定时间
        /// </summary>
        public DateTime seltime { get; set; }
        /// <summary>
        /// 线级
        /// </summary>
        public string selline { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string selkeywords { get; set; }
    }

    /// <summary>
    /// 投诉分析查询包
    /// </summary>
    public class ExtentionComplainBag
    {
        public List<ComplainAnalysisList> list { get; set; }
        public ComplainParam par { get; set; }
    }

    /// <summary>
    /// 包月分析查询辅助
    /// </summary>
    public class MonthParam
    {
        /// <summary>
        /// 选定时间
        /// </summary>
        public DateTime seltime { get; set; }
        /// <summary>
        /// 作品名
        /// </summary>
        public string selOpusName { get; set; }
        /// <summary>
        /// CP名称
        /// </summary>
        public string selCPName { get; set; }

        ///// <summary>
        ///// CPID
        ///// </summary>
        //public int selCPID { get; set; }
    }

    /// <summary>
    /// 包月管理查询辅助类
    /// </summary>
    public class ExtentionMonthBag
    {
        public List<Admin_ExcelResourceForMonth> list { get; set; }
        public MonthParam par { get; set; }
    }

    /// <summary>
    /// 收入统计查询辅助类
    /// </summary>
    public class IncomeAnalysisParam
    {
        /// <summary>
        /// cp渠道id
        /// </summary>
        public int cpid { get; set; }
        /// <summary>
        /// cp渠道名称
        /// </summary>
        public string cpname { get; set; }
        /// <summary>
        /// 作品归属
        /// </summary>
        public string fromcp { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string opusName { get; set; }

        DateTime seltime = DateTime.Now;
        /// <summary>
        /// 选择的查询时间
        /// </summary>
        public DateTime selTime
        {
            get { return seltime; }
            set { seltime = value; }
        }
    }

    /// <summary>
    /// 收入查询结果列表类
    /// </summary>
    public class IncomeResult
    {
        public int cpid { get; set; }
        public string CPname { get; set; }
        /// <summary>
        /// 累计次数
        /// </summary>
        public int SumNum { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string SingleOpusName { get; set; }
        /// <summary>
        /// 统计时间
        /// </summary>
        public string AnalyTime { get; set; }
    }

    /// <summary>
    /// 收入统计查询辅助类
    /// </summary>
    public class ExtentionIncomeAnalysis
    {
        /// <summary>
        /// 分析结果对象列表
        /// </summary>
        public List<IncomeResult> list { get; set; }
        /// <summary>
        /// 查询参数
        /// </summary>
        public IncomeAnalysisParam par { get; set; }


    }

    /// <summary>
    /// 渠道投诉统计查询辅助类
    /// </summary>
    public class ChannelComplainParam
    {
        /// <summary>
        /// 选择的月份
        /// </summary>
        public DateTime selmonth { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string cpName { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string opusName { get; set; }
        /// <summary>
        /// 推广渠道商
        /// </summary>
        public string cpname { get; set; }
    }
    /// <summary>
    /// 渠道投诉分析查询结果类
    /// </summary>
    public class ChannelComplainResult
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string companyName { get; set; }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public string cpName { get; set; }
        /// <summary>
        /// 作品名
        /// </summary>
        public string OpusName { get; set; }
        /// <summary>
        /// 推广渠道商
        /// </summary>
        public string ChannelPro { get; set; }
        /// <summary>
        /// 非包月付费用户数
        /// </summary>
        public int notMonthPayCusNum { get; set; }
        /// <summary>
        /// 一线遗留
        /// </summary>
        public int firstLineLeave { get; set; }
        /// <summary>
        /// 一线新增
        /// </summary>
        public int firstLineAdd { get; set; }
        /// <summary>
        /// 一线总
        /// </summary>
        public int firstLineSum { get; set; }
        /// <summary>
        /// 二线遗留
        /// </summary>
        public int secondLineLeave { get; set; }
        /// <summary>
        /// 二线新增
        /// </summary>
        public int secondLineAdd { get; set; }
        /// <summary>
        /// 二线总
        /// </summary>
        public int secondLineSum { get; set; }
        /// <summary>
        /// 一线新增万投比
        /// </summary>
        public double firstLinedAddPercent { get; set; }
        /// <summary>
        /// 一线总万投比
        /// </summary>
        public double firstLineSumPercent { get; set; }
        /// <summary>
        /// 二线新增万投比
        /// </summary>
        public double secondLinedAddPercent { get; set; }
        /// <summary>
        /// 二线总万投比
        /// </summary>
        public double secondLineSumPercent { get; set; }

    }

    /// <summary>
    /// 渠道投诉统计查询辅助类
    /// </summary>
    public class ExtentionChannelComplainAnalysis
    {
        List<ChannelComplainResult> list { get; set; }
        public ChannelComplainParam par { get; set; }
    }
}
