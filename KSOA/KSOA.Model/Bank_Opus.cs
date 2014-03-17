using System;
namespace KSOA.Model
{
	/// <summary>
	/// Bank_Opus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Bank_Opus
	{
		public Bank_Opus()
		{}
		#region Model
		private int _id;
		private string _optype;
		private string _optitle;
		private string _opauthor;
		private DateTime _opbegintime;
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
		/// 作品类型;B:buy(作品购买),S:sell(销售)
		/// </summary>
		public string OpType
		{
			set{ _optype=value;}
			get{return _optype;}
		}
		/// <summary>
		/// 作品名称
		/// </summary>
		public string OpTitle
		{
			set{ _optitle=value;}
			get{return _optitle;}
		}
		/// <summary>
		/// 作者
		/// </summary>
		public string OpAuthor
		{
			set{ _opauthor=value;}
			get{return _opauthor;}
		}
		/// <summary>
		/// 发布,上架时间
		/// </summary>
		public DateTime OpBeginTime
		{
			set{ _opbegintime=value;}
			get{return _opbegintime;}
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

