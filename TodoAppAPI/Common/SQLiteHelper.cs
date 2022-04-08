using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace TodoAppAPI.Common
{
    public class SQLiteHelper
    {
        //需要添加引用--框架，System.Configuration，添加再using，用来读取配置文件的数据库链接字符串
        private static string conStr = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
        // private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
        /// <summary>
        /// 封装增加、删、改方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="pms">SQL参数，因为不知道会有多少个参数，所以用可变参数params</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] pms)
        {
            using (SQLiteConnection conn = new SQLiteConnection(conStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        throw;
                    }


                    return cmd.ExecuteNonQuery();
                }
            }




        }

        /// <summary>
        /// 查询单个结果，一般和聚合函数 一起使用
        /// </summary>
        /// <param name="sql">查询的SQL语句</param>
        /// <param name="pms">SQL参数</param>
        /// <returns>返回查询对象，查询结果第一行第一列</returns>
        public static object ExecuteScalar(string sql, params SQLiteParameter[] pms)
        {

            using (SQLiteConnection conn = new SQLiteConnection(conStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        throw;
                    }


                    return cmd.ExecuteScalar();
                }
            }

        }

        /// <summary>
        /// 查询多行
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="pms">SQL参数</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SQLiteDataReader ExcuteReader(string sql, params SQLiteParameter[] pms)
        {

            //这里不能用using，不然在返回SqlDataReader时候会报错，因为返回时候已经在using中关闭了。
            //事实上，在使用数据库相关类中，SqlConnection是必须关闭的，但是其他可以选择关闭，因为CG回自动回收
            SQLiteConnection conn = new SQLiteConnection(conStr);
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    conn.Open();
                    //传入System.Data.CommandBehavior.CloseConnection枚举是为了让在外面使用完毕SqlDataReader后，只要关闭了SqlDataReader就会关闭对应的SqlConnection
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    conn.Close();
                    conn.Dispose();
                    throw;
                }
            }
        }
        /// <summary>
        /// 准备操作命令参数
        /// </summary>
        /// <param name="cmd">SQLiteCommand</param>
        /// <param name="conn">SQLiteConnection</param>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, Dictionary<String, String> data)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (data != null && data.Count >= 1)
            {
                foreach (KeyValuePair<String, String> val in data)
                {
                    cmd.Parameters.AddWithValue(val.Key, val.Value);
                }
            }
        }

        /// <summary>
        /// 查询，返回DataSet
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataset(string cmdText, Dictionary<string, string> data)
        {
            var ds = new DataSet();
            using (SQLiteConnection connection = new SQLiteConnection(conStr))
            {
                var command = new SQLiteCommand();
                PrepareCommand(command, connection, cmdText, data);
                var da = new SQLiteDataAdapter(command);
                da.Fill(ds);
            }
            return ds;
        }
    }
}