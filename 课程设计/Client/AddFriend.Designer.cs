namespace Client
{
    partial class AddFriend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFriend));
            this.btnAddF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNub = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddF
            // 
            this.btnAddF.Location = new System.Drawing.Point(229, 139);
            this.btnAddF.Name = "btnAddF";
            this.btnAddF.Size = new System.Drawing.Size(72, 23);
            this.btnAddF.TabIndex = 0;
            this.btnAddF.Text = "添加好友";
            this.btnAddF.UseVisualStyleBackColor = true;
            this.btnAddF.Click += new System.EventHandler(this.btnAddF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "好友账号:";
            // 
            // txtNub
            // 
            this.txtNub.Location = new System.Drawing.Point(106, 32);
            this.txtNub.Name = "txtNub";
            this.txtNub.Size = new System.Drawing.Size(195, 21);
            this.txtNub.TabIndex = 2;
            this.txtNub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNub_KeyPress);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(106, 83);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(195, 21);
            this.txtItem.TabIndex = 4;
            this.txtItem.Text = "我的好友";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "归属分组:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Cornsilk;
            this.label3.Location = new System.Drawing.Point(115, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 10);
            this.label3.TabIndex = 5;
            this.label3.Text = "若填写分组不存在，则自动新建该分组";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // AddFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(355, 188);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNub);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddFriend";
            this.Text = "添加好友";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNub;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}