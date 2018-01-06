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
    public partial class Modify : Form
    {
        private string nub;
        public Modify(string nub)
        {
            InitializeComponent();
            this.nub = nub;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtNub.Text != "" && txtItem.Text != "")
            {
                if (!ProcessingCenter.IsBeItemex(txtNub.Text, txtItem.Text))
                {
                    ProcessingCenter.SendItem(nub, txtNub.Text, txtItem.Text);
                    this.Close();
                    MessageBox.Show("修改成功");
                }
                else
                {
                    this.Close();
                    MessageBox.Show("修改失败，账户"+ txtNub .Text+ "的分组未改变或者该账户不是您的好友");   
                }
            }
            else
            {
                MessageBox.Show("请将您要修改的数据天写完整");
            }

        }

       
    }
}
