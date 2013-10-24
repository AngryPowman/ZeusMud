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
            this.lblEmailNickname = new System.Windows.Forms.TextBox();
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
            this.picAvatar.Size = new System.Drawing.Size(72, 72);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAvatar.TabIndex = 6;
            this.picAvatar.TabStop = false;
            // 
            // txt1Level
            // 
            this.txt1Level.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt1Level.Location = new System.Drawing.Point(12, 122);
            this.txt1Level.Name = "txt1Level";
            this.txt1Level.ReadOnly = true;
            this.txt1Level.Size = new System.Drawing.Size(57, 14);
            this.txt1Level.TabIndex = 12;
            this.txt1Level.Text = "等级:";
            // 
            // lblEmailNickname
            // 
            this.lblEmailNickname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblEmailNickname.Location = new System.Drawing.Point(12, 90);
            this.lblEmailNickname.Name = "lblEmailNickname";
            this.lblEmailNickname.ReadOnly = true;
            this.lblEmailNickname.Size = new System.Drawing.Size(224, 14);
            this.lblEmailNickname.TabIndex = 10;
            this.lblEmailNickname.Text = "<None>";
            // 
            // lblLoadingTip
            // 
            this.lblLoadingTip.AutoSize = true;
            this.lblLoadingTip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblLoadingTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLoadingTip.Location = new System.Drawing.Point(40, 42);
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
            this.Controls.Add(this.lblEmailNickname);
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

        private System.Windows.Forms.TextBox txt1Level;
        private System.Windows.Forms.TextBox lblEmailNickname;
        private System.Windows.Forms.Label lblLoadingTip;
        public System.Windows.Forms.PictureBox picAvatar;
    }
}