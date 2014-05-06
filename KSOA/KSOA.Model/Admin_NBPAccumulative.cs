using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Model
{
    public class Admin_NBPAccumulative
    {
        public Admin_NBPAccumulative()
        { }
        #region Model
        private int _id;
        private DateTime _counttime;
        private string _province;
        private string _cpname;
        private int? _cpid;
        private int _nbpcount;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 统计日期
        /// </summary>
        public DateTime CountTime
        {
            set { _counttime = value; }
            get { return _counttime; }
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
        /// CP名称
        /// </summary>
        public string CpName
        {
            set { _cpname = value; }
            get { return _cpname; }
        }
        /// <summary>
        /// cpid(如果能关联的话)
        /// </summary>
        public int? CpID
        {
            set { _cpid = value; }
            get { return _cpid; }
        }
        /// <summary>
        /// 非包月付费用户数
        /// </summary>
        public int NBPCount
        {
            set { _nbpcount = value; }
            get { return _nbpcount; }
        }
        #endregion Model
    }
}
