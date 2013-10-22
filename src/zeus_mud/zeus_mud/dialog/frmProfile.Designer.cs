namespace zeus_mud.dialog
{
    partial class frmProfile
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
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.txt1Level = new System.Windows.Forms.TextBox();
            this.txt1Name = new System.Windows.Forms.TextBox();
            this.txt1Email = new System.Windows.Forms.TextBox();
            this.lblLoadingTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.ErrorImage = null;
            this.picAvatar.InitialImage = null;
            this.picAvatar.Location = new System.Drawing.Point(12, 12);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(64, 64);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAvatar.TabIndex = 6;
            this.picAvatar.TabStop = false;
            // 
            // txt1Level
            // 
            this.txt1Level.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt1Level.Location = new System.Drawing.Point(93, 54);
            this.txt1Level.Name = "txt1Level";
            this.txt1Level.ReadOnly = true;
            this.txt1Level.Size = new System.Drawing.Size(57, 14);
            this.txt1Level.TabIndex = 12;
            this.txt1Level.Text = "你的等级:";
            // 
            // txt1Name
            // 
            this.txt1Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt1Name.Location = new System.Drawing.Point(93, 36);
            this.txt1Name.Name = "txt1Name";
            this.txt1Name.ReadOnly = true;
            this.txt1Name.Size = new System.Drawing.Size(57, 14);
            this.txt1Name.TabIndex = 11;
            this.txt1Name.Text = "你的名称:";
            // 
            // txt1Email
            // 
            this.txt1Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt1Email.Location = new System.Drawing.Point(93, 17);
            this.txt1Email.Name = "txt1Email";
            this.txt1Email.ReadOnly = true;
            this.txt1Email.Size = new System.Drawing.Size(57, 14);
            this.txt1Email.TabIndex = 10;
            this.txt1Email.Text = "你的帐号:";
            // 
            // lblLoadingTip
            // 
            this.lblLoadingTip.AutoSize = true;
            this.lblLoadingTip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblLoadingTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLoadingTip.Location = new System.Drawing.Point(37, 38);
            this.lblLoadingTip.Name = "lblLoadingTip";
            this.lblLoadingTip.Size = new System.Drawing.Size(17, 12);
            this.lblLoadingTip.TabIndex = 13;
            this.lblLoadingTip.Text = "0%";
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 262);
            this.Controls.Add(this.lblLoadingTip);
            this.Controls.Add(this.txt1Level);
            this.Controls.Add(this.txt1Name);
            this.Controls.Add(this.txt1Email);
            this.Controls.Add(this.picAvatar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmProfile";
            this.Text = "个人资料";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.TextBox txt1Level;
        private System.Windows.Forms.TextBox txt1Name;
        private System.Windows.Forms.TextBox txt1Email;
        private System.Windows.Forms.Label lblLoadingTip;
    }
}