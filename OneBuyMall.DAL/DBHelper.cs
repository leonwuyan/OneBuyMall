using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall.DAL
{
    public enum Sort
    {
        NONE,
        DESC,
        ASC
    }
    public class MySqlException : Exception
    {
    }
    public static class DBHelper
    {
        #region DataTable To List
        public static List<T> ToList<T>(this DataTable dt) where T : class,new()
        {
            //创建一个属性的列表
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口
            Type t = typeof(T);
            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表 
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            //创建返回的集合
            List<T> oblist = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                //创建TResult的实例
                T ob = new T();
                //找到对应的数据  并赋值
                prlist.ForEach(p =>
                {
                    if (row[p.Name] != DBNull.Value)
                    {
                        if (p.PropertyType.Name == "Boolean")
                        {
                            var value = Convert.ToBoolean(row[p.Name]);
                            p.SetValue(ob, value, null);
                        }
                        else
                        {
                            var value = row[p.Name];
                            p.SetValue(ob, value, null);
                        }
                    }
                });
                //放入到返回的集合中.
                oblist.Add(ob);
            }
            return oblist;
        }
        #endregion
        public static string _connStr = null;
        static MySqlConnection NewConnection()
        {
            if (_connStr != null)
            {
                var conn = new MySqlConnection(_connStr);
                try
                {
                    conn.Open();
                    return conn;
                }
                catch(MySqlException e)
                {
                    LogHelper.LogError(typeof(MySqlException), e);
                }
            }
            return null;
        }
        public static DataTable ExecuteDataTable(MySqlCommand cmd)
        {
            using (var conn = NewConnection())
            {
                MySqlDataAdapter rs = new MySqlDataAdapter();
                rs.SelectCommand = cmd;
                rs.SelectCommand.Connection = conn;
                DataTable dt = new DataTable();
                try
                {
                    rs.Fill(dt);
                }
                catch (Exception e)
                {
                    LogHelper.LogError(typeof(DBHelper), e);
                }
                finally
                {
                    rs.Dispose();
                }
                return dt;
            }
        }
        public static int ExecuteNonQuery(MySqlCommand cmd)
        {
            using (var conn = NewConnection())
            {
                if (conn != null)
                {
                    cmd.Connection = conn;
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    {
                        LogHelper.LogError(typeof(MySqlException), e);
                    }
                }
            }
            return -1;
        }
    }
}
