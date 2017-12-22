using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace ChatService
{
     public static  class SocketPool
    {
        /// <summary>
        /// 创建一个对象池
        /// </summary>
        private static List<Socket> socketpool=new List<Socket>();
        public static List<Socket> Socketpool
        {
            get
            {
                return socketpool;   
            }
        }

        public static List<string> nubpool = new List<string>();

        /// <summary>
        /// 当前连接对象池
        /// </summary>
        public static List<Socket> portpool=new List<Socket>();

        /// <summary>
        /// 初始化对象池
        /// </summary>


        /// <summary>
        /// 添加一个对象到对象池
        /// </summary>
        /// <param 连接对象="sock"></param>
        /// <param 连接的号="Nub"></param>
        public static void AddNub(Socket sock,string Nub)
        {
            Socketpool.Add(sock);
            nubpool.Add(Nub);
            
        }

        /// <summary>
        /// 删除一个对象从对象池
        /// </summary>
        /// <param 连接的对象="sock"></param>
        /// <param 连接的号="Nub"></param>
        public static void RemoveNub(Socket sock,string Nub)
        {
            Socketpool.Remove(sock);
            nubpool.Remove(Nub);
        }
       
        /// <summary>
        /// 获取当前所有连接的号码
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSocketPool()
        {
            return nubpool;
        }


        public static void Add(Socket sock)
        {
            portpool.Add(sock);
        }


        public static void Remove(Socket sock)
        {
            portpool.Remove(sock);
        }





    }
}
