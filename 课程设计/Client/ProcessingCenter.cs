using _CUSTOM_CONTROLS._ChatListBox;
using _CUSTOM_CONTROLS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Client
{
    public delegate void Adopt(string m);
    public delegate void Adoptf(ChatListBox chatListBox, string[] myinformation);
    public static class ProcessingCenter
    {

        /// <summary>
        /// 控制是否显示主窗体
        /// </summary>
        private static bool mainF = false;
        public static bool MainF { get { return mainF; } set { mainF = value; } }
        public static bool kongzhi=true ;
        public static bool Kongzhi { get { return kongzhi; }set { kongzhi = value; } }
        /// <summary>
        /// 控制 登录 和 消息的委托
        /// </summary>
        private static Adopt adoptL;
        private static Adopt adoptM;
        private static Adoptf adoptF;
        private static Adopt Adopt;

        /// <summary>
        /// 对外控制委托代理的索引
        /// </summary>
        public static Adopt ChageAdoptL { get { return adoptL; } set { adoptL = value; } }
        public static Adopt ChageAdoptM { get { return adoptM; } set { adoptM = value; } }
        public static Adoptf ChageAdoptF { get { return adoptF; } set { adoptF = value; } }
        public static Adopt ChageAdopt { get { return Adopt; } set { Adopt = value; } }

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
        /// <param Adopt="Adopt"></param>
        /// <param Adopt="Remenb"></param>
        /// <returns></returns>
        public static string GetJson(string T, string Nub, string M, string Adopt, string Remenb)
        {
            return ProcessingCenter.ObjectToJson(new string[] { T, Nub, M, Adopt, Remenb });
        }

        /// <summary>
        /// 通信方式接受消息的格式转换
        /// </summary>
        /// <param 接受到的json="json"></param>
        /// <returns></returns>
        public static string[] GetType(string json)
        {
            return (string[])ProcessingCenter.JsonToObject(json, new string[] { });
        }
        #endregion

        /// <summary>
        /// 当接受到消息时，消息处理中心
        /// </summary>
        /// <param 接受到的消息="json"></param>
        public static void JodgeType(string json)
        {
            Debug.Print("接受到的总消息"+json);
            switch (GetType(json)[0])
            {
                case "L":
                    adoptL(json);
                    if (GetType(json)[1] == "true")
                    {
                        if (GetType(json)[2] != null)   
                        {
                            Debug.Print(GetType(json)[2]);
                            while (kongzhi) ;

                            
                            Adopt(GetType(json)[2]);
                        }
                    }
                    break;

                case "M":
                    adoptM(json);
                    break;
            }
        }

        /// <summary>
        /// 发送注册消息
        /// </summary>
        /// <param 注册的账号="id"></param>
        /// <param 注册的昵称="name"></param>
        /// <param 注册的密码="passworld"></param>
        public static void SendRegister(string id, string name, string passworld)
        {
            Connect.SendMessage(GetJson("R", id, name, passworld, DateTime.Now.ToString()));
        }

        /// <summary>
        /// 发送消息给好友
        /// </summary>
        /// <param 自己的账号="sendid"></param>
        /// <param 朋友的账号="Friendid"></param>
        /// <param 发送的信息="message"></param>
        public static void SendMessage(string sendid, string Friendid, string message)
        {
            Connect.SendMessage(GetJson("M", sendid, Friendid, message, null));
        }

        /// <summary>
        /// 发送登录信息
        /// </summary>
        /// <param 登录的账号="id"></param>
        /// <param 登录的密码="passworld"></param>
        /// <param 是否记住密码="Remb"></param>
        /// <param 记住密码相应的主机号="conputerNub"></param>
        public static void SendLand(string id, string passworld, string Remb, string conputerNub)
        {
            Connect.SendMessage(GetJson("L", id, passworld, Remb, conputerNub));
        }

        /// <summary>
        /// 绘制一个组所有成员
        /// </summary>
        /// <param 组名="gourpName"></param>
        /// <param 该组的每个成员="information"></param>
        /// <returns>information 包含的是{组名,成员账号,成员昵称,成员签名}的集合</returns>
        public static ChatListItem DropGourp(string gourpName,List<string[]> information)
        {
            Random rnd = new Random();
            ChatListItem item = new ChatListItem(gourpName);
            foreach (var i in information)
            {
                ChatListSubItem subItem = new ChatListSubItem(i[1], i[2], i[3]);
                subItem.HeadImage = Image.FromFile("head/1 (" + rnd.Next(0, 45) + ").png");
                subItem.Status = (ChatListSubItem.UserStatus)(1);
                item.SubItems.AddAccordingToStatus(subItem);
            }

         //   item.SubItems.Sort();
            return item;
        }

     
            



    }
}