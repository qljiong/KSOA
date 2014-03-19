using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KSOA.DAL
{
	/// <summary>
	/// 数据访问类:Bank_OriginalGroup
	/// </summary>
	public partial class Bank_OriginalGroup
	{
		public Bank_OriginalGroup()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Bank_OriginalGroup"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Bank_OriginalGroup");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KSOA.Model.Bank_OriginalGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Bank_OriginalGroup(");
			strSql.Append("OpusCopyright,CreationInfo,OpusName,OpusAuthor,SalePrice,AccreditPlatform,AccreditCompany,AccreditTime,AccreditType,Awards,OpusMascot,AddTime,IsDelete)");
			strSql.Append(" values (");
			strSql.Append("@OpusCopyright,@CreationInfo,@OpusName,@OpusAuthor,@SalePrice,@AccreditPlatform,@AccreditCompany,@AccreditTime,@AccreditType,@Awards,@OpusMascot,@AddTime,@IsDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OpusCopyright", SqlDbType.NVarChar,300),
					new SqlParameter("@CreationInfo", SqlDbType.NVarChar,50),
					new SqlParameter("@OpusName", SqlDbType.NVarChar,300),
					new SqlParameter("@OpusAuthor", SqlDbType.NVarChar,50),
					new SqlParameter("@SalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@AccreditPlatform", SqlDbType.NVarChar,50),
					new SqlParameter("@AccreditCompany", SqlDbType.NVarChar,50),
					new SqlParameter("@AccreditTime", SqlDbType.DateTime),
					new SqlParameter("@AccreditType", SqlDbType.NVarChar,50),
					new SqlParameter("@Awards", SqlDbType.NVarChar,-1),
					new SqlParameter("@OpusMascot", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1)};
			parameters[0].Value = model.OpusCopyright;
			parameters[1].Value = model.CreationInfo;
			parameters[2].Value = model.OpusName;
			parameters[3].Value = model.OpusAuthor;
			parameters[4].Value = model.SalePrice;
			parameters[5].Value = model.AccreditPlatform;
			parameters[6].Value = model.AccreditCompany;
			parameters[7].Value = model.AccreditTime;
			parameters[8].Value = model.AccreditType;
			parameters[9].Value = model.Awards;
			parameters[10].Value = model.OpusMascot;
			parameters[11].Value = model.AddTime;
			parameters[12].Value = model.IsDelete;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KSOA.Model.Bank_OriginalGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Bank_OriginalGroup set ");
			strSql.Append("OpusCopyright=@OpusCopyright,");
			strSql.Append("CreationInfo=@CreationInfo,");
			strSql.Append("OpusName=@OpusName,");
			strSql.Append("OpusAuthor=@OpusAuthor,");
			strSql.Append("SalePrice=@SalePrice,");
			strSql.Append("AccreditPlatform=@AccreditPlatform,");
			strSql.Append("AccreditCompany=@AccreditCompany,");
			strSql.Append("AccreditTime=@AccreditTime,");
			strSql.Append("AccreditType=@AccreditType,");
			strSql.Append("Awards=@Awards,");
			strSql.Append("OpusMascot=@OpusMascot,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("IsDelete=@IsDelete");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OpusCopyright", SqlDbType.NVarChar,300),
					new SqlParameter("@CreationInfo", SqlDbType.NVarChar,50),
					new SqlParameter("@OpusName", SqlDbType.NVarChar,300),
					new SqlParameter("@OpusAuthor", SqlDbType.NVarChar,50),
					new SqlParameter("@SalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@AccreditPlatform", SqlDbType.NVarChar,50),
					new SqlParameter("@AccreditCompany", SqlDbType.NVarChar,50),
					new SqlParameter("@AccreditTime", SqlDbType.DateTime),
					new SqlParameter("@AccreditType", SqlDbType.NVarChar,50),
					new SqlParameter("@Awards", SqlDbType.NVarChar,-1),
					new SqlParameter("@OpusMascot", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OpusCopyright;
			parameters[1].Value = model.CreationInfo;
			parameters[2].Value = model.OpusName;
			parameters[3].Value = model.OpusAuthor;
			parameters[4].Value = model.SalePrice;
			parameters[5].Value = model.AccreditPlatform;
			parameters[6].Value = model.AccreditCompany;
			parameters[7].Value = model.AccreditTime;
			parameters[8].Value = model.AccreditType;
			parameters[9].Value = model.Awards;
			parameters[10].Value = model.OpusMascot;
			parameters[11].Value = model.AddTime;
			parameters[12].Value = model.IsDelete;
			parameters[13].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Bank_OriginalGroup ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Bank_OriginalGroup ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KSOA.Model.Bank_OriginalGroup GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OpusCopyright,CreationInfo,OpusName,OpusAuthor,SalePrice,AccreditPlatform,AccreditCompany,AccreditTime,AccreditType,Awards,OpusMascot,AddTime,IsDelete from Bank_OriginalGroup ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			KSOA.Model.Bank_OriginalGroup model=new KSOA.Model.Bank_OriginalGroup();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KSOA.Model.Bank_OriginalGroup DataRowToModel(DataRow row)
		{
			KSOA.Model.Bank_OriginalGroup model=new KSOA.Model.Bank_OriginalGroup();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["OpusCopyright"]!=null)
				{
					model.OpusCopyright=row["OpusCopyright"].ToString();
				}
				if(row["CreationInfo"]!=null)
				{
					model.CreationInfo=row["CreationInfo"].ToString();
				}
				if(row["OpusName"]!=null)
				{
					model.OpusName=row["OpusName"].ToString();
				}
				if(row["OpusAuthor"]!=null)
				{
					model.OpusAuthor=row["OpusAuthor"].ToString();
				}
				if(row["SalePrice"]!=null && row["SalePrice"].ToString()!="")
				{
					model.SalePrice=decimal.Parse(row["SalePrice"].ToString());
				}
				if(row["AccreditPlatform"]!=null)
				{
					model.AccreditPlatform=row["AccreditPlatform"].ToString();
				}
				if(row["AccreditCompany"]!=null)
				{
					model.AccreditCompany=row["AccreditCompany"].ToString();
				}
				if(row["AccreditTime"]!=null && row["AccreditTime"].ToString()!="")
				{
					model.AccreditTime=DateTime.Parse(row["AccreditTime"].ToString());
				}
				if(row["AccreditType"]!=null)
				{
					model.AccreditType=row["AccreditType"].ToString();
				}
				if(row["Awards"]!=null)
				{
					model.Awards=row["Awards"].ToString();
				}
				if(row["OpusMascot"]!=null)
				{
					model.OpusMascot=row["OpusMascot"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["IsDelete"]!=null && row["IsDelete"].ToString()!="")
				{
					if((row["IsDelete"].ToString()=="1")||(row["IsDelete"].ToString().ToLower()=="true"))
					{
						model.IsDelete=true;
					}
					else
					{
						model.IsDelete=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,OpusCopyright,CreationInfo,OpusName,OpusAuthor,SalePrice,AccreditPlatform,AccreditCompany,AccreditTime,AccreditType,Awards,OpusMascot,AddTime,IsDelete ");
			strSql.Append(" FROM Bank_OriginalGroup ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,OpusCopyright,CreationInfo,OpusName,OpusAuthor,SalePrice,AccreditPlatform,AccreditCompany,AccreditTime,AccreditType,Awards,OpusMascot,AddTime,IsDelete ");
			strSql.Append(" FROM Bank_OriginalGroup ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Bank_OriginalGroup ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Bank_OriginalGroup T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Bank_OriginalGroup";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

