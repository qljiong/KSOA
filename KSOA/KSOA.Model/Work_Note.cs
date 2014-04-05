using System;
namespace KSOA.Model
{
	/// <summary>
	/// Work_Note:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Work_Note
	{
		public Work_Note()
		{}
		#region Model
		private int _id;
		private string _wtype;
		private int _writerid;
		private string _writername;
		private string _wtitle;
		private string _wconetent;
		private int _wtaster;
		private bool _isdelete= false;
		private DateTime _addtime= DateTime.Now;
        private bool _isread;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 工作报告类型;D:日报,W:周报,M:月报
		/// </summary>
		public string WType
		{
			set{ _wtype=value;}
			get{return _wtype;}
		}
		/// <summary>
		/// 填写人ID
		/// </summary>
		public int WriterID
		{
			set{ _writerid=value;}
			get{return _writerid;}
		}
		/// <summary>
		/// 工作报告填写人
		/// </summary>
		public string WriterName
		{
			set{ _writername=value;}
			get{return _writername;}
		}
		/// <summary>
		/// 日报标题
		/// </summary>
		public string WTitle
		{
			set{ _wtitle=value;}
			get{return _wtitle;}
		}
		/// <summary>
		/// 工作报告内容
		/// </summary>
		public string WConetent
		{
			set{ _wconetent=value;}
			get{return _wconetent;}
		}
		/// <summary>
		/// 日报审阅人ID
		/// </summary>
		public int WTaster
		{
			set{ _wtaster=value;}
			get{return _wtaster;}
		}
		/// <summary>
		/// 是否已删除；0：未删除，1：已删除
		/// </summary>
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 条目添加时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
        /// 是否已阅;true:是,false:否
		/// </summary>
        public bool IsRead
		{
            set { _isread = value; }
            get { return _isread; }
		}
		#endregion Model

	}
}

