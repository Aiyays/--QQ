
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using System.Diagnostics;

namespace Client
{
    public delegate void AdoptType();
    public delegate void Trigger(bool a);
    public partial class Land : LayeredForm
    {
        
        #region  背景
        public Land()
        {
            InitializeComponent();
            ProcessingCenter.MainF = false;
            ClsoeT = new AdoptType(_close);
            EnabledT = new AdoptType(_Enabled);
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
            ProcessingCenter.ChageAdoptL = new Adopt(ReciveLand);
            
        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMoveMouseDown(object sender, MouseEventArgs e)
        {
            LayeredSkin.NativeMethods.MouseToMoveControl(this.Handle);
        }

        Image Cloud = Image.FromFile("Images\\cloud.png");
        float cloudX = 0;
        Image yezi;
        float angle = 10;
        bool RotationDirection = true;//是否为顺时针

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
            using (Image temp = LayeredSkin.ImageEffects.RotateImage(yezi, angle, new Point(25, 3)))
            {
                g.DrawImage(temp, 140, 70);//绘制叶子
            }
            base.OnLayeredPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LayeredPaint();
            GC.Collect();
        }
        #endregion

        #region 逻辑
        /// <summary>
        /// 定义的跨线程关闭和显示控件可用的委托代理
        /// </summary>
        AdoptType ClsoeT;
        AdoptType EnabledT;
        public static Trigger Adopt;
        

        /// <summary>
        /// 注册界面
        /// </summary>
        private void btnregister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            Adopt=new Trigger(register.rigger);
            register.ShowDialog();

        }

        /// <summary>
        /// 接受到登录的反馈
        /// </summary>
        /// <param 接收到的json="json"></param>
        public void ReciveLand(string json)
        {
            Debug.Print(ProcessingCenter.GetType(json)[1]);
            if (ProcessingCenter.GetType(json)[1] == "True")
            {
                MessageBox.Show("登录成功");
                ProcessingCenter.MainF = true;
                this.Invoke(ClsoeT);
            }
            else
            {
                this.Invoke(EnabledT);
                MessageBox.Show("登录失败,密码或者账号错误");
                
            }
        }

        /// <summary>
        /// 被代理的关闭和控件用的方法
        /// </summary>
        public void _close()
        {
            this.Close();
        }
        public void _Enabled()
        {
            this.Enabled = true;
        }

        /// <summary>
        /// 判断账号框和密码框是否为空
        /// </summary>
        /// <returns></returns>
        private bool AdoptLand()
        {
            return txtUser.Text != "" && txtPd.Text != "";
        }
        #endregion

        private void btnland_Click(object sender, EventArgs e)
        {
            if (AdoptLand())
            {
                ProcessingCenter.SendLand(txtUser.Text,txtPd.Text,BtnRember.Checked.ToString(), System.Net.Dns.GetHostName());
                MessageBox.Show("登录中，请稍后");



            }
            else
            {
                MessageBox.Show("请输入账号密码所有的信息！！");
            }
        }

        
        
    }
}
