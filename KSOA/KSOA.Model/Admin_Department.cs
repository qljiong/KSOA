using System;
namespace KSOA.Model
{
	/// <summary>
	/// Admin_Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin_Department
	{
		public Admin_Department()
		{}
		#region Model
		private int _id;
		private string _dpname;
		private bool _isdelete= false;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 部门表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
        /// 部门名称
		/// </summary>
		public string DpName
		{
			set{ _dpname=value;}
			get{return _dpname;}
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

