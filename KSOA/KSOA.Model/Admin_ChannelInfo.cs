using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Model
{
    public class Admin_ChannelInfo
    {
        public Admin_ChannelInfo()
        { }
        #region Model
        private int _id;
        private string _channelname;
        private DateTime _addtime;
        private bool _isdelete;
        /// <summary>
        /// 渠道表ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public string ChannelName
        {
            set { _channelname = value; }
            get { return _channelname; }
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
