using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KSOA.DAL
{
	/// <summary>
	/// 数据访问类:UI_ExcelImportByChannel
	/// </summary>
	public partial class UI_ExcelImportByChannel
	{
		public UI_ExcelImportByChannel()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KSOA.Model.UI_ExcelImportByChannel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UI_ExcelImportByChannel(");
			strSql.Append("CustomerID,ExSpreadType,ExTime,ExOpusName,ExCollectNum,ExChargeCollectNum,ExOpusUnitPrice,ExAccountPrice,ExAccountCollectNum,HistoryPercent,AddTime,IsDelete)");
			strSql.Append(" values (");
			strSql.Append("@CustomerID,@ExSpreadType,@ExTime,@ExOpusName,@ExCollectNum,@ExChargeCollectNum,@ExOpusUnitPrice,@ExAccountPrice,@ExAccountCollectNum,@HistoryPercent,@AddTime,@IsDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@ExSpreadType", SqlDbType.Char,1),
					new SqlParameter("@ExTime", SqlDbType.DateTime),
					new SqlParameter("@ExOpusName", SqlDbType.NVarChar,200),
					new SqlParameter("@ExCollectNum", SqlDbType.Int,4),
					new SqlParameter("@ExChargeCollectNum", SqlDbType.Int,4),
					new SqlParameter("@ExOpusUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ExAccountPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ExAccountCollectNum", SqlDbType.Int,4),
					new SqlParameter("@HistoryPercent", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1)};
			parameters[0].Value = model.CustomerID;
			parameters[1].Value = model.ExSpreadType;
			parameters[2].Value = model.ExTime;
			parameters[3].Value = model.ExOpusName;
			parameters[4].Value = model.ExCollectNum;
			parameters[5].Value = model.ExChargeCollectNum;
			parameters[6].Value = model.ExOpusUnitPrice;
			parameters[7].Value = model.ExAccountPrice;
			parameters[8].Value = model.ExAccountCollectNum;
			parameters[9].Value = model.HistoryPercent;
			parameters[10].Value = model.AddTime;
			parameters[11].Value = model.IsDelete;

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
		public bool Update(KSOA.Model.UI_ExcelImportByChannel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UI_ExcelImportByChannel set ");
			strSql.Append("CustomerID=@CustomerID,");
			strSql.Append("ExSpreadType=@ExSpreadType,");
			strSql.Append("ExTime=@ExTime,");
			strSql.Append("ExOpusName=@ExOpusName,");
			strSql.Append("ExCollectNum=@ExCollectNum,");
			strSql.Append("ExChargeCollectNum=@ExChargeCollectNum,");
			strSql.Append("ExOpusUnitPrice=@ExOpusUnitPrice,");
			strSql.Append("ExAccountPrice=@ExAccountPrice,");
			strSql.Append("ExAccountCollectNum=@ExAccountCollectNum,");
			strSql.Append("HistoryPercent=@HistoryPercent,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("IsDelete=@IsDelete");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@ExSpreadType", SqlDbType.Char,1),
					new SqlParameter("@ExTime", SqlDbType.DateTime),
					new SqlParameter("@ExOpusName", SqlDbType.NVarChar,200),
					new SqlParameter("@ExCollectNum", SqlDbType.Int,4),
					new SqlParameter("@ExChargeCollectNum", SqlDbType.Int,4),
					new SqlParameter("@ExOpusUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ExAccountPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ExAccountCollectNum", SqlDbType.Int,4),
					new SqlParameter("@HistoryPercent", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.CustomerID;
			parameters[1].Value = model.ExSpreadType;
			parameters[2].Value = model.ExTime;
			parameters[3].Value = model.ExOpusName;
			parameters[4].Value = model.ExCollectNum;
			parameters[5].Value = model.ExChargeCollectNum;
			parameters[6].Value = model.ExOpusUnitPrice;
			parameters[7].Value = model.ExAccountPrice;
			parameters[8].Value = model.ExAccountCollectNum;
			parameters[9].Value = model.HistoryPercent;
			parameters[10].Value = model.AddTime;
			parameters[11].Value = model.IsDelete;
			parameters[12].Value = model.ID;

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
			strSql.Append("delete from UI_ExcelImportByChannel ");
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
			strSql.Append("delete from UI_ExcelImportByChannel ");
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
		public KSOA.Model.UI_ExcelImportByChannel GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CustomerID,ExSpreadType,ExTime,ExOpusName,ExCollectNum,ExChargeCollectNum,ExOpusUnitPrice,ExAccountPrice,ExAccountCollectNum,HistoryPercent,AddTime,IsDelete from UI_ExcelImportByChannel ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			KSOA.Model.UI_ExcelImportByChannel model=new KSOA.Model.UI_ExcelImportByChannel();
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
		public KSOA.Model.UI_ExcelImportByChannel DataRowToModel(DataRow row)
		{
			KSOA.Model.UI_ExcelImportByChannel model=new KSOA.Model.UI_ExcelImportByChannel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["CustomerID"]!=null && row["CustomerID"].ToString()!="")
				{
					model.CustomerID=int.Parse(row["CustomerID"].ToString());
				}
				if(row["ExSpreadType"]!=null)
				{
					model.ExSpreadType=row["ExSpreadType"].ToString();
				}
				if(row["ExTime"]!=null && row["ExTime"].ToString()!="")
				{
					model.ExTime=DateTime.Parse(row["ExTime"].ToString());
				}
				if(row["ExOpusName"]!=null)
				{
					model.ExOpusName=row["ExOpusName"].ToString();
				}
				if(row["ExCollectNum"]!=null && row["ExCollectNum"].ToString()!="")
				{
					model.ExCollectNum=int.Parse(row["ExCollectNum"].ToString());
				}
				if(row["ExChargeCollectNum"]!=null && row["ExChargeCollectNum"].ToString()!="")
				{
					model.ExChargeCollectNum=int.Parse(row["ExChargeCollectNum"].ToString());
				}
				if(row["ExOpusUnitPrice"]!=null && row["ExOpusUnitPrice"].ToString()!="")
				{
					model.ExOpusUnitPrice=decimal.Parse(row["ExOpusUnitPrice"].ToString());
				}
				if(row["ExAccountPrice"]!=null && row["ExAccountPrice"].ToString()!="")
				{
					model.ExAccountPrice=decimal.Parse(row["ExAccountPrice"].ToString());
				}
				if(row["ExAccountCollectNum"]!=null && row["ExAccountCollectNum"].ToString()!="")
				{
					model.ExAccountCollectNum=int.Parse(row["ExAccountCollectNum"].ToString());
				}
				if(row["HistoryPercent"]!=null)
				{
					model.HistoryPercent=row["HistoryPercent"].ToString();
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
			strSql.Append("select ID,CustomerID,ExSpreadType,ExTime,ExOpusName,ExCollectNum,ExChargeCollectNum,ExOpusUnitPrice,ExAccountPrice,ExAccountCollectNum,HistoryPercent,AddTime,IsDelete ");
			strSql.Append(" FROM UI_ExcelImportByChannel ");
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
			strSql.Append(" ID,CustomerID,ExSpreadType,ExTime,ExOpusName,ExCollectNum,ExChargeCollectNum,ExOpusUnitPrice,ExAccountPrice,ExAccountCollectNum,HistoryPercent,AddTime,IsDelete ");
			strSql.Append(" FROM UI_ExcelImportByChannel ");
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
			strSql.Append("select count(1) FROM UI_ExcelImportByChannel ");
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
			strSql.Append(")AS Row, T.*  from UI_ExcelImportByChannel T ");
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
			parameters[0].Value = "UI_ExcelImportByChannel";
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

