using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;

using System.Configuration;//为了使用配置文件

namespace TeacherUser
{
    class MysqlHelper
    {
        /// <summary>
        /// string server, string database, string login, string pass, int port
        /// </summary>
        //   public static string connectionString = new ConnectionString("localhost", "bird", "root", "sdbird", 8888).AsString;
        //public static string connectionString = "Database='" + "tb3" + "';Data Source='" + "localhost" + "';User Id='" + "root" + "';Password='" + "123456" + "'";

        //  public static string connectionString = "Database='" + "userlogin" + "';Data Source='" + "172.26.162.60" + "';User Id='" + "root" + "';Password='" + "yyc105" + "'";//默认端口3306
        //    public static string connectionString = ConfigurationSettings.AppSettings["connectionstring"];//提示说ConfigurationSettings已经过时，建议用下面的

       // <add key="connectionstring" value="Database=userlogin;Data Source=172.26.163.174;User Id=root;Password=yyc105" />
        public static string connectionString = "Database='" + ConfigurationManager.AppSettings["Database"] + "';Data Source='" + ConfigurationManager.AppSettings["serverIP"]+ "';User Id='" + ConfigurationManager.AppSettings["User ID"]+ "';Password='" + ConfigurationManager.AppSettings["Password"]+ "'";//默认端口3306 
        public MysqlHelper()
        {

        }


        #region ExecuteNonQuery
        //执行SQL语句，返回影响的记录数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteNonQuery(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (MySqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteNonQuery(string SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        // PrepareCommand(cmd, connection, SQLString, cmdParms);
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (MySqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object ExecuteScalar(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
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
                    catch (MySqlException e)
                    {
                        connection.Close();
                        /*
                        ConfServerIP f = new ConfServerIP();
                        f.Show();
                         * */
                        return -1;
                        //throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object ExecuteScalar(string SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        //PrepareCommand(cmd, connection, SQLString, cmdParms);
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
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
                    catch (MySqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 执行查询语句，返回MySqlDataReader (注意：调用该方法后，一定要对MySqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>MySqlDataReader</returns>
        public static MySqlDataReader ExecuteReader(string strSQL)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(strSQL, connection);
            MySqlDataReader myReader = null;
            try
            {
                connection.Open();
                myReader = cmd.ExecuteReader();//返回数据集合。本来是ExecuteReaderEx()，貌似速度更快，但是不支持
                return myReader;
            }
            catch (MySqlException e)
            {
                throw e;
            }
            finally
            {
                //myReader.Close();//原本程序中是存在的，但是其他程序在调用本方法后，获得的MySqlDataReader类型的对象是不能进行Read()的
                //于是将该代码屏蔽，在调用处的最后进行关闭
            }
        }
        /// <summary>
        /// 执行查询语句，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>MySqlDataReader</returns>
        public static MySqlDataReader ExecuteReader(string SQLString, params MySqlParameter[] cmdParms)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myReader = null;
            try
            {
                // PrepareCommand(cmd, connection,SQLString, cmdParms);
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (MySqlException e)
            {
                throw e;
            }
            finally
            {
                myReader.Close();
                cmd.Dispose();
                connection.Close();

            }
        }
        #endregion

        #region ExecuteDataTable
        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string SQLString)
        {
            //using代码块的好处：在其中创建的对象能被自动释放，从而能够自动关闭数据库连接
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
                //PrepareCommand(cmd, connection, SQLString, cmdParms);
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds.Tables[0];
                }
            }
        }
        //获取起始页码和结束页码
        public static DataTable ExecuteDataTable(string cmdText, int startResord, int maxRecord)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(cmdText, connection);
                    command.Fill(ds, startResord, maxRecord, "ds");
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
        #endregion

        #region PageList Without Proc
        /// <summary>
        /// 获取分页数据 在不用存储过程情况下
        /// </summary>
        /// <param name="recordCount">总记录条数</param>
        /// <param name="selectList">选择的列逗号隔开,支持top num</param>
        /// <param name="tableName">表名字</param>
        /// <param name="whereStr">条件字符 必须前加 and</param>
        /// <param name="orderExpression">排序 例如 ID</param>
        /// <param name="pageIdex">当前索引页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public static DataTable getPager(out int recordCount, string selectList, string tableName, string whereStr, string orderExpression, int pageIdex, int pageSize)
        {
            int rows = 0;
            DataTable dt = new DataTable();
            MatchCollection matchs = Regex.Matches(selectList, @"top\s+\d{1,}", RegexOptions.IgnoreCase);//含有top
            string sqlStr = sqlStr = string.Format("select {0} from {1} where 1=1 {2}", selectList, tableName, whereStr);
            if (!string.IsNullOrEmpty(orderExpression)) { sqlStr += string.Format(" Order by {0}", orderExpression); }
            if (matchs.Count > 0) //含有top的时候
            {
                DataTable dtTemp = ExecuteDataTable(sqlStr);
                rows = dtTemp.Rows.Count;
            }
            else //不含有top的时候
            {
                string sqlCount = string.Format("select count(*) from {0} where 1=1 {1} ", tableName, whereStr);
                //获取行数
                object obj = ExecuteScalar(sqlCount);
                if (obj != null)
                {
                    rows = Convert.ToInt32(obj);
                }
            }
            dt = ExecuteDataTable(sqlStr, (pageIdex - 1) * pageSize, pageSize);
            recordCount = rows;
            return dt;
        }
        #endregion

        #region 创建command
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion
    }
}
