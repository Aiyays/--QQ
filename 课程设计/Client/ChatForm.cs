using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatForm : Form
    {
        #region 好友昵称  好友ID  用户ID
        string friendName;
        string friendId;
        string userId;
        string userName;        
        #endregion
        
        public ChatForm(string friendName,string friendId,string userId,string userName)
        {
            InitializeComponent();
            InitializeCode(friendName,friendId,userId,userName);
        }

        /// <summary>
        /// 初始化各个数据
        /// </summary>
        /// <param 好友昵称="friendName"></param>
        /// <param 好友ID="friendId"></param>
        /// <param 使用ID="userId"></param>
        private void InitializeCode(string friendName, string friendId, string userId,string userName)
        {
            this.friendId = friendId;
            this.friendName = friendName;
            this.userId = userId;
            this.userName = userName;
            this.Text = friendName;
        }

        /// <summary>
        /// 发送
        /// </summary>
        private void SendMessage()
        {
            if (txtSend.Text!="")
            {
                ProcessingCenter.SendMessage(userId, friendId, txtSend.Text);
                txtShow.AppendText(DateTime.Now+"  "+userName+":"+txtSend.Text+"\n");
            }
        }

        /// <summary>
        /// 接受到消息
        /// </summary>
        /// <param 收到的消息="json"></param>
        private void Recieve(string json)
        {
            txtShow.AppendText(DateTime.Now+"  "+friendName+":"+ ProcessingCenter.GetType(json)[2]);
        }

       
        private void btnSend_Click(object sender, EventArgs e){  SendMessage(); }

    }
}
