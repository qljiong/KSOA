using System;
namespace KSOA.Model
{
    /// <summary>
    /// Admin_ExcelResourceForMonth:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Admin_ExcelResourceForMonth
    {
        public Admin_ExcelResourceForMonth()
        { }
        #region Model
        private int _id;
        private int _cpid;
        private string _sourcelevel;
        private int _rownumber;
        private DateTime _statisticstime;
        private string _singleopusname;
        private int _notbaoyueplaynum;
        private int _baoyueplaynum;
        private int _paybillplaynum;
        private int _freeplaynum;
        private int _notbaoyuepaybillplaynum;
        private DateTime _addtime=DateTime.Now;
        private bool _isdelete = false;
        /// <summary>
        /// Excel源数据表(包月)ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 来源公司,从属于哪个公司(CP),外键关联Admin_CPcompany表的ID
        /// </summary>
        public int CPid
        {
            set { _cpid = value; }
            get { return _cpid; }
        }
        /// <summary>
        /// 一线,二线划分
        /// </summary>
        public string SourceLevel
        {
            set { _sourcelevel = value; }
            get { return _sourcelevel; }
        }
        /// <summary>
        /// 行号
        /// </summary>
        public int RowNumber
        {
            set { _rownumber = value; }
            get { return _rownumber; }
        }
        /// <summary>
        /// 统计日期
        /// </summary>
        public DateTime StatisticsTime
        {
            set { _statisticstime = value; }
            get { return _statisticstime; }
        }
        /// <summary>
        /// 单部名称
        /// </summary>
        public string SingleOpusName
        {
            set { _singleopusname = value; }
            get { return _singleopusname; }
        }
        /// <summary>
        /// 非包月点播次数
        /// </summary>
        public int NotBaoyuePlayNum
        {
            set { _notbaoyueplaynum = value; }
            get { return _notbaoyueplaynum; }
        }
        /// <summary>
        /// 包月点播次数
        /// </summary>
        public int BaoyuePlayNum
        {
            set { _baoyueplaynum = value; }
            get { return _baoyueplaynum; }
        }
        /// <summary>
        /// 付费点播次数
        /// </summary>
        public int PayBillPlayNum
        {
            set { _paybillplaynum = value; }
            get { return _paybillplaynum; }
        }
        /// <summary>
        /// 免费点播次数
        /// </summary>
        public int FreePlayNum
        {
            set { _freeplaynum = value; }
            get { return _freeplaynum; }
        }
        /// <summary>
        /// 非包月付费点播次数
        /// </summary>
        public int NotBaoyuePayBillPlayNum
        {
            set { _notbaoyuepaybillplaynum = value; }
            get { return _notbaoyuepaybillplaynum; }
        }
        /// <summary>
        /// 条目添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 是否已删除；0：未删除，1：已删除
        /// </summary>
        public bool IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

