using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Model
{
    public class ComplainAnalysisList
    {
        /// <summary>
        /// CP内容提供商名称
        /// </summary>
        public string CpName { get; set; }
        /// <summary>
        /// 一线,二线...
        /// </summary>
        public string SourceLevel { get; set; }
        /// <summary>
        /// 每个地区的统计详细列表
        /// </summary>
        public List<ComplainAnalysisModel> caList { get; set; }
    }

    /// <summary>
    /// 分析结果单挑实体
    /// </summary>
    public class ComplainAnalysisModel
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string privnce { get; set; }
        /// <summary>
        /// 单省份非包月付费用户数
        /// </summary>
        public int notBaoyuePayUserNum { get; set; }
        /// <summary>
        /// 昨日的新增
        /// </summary>
        public int yesterdayAddNum { get; set; }
        /// <summary>
        /// 新增
        /// </summary>
        public int AddNum { get; set; }
        /// <summary>
        /// 遗留
        /// </summary>
        public int LeaveNum { get; set; }
        /// <summary>
        /// 万投比
        /// </summary>
        public double proportion { get; set; }
    }

    #region 投诉统计查询结果类
    public class ComplainAnalysisSearchResult
    {
        /// <summary>
        /// 查询时间标签
        /// </summary>
        public DateTime signDate
        {
            get;
            set;
        }
        /// <summary>
        /// cp名称
        /// </summary>
        public string cpname { get; set; }
        /// <summary>
        /// 非包月付费用户数
        /// </summary>
        public int nbpNum { get; set; }
        /// <summary>
        /// 一线昨日新增
        /// </summary>
        public int yesterdayflAddPop { get; set; }
        /// <summary>
        /// 一线今日新增
        /// </summary>
        public int flAddPop { get; set; }
        /// <summary>
        /// 一线遗留
        /// </summary>
        public int flleaveNum { get; set; }
        /// <summary>
        /// 一线总
        /// </summary>
        public int flCount { get; set; }
        /// <summary>
        /// 一线(新增)万投比,昨天
        /// </summary>
        public double flytproportion { get; set; }
        /// <summary>
        /// 一线(新增)万投比,今天
        /// </summary>
        public double fltdproportion { get; set; }
        /// <summary>
        /// 一线全网万投比
        /// </summary>
        public double flproportion { get; set; }


        /// <summary>
        /// 二线昨日新增
        /// </summary>
        public int yesterdaysdAddPop { get; set; }
        /// <summary>
        /// 二线今日新增
        /// </summary>
        public int sdAddPop { get; set; }
        /// <summary>
        /// 二线遗留
        /// </summary>
        public int sdleaveNum { get; set; }
        /// <summary>
        /// 二线总
        /// </summary>
        public int sdCount { get; set; }
        /// <summary>
        /// 二线(新增)万投比,昨天
        /// </summary>
        public double sdytproportion { get; set; }
        /// <summary>
        /// 二线(新增)万投比,今天
        /// </summary>
        public double sdtdproportion { get; set; }
        /// <summary>
        /// 二线全网万投比
        /// </summary>
        public double sdproportion { get; set; }
    }

    /// <summary>
    /// 查询结果返回辅助类,便于传递查询参数和查询结果的列表集合
    /// </summary>
    public class ExtentionCbag
    {
        /// <summary>
        /// 查询结果列表集合
        /// </summary>
        public List<ComplainAnalysisSearchResult> cbag { get; set; }
        /// <summary>
        /// 查询的时间
        /// </summary>
        public DateTime SelTime { get; set; }
    }
    #endregion
}
