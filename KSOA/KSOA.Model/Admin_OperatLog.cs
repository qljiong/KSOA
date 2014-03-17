using System;
namespace KSOA.Model
{
	/// <summary>
	/// Admin_OperatLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin_OperatLog
	{
		public Admin_OperatLog()
		{}
		#region Model
		private int _id;
		private int _operatorid;
		private string _operatorname;
		private string _module;
		private string _operationcontent;
		private string _opip;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 系统操作日志表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 操作人ID,关联用户表的用户ID
		/// </summary>
		public int OperatorID
		{
			set{ _operatorid=value;}
			get{return _operatorid;}
		}
		/// <summary>
		/// 操作人名称
		/// </summary>
		public string OperatorName
		{
			set{ _operatorname=value;}
			get{return _operatorname;}
		}
		/// <summary>
		/// 操作的模块名称
		/// </summary>
		public string Module
		{
			set{ _module=value;}
			get{return _module;}
		}
		/// <summary>
		/// 操作详细描述
		/// </summary>
		public string OperationContent
		{
			set{ _operationcontent=value;}
			get{return _operationcontent;}
		}
		/// <summary>
		/// 操作人的Ip
		/// </summary>
		public string OpIp
		{
			set{ _opip=value;}
			get{return _opip;}
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

