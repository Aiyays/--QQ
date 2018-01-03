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
        public   static Adpot HandleL;
        public   static Adpot HandleM;
        


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
            return UTF8Encoding.UTF8.GetString(dataBytes);
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
            MemoryStream mStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(jsonString));
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
        /// 服务器接受到消息的处理中心
        /// </summary>
        /// <param 接收到的消息="json"></param>
        public static void AdoptCenter(Socket s,string json)
        {
            switch (GetType(json)[0])
            {
                case "L":
                    Debug.Print("接受到登录请求处理信息");
                    AdoptLand(s,json);
                    break;
                case "R":
                    Debug.Print("接受到注册请求处理信息");
                    if (Adopt(json))
                    {
                        
                        SocketServer.Send(s,GetJson("R","False",null,null,null));
                    }
                    else
                    {
                        string[] a = GetType(json);
                        OperatingDatabase.InsertInformation(a[1], a[2], a[3], DateTime.Now.ToString(), a[4]);
                        SocketServer.Send(s, GetJson("R", "True", null, null, null));
                        ///当注册的消息准确的时候
                    }
                    break;
                case "M":
                    Debug.Print("接受到消息时触发该指令"+json );

                    AdoptPush(json);
                    break;
                default:
                    Debug.Print("接收到非法错误指令时，不予处理");
                    break;
                
            }
        }

        #region 注册
        public static bool Adopt(string json)
        {
            List<string[]> a = OperatingDatabase.Select("id","information",null,null ,null);
            foreach (var i in a)
            {
                Debug.Print(GetType(json)[1]);
                if (i[0] == GetType(json)[1])
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region 登录

        /// <summary>
        /// 判断是否登录 并且向客户端发送消息
        /// </summary>
        /// <param 对象="soc"></param>
        /// <param 接受到的json="a"></param>
        public static void AdoptLand(Socket soc, string json)
        {
            bool a=false;
            Debug.Print(OperatingDatabase.Select("*", "information", null, null, null).ToString());
          
            foreach (var i in OperatingDatabase.Select("*", "information", null, null, null))
            {
                Debug.Print("进入查询循环");
                if(i[0] == GetType(json)[1] && i[2] == GetType(json)[2])
                {
                    a = true;
                    break;
                }
                else
                {
                    a = false;
                }
            }
            SocketServer.Send(soc, GetJson("L", a.ToString(), ObjectToJson(AdpotFriend(GetType(json)[1])), null, null));
            SocketPool.AddNub(soc, GetType(json)[1]);
        }
        
        /// <summary>
        ///好友和自己的信息 
        /// </summary>
        /// <param 自己ID="userId"></param>
        /// <returns></returns>
        public static List<string[]>  AdpotFriend(string userId )
        {
            
            List<string[]> list= OperatingDatabase.Select("friendid,item","friend","userid='"+userId+"'",null,null);
            string[] item = new string[list.Count];
            for (int i = 0; i < list.Count; i++) { item[i] = list[i][1]; }
            item = DelRepeatData(item);
            Debug.Print(userId);
            string[] myInfmt = Information(userId);
            List<string[]> rte = new List<string[]>();
            rte.Add(item);
            rte.Add(myInfmt);
            foreach (var d in list)
            {
                rte.Add(Friendster(d[0], d[1]));
            }
            return rte;
             
        }

        /// <summary>
        /// 好友信息
        /// </summary>
        /// <param 好友id="friendId"></param>
        /// <param 好友分组="item"></param>
        /// <returns>分组，好友id ，好友昵称，好友签名</returns>
        public static string[] Friendster(string friendId,string item)
        {
           return new string[] { item,friendId,Information(friendId)[1], Information(friendId)[2] };       
        }

        /// <summary>
        /// 剔除数组中相同的数的Linq方法
        /// </summary>
        /// <param 传入的数组="a"></param>
        /// <returns>剔除相同的数的方法</returns>
        public static string[] DelRepeatData(string[] a)
        {
            return a.GroupBy(p => p).Select(p => p.Key).ToArray();
        }

        /// <summary>
        /// 查询自己的信息
        /// </summary>
        /// <param 查询人的id="id"></param>
        /// <returns>返回id，昵称和签名</returns>
        public static string[] Information(string id)
        {
            try
            {
                return OperatingDatabase.Select("id,name,autograph", "information", "id='" + id + "'", null, null)[0];

            }
            catch
            {
                Debug.Print("查找出现异常");
                return null;
            }
        }
        #endregion

        #region 推送消息
        
        /// <summary>
        /// 当接到一条消息 
        /// </summary>
        /// <param 接收到发送给好友的消息="json"></param>
        public static void AdoptPush(string json)
        {
            string[] msg = new string[3];
            msg[0] = GetType(json)[0];
            msg[1] = GetType(json)[1];
            msg[2] = GetType(json)[3];
            Debug.Print("发送给客户端"+ GetType(json)[2]+ ":"+ ObjectToJson(msg)+msg[2]);
            SocketServer.Send(SectNub(GetType(json)[2]),ObjectToJson(msg));
            Debug.Print("发送消息"+ ObjectToJson(msg));
        }

        /// <summary>
        /// 获取该号码的Socket
        /// </summary>
        /// <param name="nub"></param>
        /// <returns></returns>
        public static Socket SectNub(string nub)
        {
            return  SocketPool.GetSocket(nub);
        }
        #endregion


        #region 修改资料

        #endregion






    }
}
