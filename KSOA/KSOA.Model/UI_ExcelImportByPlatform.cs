using System;
namespace KSOA.Model
{
	/// <summary>
	/// UI_ExcelImportByPlatform:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UI_ExcelImportByPlatform
	{
		public UI_ExcelImportByPlatform()
		{}
		#region Model
		private int _id;
		private int _customerid;
		private string _extype;
		private DateTime _extime;
		private string _excpname;
		private string _exopusname;
		private string _excooperation;
		private int _excollectnum;
		private int _exsinglecollectnum;
		private decimal _exopusunitprice;
		private decimal _exaccountprice;
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
		/// 导入操作人ID
		/// </summary>
		public int CustomerID
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 导入类别;W:WAP,S:SDK,Q:渠道
		/// </summary>
		public string ExType
		{
			set{ _extype=value;}
			get{return _extype;}
		}
		/// <summary>
		/// 导入表单里的时间
		/// </summary>
		public DateTime ExTime
		{
			set{ _extime=value;}
			get{return _extime;}
		}
		/// <summary>
		/// CP(内容提供商)名称
		/// </summary>
		public string ExCpName
		{
			set{ _excpname=value;}
			get{return _excpname;}
		}
		/// <summary>
		/// 作品名称
		/// </summary>
		public string ExOpusName
		{
			set{ _exopusname=value;}
			get{return _exopusname;}
		}
		/// <summary>
		/// 对应合作渠道推广商
		/// </summary>
		public string ExCooperation
		{
			set{ _excooperation=value;}
			get{return _excooperation;}
		}
		/// <summary>
		/// 作品对应集数
		/// </summary>
		public int ExCollectNum
		{
			set{ _excollectnum=value;}
			get{return _excollectnum;}
		}
		/// <summary>
		/// 单集计费条数
		/// </summary>
		public int ExSingleCollectNum
		{
			set{ _exsinglecollectnum=value;}
			get{return _exsinglecollectnum;}
		}
		/// <summary>
		/// 作品单价
		/// </summary>
		public decimal ExOpusUnitPrice
		{
			set{ _exopusunitprice=value;}
			get{return _exopusunitprice;}
		}
		/// <summary>
		/// 结算金额
		/// </summary>
		public decimal ExAccountPrice
		{
			set{ _exaccountprice=value;}
			get{return _exaccountprice;}
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

