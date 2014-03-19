using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KSOA.DAL
{
	/// <summary>
	/// 数据访问类:Admin_SysMenu
	/// </summary>
	public partial class Admin_SysMenu
	{
		public Admin_SysMenu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Admin_SysMenu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Admin_SysMenu");
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
		public int Add(KSOA.Model.Admin_SysMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Admin_SysMenu(");
			strSql.Append("ParentID,MenuName,MenuUrl,OrderIndex,AdminRoleID,IsEnable,IsDelete,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@ParentID,@MenuName,@MenuUrl,@OrderIndex,@AdminRoleID,@IsEnable,@IsDelete,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4),
					new SqlParameter("@AdminRoleID", SqlDbType.Int,4),
					new SqlParameter("@IsEnable", SqlDbType.Bit,1),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.MenuName;
			parameters[2].Value = model.MenuUrl;
			parameters[3].Value = model.OrderIndex;
			parameters[4].Value = model.AdminRoleID;
			parameters[5].Value = model.IsEnable;
			parameters[6].Value = model.IsDelete;
			parameters[7].Value = model.AddTime;

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
		public bool Update(KSOA.Model.Admin_SysMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Admin_SysMenu set ");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("MenuName=@MenuName,");
			strSql.Append("MenuUrl=@MenuUrl,");
			strSql.Append("OrderIndex=@OrderIndex,");
			strSql.Append("AdminRoleID=@AdminRoleID,");
			strSql.Append("IsEnable=@IsEnable,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4),
					new SqlParameter("@AdminRoleID", SqlDbType.Int,4),
					new SqlParameter("@IsEnable", SqlDbType.Bit,1),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.MenuName;
			parameters[2].Value = model.MenuUrl;
			parameters[3].Value = model.OrderIndex;
			parameters[4].Value = model.AdminRoleID;
			parameters[5].Value = model.IsEnable;
			parameters[6].Value = model.IsDelete;
			parameters[7].Value = model.AddTime;
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
			strSql.Append("delete from Admin_SysMenu ");
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
			strSql.Append("delete from Admin_SysMenu ");
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
		public KSOA.Model.Admin_SysMenu GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ParentID,MenuName,MenuUrl,OrderIndex,AdminRoleID,IsEnable,IsDelete,AddTime from Admin_SysMenu ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			KSOA.Model.Admin_SysMenu model=new KSOA.Model.Admin_SysMenu();
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
		public KSOA.Model.Admin_SysMenu DataRowToModel(DataRow row)
		{
			KSOA.Model.Admin_SysMenu model=new KSOA.Model.Admin_SysMenu();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(row["ParentID"].ToString());
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["MenuUrl"]!=null)
				{
					model.MenuUrl=row["MenuUrl"].ToString();
				}
				if(row["OrderIndex"]!=null && row["OrderIndex"].ToString()!="")
				{
					model.OrderIndex=int.Parse(row["OrderIndex"].ToString());
				}
				if(row["AdminRoleID"]!=null && row["AdminRoleID"].ToString()!="")
				{
					model.AdminRoleID=int.Parse(row["AdminRoleID"].ToString());
				}
				if(row["IsEnable"]!=null && row["IsEnable"].ToString()!="")
				{
					if((row["IsEnable"].ToString()=="1")||(row["IsEnable"].ToString().ToLower()=="true"))
					{
						model.IsEnable=true;
					}
					else
					{
						model.IsEnable=false;
					}
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
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
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
			strSql.Append("select ID,ParentID,MenuName,MenuUrl,OrderIndex,AdminRoleID,IsEnable,IsDelete,AddTime ");
			strSql.Append(" FROM Admin_SysMenu ");
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
			strSql.Append(" ID,ParentID,MenuName,MenuUrl,OrderIndex,AdminRoleID,IsEnable,IsDelete,AddTime ");
			strSql.Append(" FROM Admin_SysMenu ");
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
			strSql.Append("select count(1) FROM Admin_SysMenu ");
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
			strSql.Append(")AS Row, T.*  from Admin_SysMenu T ");
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
			parameters[0].Value = "Admin_SysMenu";
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

