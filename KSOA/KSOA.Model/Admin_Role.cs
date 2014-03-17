using System;
namespace KSOA.Model
{
	/// <summary>
	/// Admin_Role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin_Role
	{
		public Admin_Role()
		{}
		#region Model
		private int _id;
		private string _rolename;
		private bool _input= false;
		private bool _see= false;
		private bool _import= false;
		private bool _export= false;
		private string _rolenote;
		private bool _isdelete= false;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 角色表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 录入的权限
		/// </summary>
		public bool Input
		{
			set{ _input=value;}
			get{return _input;}
		}
		/// <summary>
		/// 查看的权限
		/// </summary>
		public bool See
		{
			set{ _see=value;}
			get{return _see;}
		}
		/// <summary>
		/// 导入的权限
		/// </summary>
		public bool Import
		{
			set{ _import=value;}
			get{return _import;}
		}
		/// <summary>
		/// 导出的权限
		/// </summary>
		public bool Export
		{
			set{ _export=value;}
			get{return _export;}
		}
		/// <summary>
		/// 角色权限描述
		/// </summary>
		public string RoleNote
		{
			set{ _rolenote=value;}
			get{return _rolenote;}
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

