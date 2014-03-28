using System;
namespace KSOA.Model
{
	/// <summary>
	/// Admin_KSCustomer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin_KSCustomer
	{
		public Admin_KSCustomer()
		{}
		#region Model
		private int _id;
		private string _roleid;
		private string _realname="";
		private string _cusname;
		private string _gender="z";
		private int _age=0;
		private string _cuspwd;
		private string _cusemail;
		private string _cusphonenum;
		private string _qq="";
        private string _oldcuspwd;
		private bool _isdelete= false;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 用户表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 外键关联Admin_Role表的ID
		/// </summary>
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 用户名(昵称)
		/// </summary>
		public string CusName
		{
			set{ _cusname=value;}
			get{return _cusname;}
		}
		/// <summary>
		/// 性别;X:女,Y:男,Z:未知
		/// </summary>
		public string Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public int Age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 用户密码（需MD5混淆过的）
		/// </summary>
		public string CusPwd
		{
			set{ _cuspwd=value;}
			get{return _cuspwd;}
		}
        /// <summary>
		/// 用户旧密码（更新用户信息时使用）
		/// </summary>
        public string Oldcuspwd
		{
            set { _oldcuspwd = value; }
            get { return _oldcuspwd; }
		}
		/// <summary>
		/// 用户邮箱（可做登陆用），设置唯一约束
		/// </summary>
		public string CusEmail
		{
			set{ _cusemail=value;}
			get{return _cusemail;}
		}
		/// <summary>
		/// 用户手机（可做登陆用），设置唯一约束
		/// </summary>
		public string CusPhoneNum
		{
			set{ _cusphonenum=value;}
			get{return _cusphonenum;}
		}
		/// <summary>
		/// 用户qq
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
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

