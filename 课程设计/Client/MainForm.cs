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

namespace Client
{
   
    public partial class MainForm : Form
    {
        

        public MainForm()
        {
            ProcessingCenter.ChageAdopt = new Adopt(EverGourp);
            
            InitializeComponent();
            ProcessingCenter.Kongzhi = false;
            ProcessingCenter.ChageAdoptF = new Adoptf(FriendLis);
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
            LayeredSkin.NativeMethods.MouseToMoveControl(this.Handle);
        }

        /// <summary>
        /// 这是一个调用的点击事件
        /// </summary>
        /// <param 发发送的人="sender"></param>
        /// <param name="e"></param>
        private void FriendList_DoubleClickSubItem(object sender, _CUSTOM_CONTROLS._ChatListBox.ChatListEventArgs e)
        {
            MessageBox.Show("asfsdf");
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
            Debug.Print(json);
            //this.Invoke();
           // FriendLis(FriendList, information[1]);
            
        }

        /// <summary>
        /// 初始化面板信息
        /// </summary>
        /// <param 好友列表信息="chatListBo"></param>
        /// <param 自己的信息="myinformation"></param>
        public void FriendLis(ChatListBox chatListBo,string[] myinformation)
        {
            FriendList = chatListBo;
        }
    }
}
