using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace KSOA.DataAccess
{
    public class SQLHelper
    {
        #region 通用方法
        /// <summary>
        /// 数据连接池
        /// </summary>
        private SqlConnection con;

        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static String GetSqlConnection()
        {
            String conn = Connection.SqlConnectionString;
            //String conn="Data Source=192.168.0.103;Initial Catalog=Master;User ID=sa";
            return conn;
        }

        #endregion

        #region 执行sql字符串
        /// <summary>
        /// 执行不带参数的SQL语句 
        /// </summary>
        /// <param name="Sqlstr"></param>
        /// <returns></returns>
        public static int ExecuteSql(String Sqlstr)
        {
            String ConnStr = GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }

        /// <summary>
        /// 执行带参数的SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象数组</param>
        /// <returns></returns>
        public static int ExecuteSql(String Sqlstr, SqlParameter[] param)
        {
            String ConnStr = GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                cmd.Parameters.AddRange(param);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                return result;
            }
        }

        /// <summary>
        ///  执行带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            int res;
            using (SqlConnection connection = new SqlConnection(GetSqlConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandType = ct;
                        cmd.Parameters.AddRange(paras);
                        cmd.CommandTimeout = 200;
                        res = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    catch (Exception e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
                return res;
            }
        }

        /// <summary>
        /// 执行一条计算查询语句，
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(GetSqlConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询语句
        /// 带参数
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, SqlParameter[] paras)
        {
            using (SqlConnection connection = new SqlConnection(GetSqlConnection()))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddRange(paras);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }


        /// <summary>
        ///  执行查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">查询SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string cmdText, CommandType ct)
        {
            Open();
            String ConnStr = GetSqlConnection();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = ct;
            using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                //while (sdr.Read())
                //{
                //    string SingleOpusName = sdr["SingleOpusName"].ToString();
                //    string AnalyTime = sdr["SingleOpusName"].ToString();
                //    int SumNum = Convert.ToInt32(sdr["SingleOpusName"]);

                //}
                dt.Load(sdr);
            }
            Close();
            return dt;
        }



        /// <summary>
        /// 返回DataReader
        /// </summary>
        /// <param name="Sqlstr"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(String Sqlstr)
        {
            String ConnStr = GetSqlConnection();
            SqlConnection conn = new SqlConnection(ConnStr);//返回DataReader时,是不可以用using()的 
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                conn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);//关闭关联的Connection 
            }
            catch //(Exception ex) 
            {
                return null;
            }
        }

        /// <summary>
        /// 返回DataReader,带参数
        /// </summary>
        /// <param name="Sqlstr"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(String Sqlstr, SqlParameter[] paramList)
        {
            String ConnStr = GetSqlConnection();
            SqlConnection conn = new SqlConnection(ConnStr);//返回DataReader时,是不可以用using()的 
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                cmd.Parameters.AddRange(paramList);
                conn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);//关闭关联的Connection 
            }
            catch //(Exception ex) 
            {
                return null;
            }
        }


        /// <summary>
        /// 执行SQL语句并返回数据表   
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteDt(String Sqlstr)
        {
            String ConnStr = GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>
        ///  执行带参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">查询SQL语句或存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            String ConnStr = GetSqlConnection();
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = ct;
            cmd.Parameters.AddRange(paras);
            using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
                //lxw20131016
                cmd.Parameters.Clear();
            }
            return dt;
        }

        /// <summary>
        /// 执行SQL语句并返回DataSet 
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static DataSet ExecuteDs(String Sqlstr)
        {
            String ConnStr = GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }
        #endregion

        #region 操作存储过程

        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            String ConnStr = GetSqlConnection();
            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            } return command;
        }


        ///  
        /// 运行存储过程(已重载) 
        ///  
        /// 存储过程的名字 
        /// 存储过程的返回值 
        public int RunProc(string procName)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        ///  
        /// 运行存储过程(已重载) 
        ///  
        /// 存储过程的名字 
        /// 存储过程的输入参数列表 
        /// 存储过程的返回值 
        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters[0].Value;
        }
        public string RunProc_(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (string)cmd.Parameters["@outputvalue"].Value;
        }
        ///  
        /// 运行存储过程(已重载) 
        ///  
        /// 存储过程的名字 
        /// 结果集 
        public void RunProc(string procName, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        ///  
        /// 运行存储过程(已重载) 
        ///  
        /// 存储过程的名字 
        /// 存储过程的输入参数列表 
        /// 结果集 
        public void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        ///  
        /// 创建Command对象用于访问存储过程 
        ///  
        /// 存储过程的名字 
        /// 存储过程的输入参数列表 
        /// Command对象 
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            // 确定连接是打开的 
            Open();
            //command = new SqlCommand( sprocName, new SqlConnection( ConfigManager.DALConnectionString ) ); 
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            // 添加存储过程的输入参数列表 
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }
            // 返回Command对象 
            return cmd;
        }
        ///  
        /// 创建输入参数 
        ///  
        /// 参数名 
        /// 参数类型 
        /// 参数大小 
        /// 参数值 
        /// 新参数对象 
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        ///  
        /// 创建输出参数 
        ///  
        /// 参数名 
        /// 参数类型 
        /// 参数大小 
        /// 新参数对象 
        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }
        ///  
        /// 创建存储过程参数 
        ///  
        /// 参数名 
        /// 参数类型 
        /// 参数大小 
        /// 参数的方向(输入/输出) 
        /// 参数值 
        /// 新参数对象 
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;
            if (Size > 0)
            {
                param = new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                param = new SqlParameter(ParamName, DbType);
            }
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
            {
                param.Value = Value;
            }
            return param;
        }
        #endregion

        #region 数据库连接和关闭
        ///  
        /// 打开连接池 
        ///  
        private void Open()
        {
            // 打开连接池 
            if (con == null)
            {
                //这里不仅需要using System.Configuration;还要在引用目录里添加 
                con = new SqlConnection(GetSqlConnection());
                con.Open();
            }
        }
        ///  
        /// 关闭连接池 
        ///  
        public void Close()
        {
            if (con != null)
                con.Close();
        }
        ///  
        /// 释放连接池 
        ///  
        public void Dispose()
        {
            // 确定连接已关闭 
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
        #endregion
    }
}
