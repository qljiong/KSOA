using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KSOA.DAL
{
	/// <summary>
	/// 数据访问类:Admin_KSCustomer
	/// </summary>
	public partial class Admin_KSCustomer
	{
		public Admin_KSCustomer()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Admin_KSCustomer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CusEmail,string CusPhoneNum,int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Admin_KSCustomer");
			strSql.Append(" where CusEmail=@CusEmail and CusPhoneNum=@CusPhoneNum and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CusEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@CusPhoneNum", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = CusEmail;
			parameters[1].Value = CusPhoneNum;
			parameters[2].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KSOA.Model.Admin_KSCustomer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Admin_KSCustomer(");
			strSql.Append("RoleID,RealName,CusName,Gender,Age,CusPwd,CusEmail,CusPhoneNum,QQ,IsDelete,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@RealName,@CusName,@Gender,@Age,@CusPwd,@CusEmail,@CusPhoneNum,@QQ,@IsDelete,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@CusName", SqlDbType.NVarChar,50),
					new SqlParameter("@Gender", SqlDbType.Char,1),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@CusPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@CusEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@CusPhoneNum", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.RealName;
			parameters[2].Value = model.CusName;
			parameters[3].Value = model.Gender;
			parameters[4].Value = model.Age;
			parameters[5].Value = model.CusPwd;
			parameters[6].Value = model.CusEmail;
			parameters[7].Value = model.CusPhoneNum;
			parameters[8].Value = model.QQ;
			parameters[9].Value = model.IsDelete;
			parameters[10].Value = model.AddTime;

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
		public bool Update(KSOA.Model.Admin_KSCustomer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Admin_KSCustomer set ");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("RealName=@RealName,");
			strSql.Append("CusName=@CusName,");
			strSql.Append("Gender=@Gender,");
			strSql.Append("Age=@Age,");
			strSql.Append("CusPwd=@CusPwd,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@CusName", SqlDbType.NVarChar,50),
					new SqlParameter("@Gender", SqlDbType.Char,1),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@CusPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CusEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@CusPhoneNum", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.RealName;
			parameters[2].Value = model.CusName;
			parameters[3].Value = model.Gender;
			parameters[4].Value = model.Age;
			parameters[5].Value = model.CusPwd;
			parameters[6].Value = model.QQ;
			parameters[7].Value = model.IsDelete;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.ID;
			parameters[10].Value = model.CusEmail;
			parameters[11].Value = model.CusPhoneNum;

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
			strSql.Append("delete from Admin_KSCustomer ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CusEmail,string CusPhoneNum,int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin_KSCustomer ");
			strSql.Append(" where CusEmail=@CusEmail and CusPhoneNum=@CusPhoneNum and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CusEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@CusPhoneNum", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = CusEmail;
			parameters[1].Value = CusPhoneNum;
			parameters[2].Value = ID;

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
			strSql.Append("delete from Admin_KSCustomer ");
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
		public KSOA.Model.Admin_KSCustomer GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,RoleID,RealName,CusName,Gender,Age,CusPwd,CusEmail,CusPhoneNum,QQ,IsDelete,AddTime from Admin_KSCustomer ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			KSOA.Model.Admin_KSCustomer model=new KSOA.Model.Admin_KSCustomer();
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
		public KSOA.Model.Admin_KSCustomer DataRowToModel(DataRow row)
		{
			KSOA.Model.Admin_KSCustomer model=new KSOA.Model.Admin_KSCustomer();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["RoleID"]!=null)
				{
					model.RoleID=row["RoleID"].ToString();
				}
				if(row["RealName"]!=null)
				{
					model.RealName=row["RealName"].ToString();
				}
				if(row["CusName"]!=null)
				{
					model.CusName=row["CusName"].ToString();
				}
				if(row["Gender"]!=null)
				{
					model.Gender=row["Gender"].ToString();
				}
				if(row["Age"]!=null && row["Age"].ToString()!="")
				{
					model.Age=int.Parse(row["Age"].ToString());
				}
				if(row["CusPwd"]!=null)
				{
					model.CusPwd=row["CusPwd"].ToString();
				}
				if(row["CusEmail"]!=null)
				{
					model.CusEmail=row["CusEmail"].ToString();
				}
				if(row["CusPhoneNum"]!=null)
				{
					model.CusPhoneNum=row["CusPhoneNum"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
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
			strSql.Append("select ID,RoleID,RealName,CusName,Gender,Age,CusPwd,CusEmail,CusPhoneNum,QQ,IsDelete,AddTime ");
			strSql.Append(" FROM Admin_KSCustomer ");
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
			strSql.Append(" ID,RoleID,RealName,CusName,Gender,Age,CusPwd,CusEmail,CusPhoneNum,QQ,IsDelete,AddTime ");
			strSql.Append(" FROM Admin_KSCustomer ");
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
			strSql.Append("select count(1) FROM Admin_KSCustomer ");
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
			strSql.Append(")AS Row, T.*  from Admin_KSCustomer T ");
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
			parameters[0].Value = "Admin_KSCustomer";
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

