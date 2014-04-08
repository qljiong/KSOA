using System;
namespace KSOA.Model
{
    /// <summary>
    /// Bank_CommercialOpus:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Bank_CommercialOpus
    {
        public Bank_CommercialOpus()
        { }
        #region Model
        private int _id;
        private int _opusid;
        private string _oupsname;
        private string _companyname;
        private string _cpaddress;
        private string _channeladdress;
        private DateTime _addtime = DateTime.Now;
        private bool _isdelete = false;

        /// <summary>
        /// 作品名称
        /// </summary>
        public string Oupsname
        {
            get { return _oupsname; }
            set { _oupsname = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 作品ID,关联Bank_Opus的id
        /// </summary>
        public int OpusID
        {
            set { _opusid = value; }
            get { return _opusid; }
        }
        /// <summary>
        /// 作品使用公司名称
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 作品CP地址
        /// </summary>
        public string CpAddress
        {
            set { _cpaddress = value; }
            get { return _cpaddress; }
        }
        /// <summary>
        /// 作品渠道地址
        /// </summary>
        public string ChannelAddress
        {
            set { _channeladdress = value; }
            get { return _channeladdress; }
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

