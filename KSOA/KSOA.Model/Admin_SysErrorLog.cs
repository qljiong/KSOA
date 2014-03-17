using System;
namespace KSOA.Model
{
	/// <summary>
	/// Admin_SysErrorLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin_SysErrorLog
	{
		public Admin_SysErrorLog()
		{}
		#region Model
		private int _id;
		private string _pageurl;
		private string _errormsg;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 错误页面URL
		/// </summary>
		public string PageUrl
		{
			set{ _pageurl=value;}
			get{return _pageurl;}
		}
		/// <summary>
		/// 错误提示信息
		/// </summary>
		public string ErrorMsg
		{
			set{ _errormsg=value;}
			get{return _errormsg;}
		}
		/// <summary>
		/// 条目添加时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

