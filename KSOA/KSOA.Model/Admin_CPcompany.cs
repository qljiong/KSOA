using System;
namespace KSOA.Model
{
    /// <summary>
    /// Admin_CPcompany:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Admin_CPcompany
    {
        public Admin_CPcompany()
        { }
        #region Model
        private int _id;
        private string _cpname;
        private DateTime _addtime = DateTime.Now;
        private bool _isdelete = false;
        /// <summary>
        /// CP内容提供商表ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 内容提供商名称
        /// </summary>
        public string CPname
        {
            set { _cpname = value; }
            get { return _cpname; }
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

