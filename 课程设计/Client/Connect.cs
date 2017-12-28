using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace Client
{
    public static class Connect
    {
        private static byte[] result = new byte[1024];
        /// <summary>
        /// 初始化客户端连接对象
        /// </summary>
        private static Socket clientSocket= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      
        /// <summary>
        /// 开启客户端连接
        /// </summary>
        public static void Start()
        {
            IPAddress ip = IPAddress.Parse("192.168.0.100");
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 10000)); //配置服务器IP与端口
                Debug.Print("连接服务器成功");
                 new Task(() =>{
                    Recevice();
                }).Start();
                

            }
            catch
            {
                Debug.Print("连接服务器失败，请按回车键退出！");
                return;
            }

        }
        
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="socket"></param>
        public static void Recevice()
        {
            while (true)
            {

                string a = UTF8Encoding.UTF8.GetString(result, 0, clientSocket.Receive(result));
                ProcessingCenter.JodgeType(a);
                Debug.Print("客户端接收到消息"+a);
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        public  static void SendMessage(string message)
        {
            try
            {
                clientSocket.Send(UTF8Encoding.UTF8.GetBytes(message));
                Debug.Print("发送消息成功");
            }
            catch
            {
                Debug.Print("发送消息失败 ");
            }
        }
    }
}
