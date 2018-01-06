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
    public partial class DeleteFriend : Form
    {
        private string nub;
        public DeleteFriend(string nub)
        {
            InitializeComponent();
            this.nub = nub;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtNub.Text != "")
            {
                if (ProcessingCenter.IsBExistence(txtNub.Text))
                {
                    ProcessingCenter.SendDeleteFriend(nub, txtNub.Text);
                    this.Close();
                    MessageBox.Show("正在处理");
                }
                else
                {
                    this.Close();
                    MessageBox.Show("该账户还不是您的好友喔");
                }
               
            }
            else
            {
                MessageBox.Show("请输入您要删除的好友账号");
            }
        }
    }
}
