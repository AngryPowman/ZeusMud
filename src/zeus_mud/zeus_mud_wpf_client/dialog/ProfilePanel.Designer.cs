namespace zeus_mud.dialog
{
    partial class ProfilePanel
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
            this.lblLoadingTip = new System.Windows.Forms.Label();
            this.lblNickname = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.ltxtLastLogin = new System.Windows.Forms.TextBox();
            this.tlblEmail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.ErrorImage = null;
            this.picAvatar.InitialImage = null;
            this.picAvatar.Location = new System.Drawing.Point(5, 5);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(72, 72);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAvatar.TabIndex = 6;
            this.picAvatar.TabStop = false;
            // 
            // lblLoadingTip
            // 
            this.lblLoadingTip.AutoSize = true;
            this.lblLoadingTip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblLoadingTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLoadingTip.Location = new System.Drawing.Point(30, 33);
            this.lblLoadingTip.Name = "lblLoadingTip";
            this.lblLoadingTip.Size = new System.Drawing.Size(17, 12);
            this.lblLoadingTip.TabIndex = 13;
            this.lblLoadingTip.Text = "0%";
            // 
            // lblNickname
            // 
            this.lblNickname.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.lblNickname.Location = new System.Drawing.Point(82, 2);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(17, 26);
            this.lblNickname.TabIndex = 14;
            this.lblNickname.Values.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "上次登录：";
            // 
            // ltxtLastLogin
            // 
            this.ltxtLastLogin.BackColor = System.Drawing.SystemColors.Control;
            this.ltxtLastLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ltxtLastLogin.Location = new System.Drawing.Point(149, 66);
            this.ltxtLastLogin.Name = "ltxtLastLogin";
            this.ltxtLastLogin.Size = new System.Drawing.Size(100, 14);
            this.ltxtLastLogin.TabIndex = 16;
            this.ltxtLastLogin.Text = "-";
            // 
            // tlblEmail
            // 
            this.tlblEmail.BackColor = System.Drawing.SystemColors.Window;
            this.tlblEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlblEmail.Location = new System.Drawing.Point(88, 26);
            this.tlblEmail.Name = "tlblEmail";
            this.tlblEmail.ReadOnly = true;
            this.tlblEmail.Size = new System.Drawing.Size(100, 14);
            this.tlblEmail.TabIndex = 16;
            this.tlblEmail.Text = "<None>";
            // 
            // ProfilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlblEmail);
            this.Controls.Add(this.ltxtLastLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.lblLoadingTip);
            this.Controls.Add(this.picAvatar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ProfilePanel";
            this.Size = new System.Drawing.Size(343, 262);
            this.Load += new System.EventHandler(this.frmProfile_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProfilePanel_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoadingTip;
        public System.Windows.Forms.PictureBox picAvatar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNickname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ltxtLastLogin;
        private System.Windows.Forms.TextBox tlblEmail;
    }
}