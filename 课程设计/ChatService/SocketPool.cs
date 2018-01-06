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

        /// <summary>
        /// 一个私有化的线程池
        /// </summary>
        public static List<Socket> Socketpool
        {
            get
            {
                return socketpool;   
            }
        }
        
        /// <summary>
        /// 创建的连接号码池
        /// </summary>
        private static List<string> nubpool = new List<string>();

        /// <summary>
        /// 创建的
        /// </summary>
        public static List<string> Nubpool { get { return nubpool; } }  


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
        public static void RemoveNub(Socket sock)
        {
            int  i =Socketpool.IndexOf(sock);
            Socketpool.Remove(sock);
            nubpool.RemoveAt(i);
        }
       
        /// <summary>
        /// 获取当前所有连接的号码
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSocketNubPool()
        {
            return nubpool;
        }

        /// <summary>
        /// 根据号码查找登录的socket
        /// </summary>
        /// <param 号码="nub"></param>
        /// <returns></returns>
        public static Socket GetSocket(string nub)
        {
            int i = Nubpool.IndexOf(nub);
            return Socketpool[i];
        }





    }
}
