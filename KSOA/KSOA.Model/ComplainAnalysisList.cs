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
}
