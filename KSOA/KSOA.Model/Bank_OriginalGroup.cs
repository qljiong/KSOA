using System;
namespace KSOA.Model
{
	/// <summary>
	/// Bank_OriginalGroup:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Bank_OriginalGroup
	{
		public Bank_OriginalGroup()
		{}
		#region Model
		private int _id;
		private string _opuscopyright;
		private string _creationinfo;
		private string _opusname;
		private string _opusauthor;
		private decimal _saleprice;
		private string _accreditplatform;
		private string _accreditcompany;
		private DateTime _accredittime;
		private string _accredittype;
		private string _awards;
		private string _opusmascot;
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
		/// 版权信息
		/// </summary>
		public string OpusCopyright
		{
			set{ _opuscopyright=value;}
			get{return _opuscopyright;}
		}
		/// <summary>
		/// 创作信息
		/// </summary>
		public string CreationInfo
		{
			set{ _creationinfo=value;}
			get{return _creationinfo;}
		}
		/// <summary>
		/// 作品名称
		/// </summary>
		public string OpusName
		{
			set{ _opusname=value;}
			get{return _opusname;}
		}
		/// <summary>
		/// 作者
		/// </summary>
		public string OpusAuthor
		{
			set{ _opusauthor=value;}
			get{return _opusauthor;}
		}
		/// <summary>
		/// 销售金额
		/// </summary>
		public decimal SalePrice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
		}
		/// <summary>
		/// 授权平台
		/// </summary>
		public string AccreditPlatform
		{
			set{ _accreditplatform=value;}
			get{return _accreditplatform;}
		}
		/// <summary>
		/// 授权公司
		/// </summary>
		public string AccreditCompany
		{
			set{ _accreditcompany=value;}
			get{return _accreditcompany;}
		}
		/// <summary>
		/// 授权日期
		/// </summary>
		public DateTime AccreditTime
		{
			set{ _accredittime=value;}
			get{return _accredittime;}
		}
		/// <summary>
		/// 授权类型
		/// </summary>
		public string AccreditType
		{
			set{ _accredittype=value;}
			get{return _accredittype;}
		}
		/// <summary>
		/// 获奖情况
		/// </summary>
		public string Awards
		{
			set{ _awards=value;}
			get{return _awards;}
		}
		/// <summary>
		/// 原创形象相关信息
		/// </summary>
		public string OpusMascot
		{
			set{ _opusmascot=value;}
			get{return _opusmascot;}
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

