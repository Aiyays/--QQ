﻿namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnClose = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Label();
            this.MyName = new System.Windows.Forms.Label();
            this.MyAutograph = new System.Windows.Forms.Label();
            this.lable5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MyNub = new System.Windows.Forms.Label();
            this.FriendList = new _CUSTOM_CONTROLS.ChatListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Location = new System.Drawing.Point(262, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 21);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDown
            // 
            this.btnDown.AutoSize = true;
            this.btnDown.BackColor = System.Drawing.Color.Transparent;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDown.Location = new System.Drawing.Point(236, 0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(20, 25);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "-";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // MyName
            // 
            this.MyName.AutoSize = true;
            this.MyName.BackColor = System.Drawing.Color.Transparent;
            this.MyName.Font = new System.Drawing.Font("新宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyName.ForeColor = System.Drawing.Color.Red;
            this.MyName.Location = new System.Drawing.Point(129, 35);
            this.MyName.Name = "MyName";
            this.MyName.Size = new System.Drawing.Size(110, 24);
            this.MyName.TabIndex = 4;
            this.MyName.Text = "新年快年";
            // 
            // MyAutograph
            // 
            this.MyAutograph.AutoSize = true;
            this.MyAutograph.BackColor = System.Drawing.Color.Transparent;
            this.MyAutograph.ForeColor = System.Drawing.SystemColors.Info;
            this.MyAutograph.Location = new System.Drawing.Point(131, 95);
            this.MyAutograph.Name = "MyAutograph";
            this.MyAutograph.Size = new System.Drawing.Size(125, 12);
            this.MyAutograph.TabIndex = 5;
            this.MyAutograph.Text = "春节加wdqwdqwdqwdqwd";
            // 
            // lable5
            // 
            this.lable5.AutoSize = true;
            this.lable5.BackColor = System.Drawing.Color.Transparent;
            this.lable5.ForeColor = System.Drawing.Color.DimGray;
            this.lable5.Location = new System.Drawing.Point(10, 9);
            this.lable5.Name = "lable5";
            this.lable5.Size = new System.Drawing.Size(65, 12);
            this.lable5.TabIndex = 7;
            this.lable5.Text = "聊天主界面";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // MyNub
            // 
            this.MyNub.AutoSize = true;
            this.MyNub.BackColor = System.Drawing.Color.Transparent;
            this.MyNub.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MyNub.Location = new System.Drawing.Point(140, 59);
            this.MyNub.Name = "MyNub";
            this.MyNub.Size = new System.Drawing.Size(59, 12);
            this.MyNub.TabIndex = 9;
            this.MyNub.Text = "135981246";
            // 
            // FriendList
            // 
            this.FriendList.BackColor = System.Drawing.Color.White;
            this.FriendList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FriendList.BackgroundImage")));
            this.FriendList.Font = new System.Drawing.Font("新宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FriendList.ForeColor = System.Drawing.Color.Black;
            this.FriendList.ItemColor = System.Drawing.Color.LightYellow;
            this.FriendList.Location = new System.Drawing.Point(0, 173);
            this.FriendList.Name = "FriendList";
            this.FriendList.ScrollArrowColor = System.Drawing.Color.Black;
            this.FriendList.Size = new System.Drawing.Size(289, 480);
            this.FriendList.SubItemColor = System.Drawing.Color.Bisque;
            this.FriendList.TabIndex = 10;
            this.FriendList.DoubleClickSubItem += new _CUSTOM_CONTROLS.ChatListBox.ChatListEventHandler(this.FriendList_DoubleClickSubItem);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(289, 653);
            this.Controls.Add(this.FriendList);
            this.Controls.Add(this.MyNub);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lable5);
            this.Controls.Add(this.MyAutograph);
            this.Controls.Add(this.MyName);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label btnDown;
        private System.Windows.Forms.Label MyName;
        private System.Windows.Forms.Label MyAutograph;
        private System.Windows.Forms.Label lable5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label MyNub;
        private _CUSTOM_CONTROLS.ChatListBox FriendList;
    }
}