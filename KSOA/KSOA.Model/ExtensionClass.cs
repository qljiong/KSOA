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
    public class ExtentionMonthBag
    {
        public List<Admin_ExcelResourceForMonth> list { get; set; }
        public MonthParam par { get; set; }
    }
}
