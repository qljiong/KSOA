using System;
namespace KSOA.Model
{
	/// <summary>
	/// Work_Schedule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Work_Schedule
	{
		public Work_Schedule()
		{}
		#region Model
		private int _id;
		private string _itemname;
		private DateTime _itemlaunchtime;
		private DateTime _addtime= DateTime.Now;
		private bool _isdelete= false;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 项目发起时间
		/// </summary>
		public DateTime ItemLaunchTime
		{
			set{ _itemlaunchtime=value;}
			get{return _itemlaunchtime;}
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
		/// 是否已删除；0：未删除，1：已删除
		/// </summary>
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

