using System;
namespace KSOA.Model
{
	/// <summary>
	/// Admin_Platform:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin_Platform
	{
		public Admin_Platform()
		{}
		#region Model
		private int _id;
		private string _ptype;
		private string _pname;
		private bool _isdelete= false;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 平台表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 平台类型;CP,渠道,SDK,合作渠道
		/// </summary>
		public string PType
		{
			set{ _ptype=value;}
			get{return _ptype;}
		}
		/// <summary>
		/// 平台名称
		/// </summary>
		public string PName
		{
			set{ _pname=value;}
			get{return _pname;}
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
		#endregion Model

	}
}

