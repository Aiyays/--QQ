using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _CUSTOM_CONTROLS;
using System.Diagnostics;
using System.Net.Sockets;

namespace Client
{
   
    public partial class MainForm : Form
    {
        List<Socket> socketpool = new List<Socket>();
        /// <summary>
        /// 创建一个对象池
        /// </summary>
        public  static List<ChatForm> chatList = new List<ChatForm>();
        public static List<string > nubList = new List<string >();
        
        private string[] a;

        public MainForm()
        {
            ProcessingCenter.ChageAdopt = new Adopt(EverGourp);
            InitializeComponent();
            ProcessingCenter.Kongzhi = false;
            ProcessingCenter.ChageAdoptF = new Adoptf(FriendLis);
            ProcessingCenter.ChageAdoptM=new Adopt(Recevice);
            
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            LayeredSkin.NativeMethods.MouseToMoveControl(this.Handle);
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 这是一个调用的点击事件
        /// </summary>
        /// <param 发发送的人="sender"></param>
        /// <param name="e"></param>
        private void FriendList_DoubleClickSubItem(object sender, _CUSTOM_CONTROLS._ChatListBox.ChatListEventArgs e)
        {
            ///e.SelectSubItem.DisplayName---->为好友昵称
            ///e.SelectSubItem.NicName ---->为好友账号
            /// MessageBox.Show(e.SelectSubItem.DisplayName+e.SelectSubItem.NicName);
            ChatForm a = new ChatForm(e.SelectSubItem.DisplayName, e.SelectSubItem.NicName, MyNub.Text, MyName.Text);
            a.Show();
            e.SelectSubItem.IsTwinkle = false;
            string[] ne= ProcessingCenter.ClikRm(e.SelectSubItem.NicName);
            if(ne!=null)
            {
                a.Send(ne);
            }
            chatList.Add(a);
            nubList.Add(e.SelectSubItem.NicName);
            //点击事件
        }

        /// <summary>
        /// 绘制好友列表
        /// </summary>
        /// <param 所有信息="json"></param>
        /// <param 传入一个CheckedListBox="a"></param>
        /// <returns></returns>
        public void EverGourp(string json)
        {
            
            Debug.Print("接受到消息"+json);
            ChatListBox c = new ChatListBox();
            List<string[]> information = (List<string[]>)ProcessingCenter.JsonToObject(json, new List<string[]>());
            a = information[1];
            Debug.Print("1");
            for (int i = 0; i < information[0].Length; i++)
            {
                List<string[]> TemporaryStorage = new List<string[]>();
                foreach (var j in information)
                {
                    if (j != information[0] && j [0]== information[0][i]&&j!=information[1])
                    {
                        TemporaryStorage.Add(j);
                    }
                }
                FriendList.Items.Add(ProcessingCenter.DropGourp(information[0][i], TemporaryStorage));
            }
            Debug.Print("绘制好友列表"+json);
           
            //this.Invoke();
            FriendLis(FriendList);
            

        }

        /// <summary>
        /// 初始化自己的信息
        /// </summary>
        /// <param 自己的信息数组="myinformation"></param>
        private void MyInformatin(string[] myinformation)
        {
            MyNub.Text = myinformation[0];
            MyName.Text = myinformation[1];
            MyAutograph.Text = myinformation[2];
        }

        /// <summary>
        /// 初始化面板信息
        /// </summary>
        /// <param 好友列表信息="chatListBo"></param>
        /// <param 自己的信息="myinformation"></param>
        public void FriendLis(ChatListBox chatListBo)
        {
            FriendList = chatListBo;
            ProcessingCenter.agent = FriendList;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MyInformatin(a);
        }


        /// <summary>
        /// 设置动态闪烁
        /// </summary>
        /// <param 接受到的消息="json"></param>
        /// <param 界面="chatListBox1"></param>
        public  void Recevice( string json)
        {
            Debug.Print("接受到一个信息"+json);
            string[] rece = ProcessingCenter.GetType(json);
            for (int i = 0; i < FriendList.Items.Count; i++)
            {
                for (int j = 0; j < FriendList.Items[i].SubItems.Count; j++)
                {
                    Debug.Print(FriendList.Items[i].SubItems[j].NicName.ToString()+"这是接到的账号"+ rece[1]);
                    if (FriendList.Items[i].SubItems[j].NicName.ToString() == rece[1])
                    {
                        Debug.Print("准备闪烁");
                        FriendList.Items[i].SubItems[j].IsTwinkle = !FriendList.Items[i].SubItems[j].IsTwinkle;
                        ProcessingCenter.Write(json);
                    }
                }
            }
        }

        /// <summary>
        /// 根据号码查找登录的socket
        /// </summary>
        /// <param 号码="nub"></param>
        /// <returns></returns>
        public static ChatForm GetSocket(string nub)
        {
            int i = nubList.IndexOf(nub);
            return chatList[i];
        }
    }
}
