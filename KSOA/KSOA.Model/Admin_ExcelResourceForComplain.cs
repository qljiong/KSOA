using System;
namespace KSOA.Model
{
    /// <summary>
    /// Admin_ExcelResourceForComplain:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Admin_ExcelResourceForComplain
    {
        public Admin_ExcelResourceForComplain()
        { }
        #region Model
        private int _id;
        private DateTime _filedatetime;
        private string _usernumber;
        private string _province;
        private DateTime _ordertime;
        private string _businessname;
        private decimal _payamount;
        private DateTime _addtime = DateTime.Now;
        private bool _isdelete = false;
        private int _cpid;
        private string _sourcelevel;

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
        /// 源数据表,投诉表ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 投诉归档日期
        /// </summary>
        public DateTime FileDateTime
        {
            set { _filedatetime = value; }
            get { return _filedatetime; }
        }
        /// <summary>
        /// 用户号码
        /// </summary>
        public string UserNumber
        {
            set { _usernumber = value; }
            get { return _usernumber; }
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
        /// 订购日期
        /// </summary>
        public DateTime OrderTime
        {
            set { _ordertime = value; }
            get { return _ordertime; }
        }
        /// <summary>
        /// 订购业务名称
        /// </summary>
        public string BusinessName
        {
            set { _businessname = value; }
            get { return _businessname; }
        }
        /// <summary>
        /// 支付费用
        /// </summary>
        public decimal PayAmount
        {
            set { _payamount = value; }
            get { return _payamount; }
        }
        /// <summary>
        /// 条目增加时间
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

