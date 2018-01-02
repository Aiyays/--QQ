
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;

namespace Client
{
    public delegate void RFeedBack();
    public partial class Register : LayeredForm
    {
        public static RFeedBack Enab;
        public static RFeedBack Clos;
        #region 定义的背景的基础变量
        Image Cloud = Image.FromFile("Images\\cloud.png");
        float cloudX = 0;
        Image yezi;
        float angle = 10;
        bool RotationDirection = true;//是否为顺时针
        #endregion

        #region 背景
        public Register()
        {
            InitializeComponent();
            Enab = new RFeedBack(_Enabled);
            Clos = new RFeedBack(_Close);
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void QQ_Load(object sender, EventArgs e)
        {
            yezi = new Bitmap(90, 80);//先把叶子画在稍微大一点的画布上，这样叶子旋转的时候才不会被裁掉一部分
            using (Graphics g = Graphics.FromImage(yezi))
            {
                g.DrawImage(Image.FromFile("Images\\yezi3.png"), 10, 0);
            }
            timer1.Start();
        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMoveMouseDown(object sender, MouseEventArgs e)
        {
            LayeredSkin.NativeMethods.MouseToMoveControl(this.Handle);
        }

        protected override void OnLayeredPaint(LayeredSkin.LayeredEventArgs e)
        {
            Graphics g = e.Graphics;
            if (cloudX > this.Width - Cloud.Width)
            {//云的飘动
                cloudX = 0;
            }
            else
            {
                cloudX += 0.5f;
            }
            g.DrawImage(Cloud, cloudX, 0);//把云绘制上去

            if (angle > 10)
            {//控制旋转方向
                RotationDirection = false;
            }
            if (angle < -10)
            {
                RotationDirection = true;
            }
            if (RotationDirection)
            {
                angle += 1;
            }
            else
            {
                angle -= 1;
            }
          
            base.OnLayeredPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LayeredPaint();
            GC.Collect();
        }


        #endregion

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (Jodge())
            {
                if (txtUSerPd.Text == txtSurePd.Text)
                {
                    try
                    {
                        ProcessingCenter.SendRegister(txtUserID.Text, txtUserName.Text, txtSurePd.Text, txtAutograph.Text);
                        MessageBox.Show("注册中。。");
                        Enabled = false;
                    }
                    catch
                    {
                        MessageBox.Show("注册失败，请检查网络连接");
                    }
                }
                else
                {
                    MessageBox.Show("两次密码输入请一致");
                }
            }
            else
            {
                MessageBox.Show("请将所有信息填写完整");
            }
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 判断所有的选项是否为空
        /// </summary>
        /// <returns>如果所有都有输入 则返回true</returns>
        private bool Jodge()
        {
            return txtSurePd.Text != "" && txtUserID.Text != "" && txtUserName.Text != "" && txtUSerPd.Text != ""&& txtAutograph.Text!="";
        }

        /// <summary>
        /// 开启整个页面
        /// </summary>
        public void _Enabled()
        {
            this.Enabled = true;
        }

        /// <summary>
        /// 关闭注册页面
        /// </summary>
        public void _Close()
        {
            this.Close();
        }

        public  void rigger(bool a)
        {
            if (a)
            {
                this.Invoke(Register.Enab);
                MessageBox.Show("该账号已经被注册");
            }
            else
            {
                MessageBox.Show("注册成功");
                this.Invoke(Register.Clos);
            }
        }
    }
}
