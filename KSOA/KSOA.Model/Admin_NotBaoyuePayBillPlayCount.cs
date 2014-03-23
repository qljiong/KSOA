using System;
namespace KSOA.Model
{
    /// <summary>
    /// Admin_NotBaoyuePayBillPlayCount:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Admin_NotBaoyuePayBillPlayCount
    {
        public Admin_NotBaoyuePayBillPlayCount()
        { }
        #region Model
        private int _id;
        private string _cpname;
        private int _cpid;
        private string _province;
        private int _leavenum;
        private int _addnum;
        private int _numtotal;
        private DateTime _addtime = DateTime.Now;
        private bool _isdelete = false;
        /// <summary>
        /// 非包月付费用户数量统计表ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 内容提供商名称
        /// </summary>
        public string CpName
        {
            set { _cpname = value; }
            get { return _cpname; }
        }
        /// <summary>
        /// 内容提供商ID,外键关联Admin_CPcompany表ID
        /// </summary>
        public int CpID
        {
            set { _cpid = value; }
            get { return _cpid; }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 遗留数
        /// </summary>
        public int LeaveNum
        {
            set { _leavenum = value; }
            get { return _leavenum; }
        }
        /// <summary>
        /// 新增数
        /// </summary>
        public int AddNum
        {
            set { _addnum = value; }
            get { return _addnum; }
        }
        /// <summary>
        /// 总和=遗留数+新增数
        /// </summary>
        public int NumTotal
        {
            set { _numtotal = value; }
            get { return _numtotal; }
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

