using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KSOA.DAL
{
	/// <summary>
	/// 数据访问类:Work_Notice
	/// </summary>
	public partial class Work_Notice
	{
		public Work_Notice()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Work_Notice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Work_Notice");
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
		public int Add(KSOA.Model.Work_Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Work_Notice(");
			strSql.Append("NTitle,NContent,NCustomerID,NCustomerName,Nlevel,AddTime,IsDelete,NIP)");
			strSql.Append(" values (");
			strSql.Append("@NTitle,@NContent,@NCustomerID,@NCustomerName,@Nlevel,@AddTime,@IsDelete,@NIP)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@NContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@NCustomerID", SqlDbType.Int,4),
					new SqlParameter("@NCustomerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Nlevel", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@NIP", SqlDbType.VarChar,50)};
			parameters[0].Value = model.NTitle;
			parameters[1].Value = model.NContent;
			parameters[2].Value = model.NCustomerID;
			parameters[3].Value = model.NCustomerName;
			parameters[4].Value = model.Nlevel;
			parameters[5].Value = model.AddTime;
			parameters[6].Value = model.IsDelete;
			parameters[7].Value = model.NIP;

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
		public bool Update(KSOA.Model.Work_Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Work_Notice set ");
			strSql.Append("NTitle=@NTitle,");
			strSql.Append("NContent=@NContent,");
			strSql.Append("NCustomerID=@NCustomerID,");
			strSql.Append("NCustomerName=@NCustomerName,");
			strSql.Append("Nlevel=@Nlevel,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("NIP=@NIP");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@NTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@NContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@NCustomerID", SqlDbType.Int,4),
					new SqlParameter("@NCustomerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Nlevel", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@NIP", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.NTitle;
			parameters[1].Value = model.NContent;
			parameters[2].Value = model.NCustomerID;
			parameters[3].Value = model.NCustomerName;
			parameters[4].Value = model.Nlevel;
			parameters[5].Value = model.AddTime;
			parameters[6].Value = model.IsDelete;
			parameters[7].Value = model.NIP;
			parameters[8].Value = model.ID;

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
			strSql.Append("delete from Work_Notice ");
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
			strSql.Append("delete from Work_Notice ");
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
		public KSOA.Model.Work_Notice GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NTitle,NContent,NCustomerID,NCustomerName,Nlevel,AddTime,IsDelete,NIP from Work_Notice ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			KSOA.Model.Work_Notice model=new KSOA.Model.Work_Notice();
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
		public KSOA.Model.Work_Notice DataRowToModel(DataRow row)
		{
			KSOA.Model.Work_Notice model=new KSOA.Model.Work_Notice();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["NTitle"]!=null)
				{
					model.NTitle=row["NTitle"].ToString();
				}
				if(row["NContent"]!=null)
				{
					model.NContent=row["NContent"].ToString();
				}
				if(row["NCustomerID"]!=null && row["NCustomerID"].ToString()!="")
				{
					model.NCustomerID=int.Parse(row["NCustomerID"].ToString());
				}
				if(row["NCustomerName"]!=null)
				{
					model.NCustomerName=row["NCustomerName"].ToString();
				}
				if(row["Nlevel"]!=null && row["Nlevel"].ToString()!="")
				{
					model.Nlevel=int.Parse(row["Nlevel"].ToString());
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
				if(row["NIP"]!=null)
				{
					model.NIP=row["NIP"].ToString();
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
			strSql.Append("select ID,NTitle,NContent,NCustomerID,NCustomerName,Nlevel,AddTime,IsDelete,NIP ");
			strSql.Append(" FROM Work_Notice ");
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
			strSql.Append(" ID,NTitle,NContent,NCustomerID,NCustomerName,Nlevel,AddTime,IsDelete,NIP ");
			strSql.Append(" FROM Work_Notice ");
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
			strSql.Append("select count(1) FROM Work_Notice ");
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
			strSql.Append(")AS Row, T.*  from Work_Notice T ");
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
			parameters[0].Value = "Work_Notice";
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

