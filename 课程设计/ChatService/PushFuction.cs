using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.Net.Sockets;

namespace ChatService
{
    public delegate void Adpot(string json);
    public static class PushFuction
    {
        #region 委托
        public static Adpot HandleL;
        public static Adpot HandleM;

        #endregion

        #region 传送信息统一格式
        /// <summary>
        /// 将一个对象生成josn字符串
        /// </summary>
        /// <param 任意对象类型="obj"></param>
        /// <returns>返回一个json字符串</returns>
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }

        /// <summary>
        /// 将一个josn串解析成对象
        /// </summary>
        /// <param json串="jsonString"></param>
        /// <param 对象类型="obj"></param>
        /// <returns></returns>
        public static object JsonToObject(string jsonString, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            return serializer.ReadObject(mStream);
        }

        /// <summary>
        /// 通信方式发送消息
        /// </summary>
        /// <param 类型="T"></param>
        /// <param 账号="Nub"></param>
        /// <param 消息="M"></param>
        /// <returns></returns>
        public static string GetJson(string T,string Nub,string M,string Adopt,string Remenb)
        {
            return PushFuction.ObjectToJson(new string[] { T,Nub,M,Adopt,Remenb});
        }

        /// <summary>
        /// 通信方式接受消息的格式转换
        /// </summary>
        /// <param 接受到的json="json"></param>
        /// <returns></returns>
        public static string[] GetType(string json)
        {
             return (string[])PushFuction.JsonToObject(json,new string[] { });
        }
        #endregion

        /// <summary>
        /// 接受到的消息
        /// </summary>
        /// <param 接受到的json="a"></param>
        public static void AdoptType(string a)
        {
            try
            {
                switch (GetType(a)[0])
                {
                    case "L":
                        
                        break;
                    case "M":

                        break;
                    case "R":

                        break;

                }
            }
            catch
            {
                Debug.Print("接受到的数据"+a+"格式异常");
            }
        }

        /// <summary>
        /// 判断是否登录 并且向客户端发送消息
        /// </summary>
        /// <param 对象="soc"></param>
        /// <param 接受到的json="a"></param>
        public static void AdoptLand(Socket soc,string a)
        {
            OperatingDatabase.OpenMysql();
            List<string[]> choice = OperatingDatabase.Select("*","","","","");
            
            if (choice[0][1] == GetType(a)[1] && choice[0][2] == GetType(a)[2])
            {
                Debug.Print("判断登录");
                SocketPool.AddNub(soc, GetType(a)[1]);
                SocketServer.Send(soc, GetJson("L", "true", null,null,null));
            }
            else
            {
                Debug.Print("登录失败");
                SocketServer.Send(soc, GetJson("L", "false", null, null, null));
            }
           
         }


        #region 注册

        #endregion

        #region 登录

        #endregion

        #region 推送消息

        #endregion

        #region 监听下线

        #endregion

        #region 上线下线

        #endregion






    }
}
