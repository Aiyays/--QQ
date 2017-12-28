using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChatService
{
    public class SocketServer
    {
        private static byte[] result = new byte[1024];
        private static int myProt = 10000;   //端口
        static Socket serverSocket;


        /// <summary>
        /// 开启一个Socket服务
        /// </summary>
        public static void start()
        {
            
            IPAddress ip = IPAddress.Parse("192.168.0.100");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myProt));  
            serverSocket.Listen(10);    
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();
            Console.ReadLine();
        }


        /// <summary>
        /// 监听客户端连接
        /// </summary>
        private static void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                //clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
                Debug.Print(clientSocket.RemoteEndPoint.ToString()+"已连接");
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param 连接对象="clientSocket"></param>
        private static void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                  // new Task(() => 
                   // {

                        int receiveNumber = myClientSocket.Receive(result);
                        Debug.WriteLine("接收客户端{0}消息{1}", myClientSocket.RemoteEndPoint.ToString(), UTF8Encoding.UTF8.GetString(result, 0, receiveNumber));
                        PushFuction.AdoptCenter(myClientSocket, UTF8Encoding.UTF8.GetString(result, 0, receiveNumber));
                  //  }).Start();
                   
                }
                catch 
                {
                  
                    Debug.Print("客户端{0}已经断开", myClientSocket.RemoteEndPoint.ToString());
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// < 发送消息的对象="sock"></param>
        /// <发送的消息 name="str"></param>
        public static void Send(Socket sock, string str)
        {
            string accept = str;
            byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(accept);
            try
            {
                sock.BeginSend(data, 0, data.Length, SocketFlags.None, AsynCallBack, sock);
            }
            catch
            { }

        }

        /// <summary>
        /// 异步发送
        /// </summary>
        /// <param name="result"></param>
        static void AsynCallBack(IAsyncResult result)
        {
            try
            {
                Socket sock = result.AsyncState as Socket;

                if (sock != null)
                {
                    sock.EndSend(result);
                }
            }
            catch{}
        }


    }

}
