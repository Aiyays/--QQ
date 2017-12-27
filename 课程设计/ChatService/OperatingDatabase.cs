using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace ChatService
{
    public  class OperatingDatabase
    {
        #region 初始化数据库

        /// <summary>
        /// 引用登录
        /// </summary>
        private static MySqlConnection mysql = getMySqlCon();

        /// <summary>
        /// 建立执行命令语句对象
        /// </summary>
        /// <returns>sql.txt=配置mysql的相应文档</returns>
        public static MySqlConnection getMySqlCon()
        {
            String mysqlStr = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "sql.txt");

            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }

        /// <summary>
        /// 获得连接对象 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mysql"></param>
        /// <returns></returns>
        public static MySqlCommand getSqlCommand(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            return mySqlCommand;
        }

        /// <summary>
        /// 打开mysql
        /// </summary>
        public static void OpenMysql()
        {
            mysql.Open();
        }

        /// <summary>
        ///关闭mysql 
        /// </summary>
        public static void CloseMysql()
        {
            mysql.Close();
        }

        /// <summary>
        /// 数据库操作的基方法
        /// </summary>
        /// <param name="sql"></param>
        private static void Common(string sql)
        {
            MySqlCommand mySqlCommand = getSqlCommand(sql, mysql);
           
            try
            {
                mySqlCommand.ExecuteReader();
                Debug.Print("已经成功执行了该语句:" + sql);
            }
            catch
            {
                Debug.Print("执行异常,请检查数据库，或者检查执行的语句");
            }
        }

        /// <summary>
        /// 有返回值的操作的基础方法 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static List<string[]> CommonS(string sql)
        {
            OperatingDatabase.OpenMysql();
            MySqlCommand mySqlCommand = getSqlCommand(sql, mysql);
            try
            {

                List<string[]> a = GetData(mySqlCommand);
                Debug.Print("已经成功执行了该语句:" + sql);
                return a;
            }
            catch
            {
                Debug.Print("执行异常,请检查数据库，或者检查执行的语句");
                return null;
            }
        }
        #endregion

        #region 表的插入操作

        /// <summary>
        /// 对于插入的泛型方法
        /// </summary>
        /// <param >insert into worker set name='tom'</param>
        /// <param worker---查找的某张表="table"></param>
        /// <param name='tom'---数据类型+数据="Date">这个需要自己写  以后会完善该方法</param>
        /// 使用该方法请先打开数据库  mysql.open---方便以后插入多条数据时  只需要打开一次数据库
        public static void Insert(string table, string Date)
        {
            Common("insert into " + table + " set " + Date);
        }
        #endregion

        #region 数据库的删除操作
        /// <summary>
        /// 删除数据库中的库 表 和表中数据
        /// </summary>
        /// <param 删除类型="type"> database-删库 table-删表 date-删表中数据</param>
        /// <param 删除的库或者表的名字="name"></param>
        /// <param 当删除表中的某条数据时的判断语句 若没有就不写="adopt"></param>
        public static void Delete(string type, string name, string adopt)
        {
            switch (type)
            {
                case "database":
                    Common("DROP DATABASE " + name);
                    break;
                case "table":
                    Common("DROP TABLE " + name);
                    break;
                case "date":
                    Common("DELETE FROM " + name + " WHERE " + adopt);
                    break;
            }
        }


        #endregion

        #region 表的修改

        #endregion

        #region  表的查询
        /// <summary>
        /// 表的查询操作 
        /// </summary>
        /// <param 返回哪些数据="returnData"></param>
        /// <param 查询的表名="tableName"></param>
        /// <param 筛选的条件="screen"></param>
        /// <param Limit LimitiList,LimitHost;="LimitiList"></param>
        /// <param name="LimitHost"></param>
        /// 如果 screen 和LimitiList和LimitHost不存在  则返回 null
        public static List<string[]> Select(string returnData, string tableName, string screen, string LimitiList, string LimitHost)
        {
            if (screen == null)
            {
                if (LimitiList == null)
                {
                    return CommonS("select " + returnData + "  from " + tableName);
                }
                else
                {
                    switch (LimitiList)
                    {
                        case null:
                            return CommonS("select " + returnData + "  from " + tableName + " limit " + LimitiList);

                        default:
                            return CommonS("select " + returnData + "  from " + tableName + " limit " + LimitiList + "," + LimitHost);


                    }
                }
            }
            else
            {
                if (LimitiList == null)
                {
                    Debug.Print("筛选");
                    return CommonS("select " + returnData + "  from " + tableName + " where " + screen);
                }
                else
                {
                    switch (LimitiList)
                    {
                        case null:
                            return CommonS("select " + returnData + "  from " + tableName + " where " + screen + " limit " + LimitiList);

                        default:
                            return CommonS("select " + returnData + "  from " + tableName + " where " + screen + " limit " + LimitiList + "," + LimitHost);


                    }
                }
            }
        }

        /// <summary>
        /// 查询到的数据的处理
        /// </summary>
        /// <param 传入操作的mysql代理="mySqlCommand"></param>
        /// <returns></returns>
        public static List<string[]> GetData(MySqlCommand mySqlCommand)
        {

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            List<string[]> ad = new List<string[]>();
            try
            {

                while (reader.Read())
                {
                    int c = reader.FieldCount;
                    Debug.Print(c.ToString());
                    string[] tst = new string[c];
                    for (int i = 0; i < c; i++)
                    {
                        tst[i] = reader.GetString(i);

                        Debug.Print("查询到"+reader.GetString(i));
                    }
                    ad.Add(tst);
                }
                Debug.Print("查询成功");
                mysql.Dispose();
                return ad;
            }
            catch
            {
                Debug.Print("执行查询操作出错");
                return null;
            }
            
        }
        #endregion
    }
}