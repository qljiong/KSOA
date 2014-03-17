using System;
namespace KSOA.Model
{
	/// <summary>
	/// UI_ExcelImportByChannel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UI_ExcelImportByChannel
	{
		public UI_ExcelImportByChannel()
		{}
		#region Model
		private int _id;
		private int _customerid;
		private string _exspreadtype;
		private DateTime _extime;
		private string _exopusname;
		private int _excollectnum;
		private int _exchargecollectnum;
		private decimal _exopusunitprice;
		private decimal _exaccountprice;
		private int _exaccountcollectnum;
		private string _historypercent;
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
		/// 推广平台;Q:渠道,S:SDK,C:CP(内容提供商)
		/// </summary>
		public string ExSpreadType
		{
			set{ _exspreadtype=value;}
			get{return _exspreadtype;}
		}
		/// <summary>
		/// 日期:导入表单里的时间
		/// </summary>
		public DateTime ExTime
		{
			set{ _extime=value;}
			get{return _extime;}
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
		/// 作品对应的集数
		/// </summary>
		public int ExCollectNum
		{
			set{ _excollectnum=value;}
			get{return _excollectnum;}
		}
		/// <summary>
		/// 作品对应集数计费条数
		/// </summary>
		public int ExChargeCollectNum
		{
			set{ _exchargecollectnum=value;}
			get{return _exchargecollectnum;}
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
		/// 结算条数
		/// </summary>
		public int ExAccountCollectNum
		{
			set{ _exaccountcollectnum=value;}
			get{return _exaccountcollectnum;}
		}
		/// <summary>
		/// 渠道结算金额比例设置调整记录
		/// </summary>
		public string HistoryPercent
		{
			set{ _historypercent=value;}
			get{return _historypercent;}
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

