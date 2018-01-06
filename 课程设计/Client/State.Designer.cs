namespace Client
{
    partial class State
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(State));
            this.StOnLine = new System.Windows.Forms.PictureBox();
            this.StLeave = new System.Windows.Forms.PictureBox();
            this.StBusy = new System.Windows.Forms.PictureBox();
            this.StWaite = new System.Windows.Forms.PictureBox();
            this.StRefuse = new System.Windows.Forms.PictureBox();
            this.StInvisible = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.StOnLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StBusy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StWaite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StRefuse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StInvisible)).BeginInit();
            this.SuspendLayout();
            // 
            // StOnLine
            // 
            this.StOnLine.BackColor = System.Drawing.Color.Transparent;
            this.StOnLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StOnLine.BackgroundImage")));
            this.StOnLine.Location = new System.Drawing.Point(1, -1);
            this.StOnLine.Name = "StOnLine";
            this.StOnLine.Size = new System.Drawing.Size(10, 12);
            this.StOnLine.TabIndex = 15;
            this.StOnLine.TabStop = false;
            this.StOnLine.Click += new System.EventHandler(this.StOnLine_Click);
            // 
            // StLeave
            // 
            this.StLeave.BackColor = System.Drawing.Color.Transparent;
            this.StLeave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StLeave.BackgroundImage")));
            this.StLeave.Location = new System.Drawing.Point(33, -1);
            this.StLeave.Name = "StLeave";
            this.StLeave.Size = new System.Drawing.Size(10, 13);
            this.StLeave.TabIndex = 16;
            this.StLeave.TabStop = false;
            this.StLeave.Click += new System.EventHandler(this.StLeave_Click);
            // 
            // StBusy
            // 
            this.StBusy.BackColor = System.Drawing.Color.Transparent;
            this.StBusy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StBusy.BackgroundImage")));
            this.StBusy.Location = new System.Drawing.Point(49, -1);
            this.StBusy.Name = "StBusy";
            this.StBusy.Size = new System.Drawing.Size(10, 13);
            this.StBusy.TabIndex = 17;
            this.StBusy.TabStop = false;
            this.StBusy.Click += new System.EventHandler(this.StBusy_Click);
            // 
            // StWaite
            // 
            this.StWaite.BackColor = System.Drawing.Color.Transparent;
            this.StWaite.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StWaite.BackgroundImage")));
            this.StWaite.Location = new System.Drawing.Point(17, -1);
            this.StWaite.Name = "StWaite";
            this.StWaite.Size = new System.Drawing.Size(10, 13);
            this.StWaite.TabIndex = 18;
            this.StWaite.TabStop = false;
            this.StWaite.Click += new System.EventHandler(this.StWaite_Click);
            // 
            // StRefuse
            // 
            this.StRefuse.BackColor = System.Drawing.Color.Transparent;
            this.StRefuse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StRefuse.BackgroundImage")));
            this.StRefuse.Location = new System.Drawing.Point(65, -1);
            this.StRefuse.Name = "StRefuse";
            this.StRefuse.Size = new System.Drawing.Size(10, 13);
            this.StRefuse.TabIndex = 19;
            this.StRefuse.TabStop = false;
            this.StRefuse.Click += new System.EventHandler(this.StRefuse_Click);
            // 
            // StInvisible
            // 
            this.StInvisible.BackColor = System.Drawing.Color.Transparent;
            this.StInvisible.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StInvisible.BackgroundImage")));
            this.StInvisible.Location = new System.Drawing.Point(81, -1);
            this.StInvisible.Name = "StInvisible";
            this.StInvisible.Size = new System.Drawing.Size(10, 13);
            this.StInvisible.TabIndex = 20;
            this.StInvisible.TabStop = false;
            this.StInvisible.Click += new System.EventHandler(this.StInvisible_Click);
            // 
            // State
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(94, 13);
            this.Controls.Add(this.StInvisible);
            this.Controls.Add(this.StRefuse);
            this.Controls.Add(this.StWaite);
            this.Controls.Add(this.StBusy);
            this.Controls.Add(this.StLeave);
            this.Controls.Add(this.StOnLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(300, 300);
            this.Name = "State";
            this.Text = "State";
            this.Click += new System.EventHandler(this.State_Click);
            ((System.ComponentModel.ISupportInitialize)(this.StOnLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StBusy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StWaite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StRefuse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StInvisible)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox StOnLine;
        private System.Windows.Forms.PictureBox StLeave;
        private System.Windows.Forms.PictureBox StBusy;
        private System.Windows.Forms.PictureBox StWaite;
        private System.Windows.Forms.PictureBox StRefuse;
        private System.Windows.Forms.PictureBox StInvisible;
    }
}