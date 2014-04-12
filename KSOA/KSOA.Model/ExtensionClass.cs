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
}
