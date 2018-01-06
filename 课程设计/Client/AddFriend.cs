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

    public partial class AddFriend : Form
    {
        public static ThisClose AFClose;//关闭该窗口的委托
         
        private string nub;//自己的账号

        public AddFriend(string nub)
        {
            InitializeComponent();
            this.nub = nub;
            AFClose = new ThisClose(delet_Clsoe);
        }

        private void btnAddF_Click(object sender, EventArgs e)
        {
            if (txtNub.Text!=""&&txtItem.Text!="")
            {
                if (!ProcessingCenter.IsBExistence(txtNub.Text))
                {
                    ProcessingCenter.SendAddFriend(nub, txtNub.Text, txtItem.Text);
                    this.Close();
                    MessageBox.Show("添加中 请稍后");
                }
                else
                {
                    this.Close();
                    MessageBox.Show("该账户已经是您的好友了");
                }
            }
            else
            {
                MessageBox.Show("请将所有的信息填写完全");
            }
        }

        private void txtNub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 关闭该窗口
        /// </summary>
        public void delet_Clsoe()
        {
            this.Invoke(new ThisClose(AD_Clsoe));
        }
        public void AD_Clsoe()
        {
            this.Close();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
