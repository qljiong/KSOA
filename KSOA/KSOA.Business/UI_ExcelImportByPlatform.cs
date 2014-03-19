using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KSOA.DAL
{
	/// <summary>
	/// 数据访问类:UI_ExcelImportByPlatform
	/// </summary>
	public partial class UI_ExcelImportByPlatform
	{
		public UI_ExcelImportByPlatform()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KSOA.Model.UI_ExcelImportByPlatform model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UI_ExcelImportByPlatform(");
			strSql.Append("CustomerID,ExType,ExTime,ExCpName,ExOpusName,ExCooperation,ExCollectNum,ExSingleCollectNum,ExOpusUnitPrice,ExAccountPrice,AddTime,IsDelete)");
			strSql.Append(" values (");
			strSql.Append("@CustomerID,@ExType,@ExTime,@ExCpName,@ExOpusName,@ExCooperation,@ExCollectNum,@ExSingleCollectNum,@ExOpusUnitPrice,@ExAccountPrice,@AddTime,@IsDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@ExType", SqlDbType.Char,1),
					new SqlParameter("@ExTime", SqlDbType.DateTime),
					new SqlParameter("@ExCpName", SqlDbType.NVarChar,50),
					new SqlParameter("@ExOpusName", SqlDbType.NVarChar,200),
					new SqlParameter("@ExCooperation", SqlDbType.NVarChar,100),
					new SqlParameter("@ExCollectNum", SqlDbType.Int,4),
					new SqlParameter("@ExSingleCollectNum", SqlDbType.Int,4),
					new SqlParameter("@ExOpusUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ExAccountPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1)};
			parameters[0].Value = model.CustomerID;
			parameters[1].Value = model.ExType;
			parameters[2].Value = model.ExTime;
			parameters[3].Value = model.ExCpName;
			parameters[4].Value = model.ExOpusName;
			parameters[5].Value = model.ExCooperation;
			parameters[6].Value = model.ExCollectNum;
			parameters[7].Value = model.ExSingleCollectNum;
			parameters[8].Value = model.ExOpusUnitPrice;
			parameters[9].Value = model.ExAccountPrice;
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
		public bool Update(KSOA.Model.UI_ExcelImportByPlatform model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UI_ExcelImportByPlatform set ");
			strSql.Append("CustomerID=@CustomerID,");
			strSql.Append("ExType=@ExType,");
			strSql.Append("ExTime=@ExTime,");
			strSql.Append("ExCpName=@ExCpName,");
			strSql.Append("ExOpusName=@ExOpusName,");
			strSql.Append("ExCooperation=@ExCooperation,");
			strSql.Append("ExCollectNum=@ExCollectNum,");
			strSql.Append("ExSingleCollectNum=@ExSingleCollectNum,");
			strSql.Append("ExOpusUnitPrice=@ExOpusUnitPrice,");
			strSql.Append("ExAccountPrice=@ExAccountPrice,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("IsDelete=@IsDelete");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@ExType", SqlDbType.Char,1),
					new SqlParameter("@ExTime", SqlDbType.DateTime),
					new SqlParameter("@ExCpName", SqlDbType.NVarChar,50),
					new SqlParameter("@ExOpusName", SqlDbType.NVarChar,200),
					new SqlParameter("@ExCooperation", SqlDbType.NVarChar,100),
					new SqlParameter("@ExCollectNum", SqlDbType.Int,4),
					new SqlParameter("@ExSingleCollectNum", SqlDbType.Int,4),
					new SqlParameter("@ExOpusUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ExAccountPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.CustomerID;
			parameters[1].Value = model.ExType;
			parameters[2].Value = model.ExTime;
			parameters[3].Value = model.ExCpName;
			parameters[4].Value = model.ExOpusName;
			parameters[5].Value = model.ExCooperation;
			parameters[6].Value = model.ExCollectNum;
			parameters[7].Value = model.ExSingleCollectNum;
			parameters[8].Value = model.ExOpusUnitPrice;
			parameters[9].Value = model.ExAccountPrice;
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
			strSql.Append("delete from UI_ExcelImportByPlatform ");
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
			strSql.Append("delete from UI_ExcelImportByPlatform ");
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
		public KSOA.Model.UI_ExcelImportByPlatform GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CustomerID,ExType,ExTime,ExCpName,ExOpusName,ExCooperation,ExCollectNum,ExSingleCollectNum,ExOpusUnitPrice,ExAccountPrice,AddTime,IsDelete from UI_ExcelImportByPlatform ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			KSOA.Model.UI_ExcelImportByPlatform model=new KSOA.Model.UI_ExcelImportByPlatform();
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
		public KSOA.Model.UI_ExcelImportByPlatform DataRowToModel(DataRow row)
		{
			KSOA.Model.UI_ExcelImportByPlatform model=new KSOA.Model.UI_ExcelImportByPlatform();
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
				if(row["ExType"]!=null)
				{
					model.ExType=row["ExType"].ToString();
				}
				if(row["ExTime"]!=null && row["ExTime"].ToString()!="")
				{
					model.ExTime=DateTime.Parse(row["ExTime"].ToString());
				}
				if(row["ExCpName"]!=null)
				{
					model.ExCpName=row["ExCpName"].ToString();
				}
				if(row["ExOpusName"]!=null)
				{
					model.ExOpusName=row["ExOpusName"].ToString();
				}
				if(row["ExCooperation"]!=null)
				{
					model.ExCooperation=row["ExCooperation"].ToString();
				}
				if(row["ExCollectNum"]!=null && row["ExCollectNum"].ToString()!="")
				{
					model.ExCollectNum=int.Parse(row["ExCollectNum"].ToString());
				}
				if(row["ExSingleCollectNum"]!=null && row["ExSingleCollectNum"].ToString()!="")
				{
					model.ExSingleCollectNum=int.Parse(row["ExSingleCollectNum"].ToString());
				}
				if(row["ExOpusUnitPrice"]!=null && row["ExOpusUnitPrice"].ToString()!="")
				{
					model.ExOpusUnitPrice=decimal.Parse(row["ExOpusUnitPrice"].ToString());
				}
				if(row["ExAccountPrice"]!=null && row["ExAccountPrice"].ToString()!="")
				{
					model.ExAccountPrice=decimal.Parse(row["ExAccountPrice"].ToString());
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
			strSql.Append("select ID,CustomerID,ExType,ExTime,ExCpName,ExOpusName,ExCooperation,ExCollectNum,ExSingleCollectNum,ExOpusUnitPrice,ExAccountPrice,AddTime,IsDelete ");
			strSql.Append(" FROM UI_ExcelImportByPlatform ");
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
			strSql.Append(" ID,CustomerID,ExType,ExTime,ExCpName,ExOpusName,ExCooperation,ExCollectNum,ExSingleCollectNum,ExOpusUnitPrice,ExAccountPrice,AddTime,IsDelete ");
			strSql.Append(" FROM UI_ExcelImportByPlatform ");
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
			strSql.Append("select count(1) FROM UI_ExcelImportByPlatform ");
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
			strSql.Append(")AS Row, T.*  from UI_ExcelImportByPlatform T ");
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
			parameters[0].Value = "UI_ExcelImportByPlatform";
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

