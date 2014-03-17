using System;
namespace KSOA.Model
{
	/// <summary>
	/// Work_Notice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Work_Notice
	{
		public Work_Notice()
		{}
		#region Model
		private int _id;
		private string _ntitle;
		private string _ncontent;
		private int _ncustomerid;
		private string _ncustomername;
		private int _nlevel;
		private DateTime _addtime= DateTime.Now;
		private bool _isdelete= false;
		private string _nip;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 公告标题
		/// </summary>
		public string NTitle
		{
			set{ _ntitle=value;}
			get{return _ntitle;}
		}
		/// <summary>
		/// 公告内容
		/// </summary>
		public string NContent
		{
			set{ _ncontent=value;}
			get{return _ncontent;}
		}
		/// <summary>
		/// 发布人ID
		/// </summary>
		public int NCustomerID
		{
			set{ _ncustomerid=value;}
			get{return _ncustomerid;}
		}
		/// <summary>
		/// 发布人名称
		/// </summary>
		public string NCustomerName
		{
			set{ _ncustomername=value;}
			get{return _ncustomername;}
		}
		/// <summary>
		/// 公告级别,1,2,3,4;1的级别最大
		/// </summary>
		public int Nlevel
		{
			set{ _nlevel=value;}
			get{return _nlevel;}
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
		/// <summary>
		/// 发布人IP
		/// </summary>
		public string NIP
		{
			set{ _nip=value;}
			get{return _nip;}
		}
		#endregion Model

	}
}

