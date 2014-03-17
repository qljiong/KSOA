using System;
namespace KSOA.Model
{
	/// <summary>
	/// Admin_SysMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin_SysMenu
	{
		public Admin_SysMenu()
		{}
		#region Model
		private int _id;
		private int _parentid=0;
		private string _menuname;
		private string _menuurl;
		private int _orderindex;
		private int _adminroleid;
		private bool _isenable= true;
		private bool _isdelete= false;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 系统菜单表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 菜单级别ID;0:一级菜单,其它自关联当前表ID
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 菜单URL
		/// </summary>
		public string MenuUrl
		{
			set{ _menuurl=value;}
			get{return _menuurl;}
		}
		/// <summary>
		/// 菜单排序ID
		/// </summary>
		public int OrderIndex
		{
			set{ _orderindex=value;}
			get{return _orderindex;}
		}
		/// <summary>
		/// 关联AdminRole表的ID,外键
		/// </summary>
		public int AdminRoleID
		{
			set{ _adminroleid=value;}
			get{return _adminroleid;}
		}
		/// <summary>
		/// 是否启用;0:未启用,1:已启用
		/// </summary>
		public bool IsEnable
		{
			set{ _isenable=value;}
			get{return _isenable;}
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

