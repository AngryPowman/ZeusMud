namespace zeus_mud_wpf_client.dialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.ltxtGold = new System.Windows.Forms.TextBox();
            this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonLinkLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
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
            this.label1.Location = new System.Drawing.Point(86, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "上次登录：";
            // 
            // ltxtLastLogin
            // 
            this.ltxtLastLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltxtLastLogin.BackColor = System.Drawing.SystemColors.Control;
            this.ltxtLastLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ltxtLastLogin.Location = new System.Drawing.Point(149, 64);
            this.ltxtLastLogin.Name = "ltxtLastLogin";
            this.ltxtLastLogin.Size = new System.Drawing.Size(193, 14);
            this.ltxtLastLogin.TabIndex = 16;
            this.ltxtLastLogin.Text = "-";
            // 
            // tlblEmail
            // 
            this.tlblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlblEmail.BackColor = System.Drawing.SystemColors.Window;
            this.tlblEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlblEmail.Location = new System.Drawing.Point(88, 26);
            this.tlblEmail.Name = "tlblEmail";
            this.tlblEmail.ReadOnly = true;
            this.tlblEmail.Size = new System.Drawing.Size(253, 14);
            this.tlblEmail.TabIndex = 16;
            this.tlblEmail.Text = "<None>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "金币：";
            // 
            // ltxtGold
            // 
            this.ltxtGold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltxtGold.BackColor = System.Drawing.SystemColors.Control;
            this.ltxtGold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ltxtGold.Location = new System.Drawing.Point(131, 46);
            this.ltxtGold.Name = "ltxtGold";
            this.ltxtGold.Size = new System.Drawing.Size(193, 14);
            this.ltxtGold.TabIndex = 16;
            this.ltxtGold.Text = "-";
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(3, 94);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(35, 20);
            this.kryptonLinkLabel1.TabIndex = 18;
            this.kryptonLinkLabel1.Values.Text = "背包";
            // 
            // kryptonLinkLabel2
            // 
            this.kryptonLinkLabel2.Location = new System.Drawing.Point(44, 94);
            this.kryptonLinkLabel2.Name = "kryptonLinkLabel2";
            this.kryptonLinkLabel2.Size = new System.Drawing.Size(35, 20);
            this.kryptonLinkLabel2.TabIndex = 18;
            this.kryptonLinkLabel2.Values.Text = "社交";
            // 
            // ProfilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonLinkLabel2);
            this.Controls.Add(this.kryptonLinkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tlblEmail);
            this.Controls.Add(this.ltxtGold);
            this.Controls.Add(this.ltxtLastLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.lblLoadingTip);
            this.Controls.Add(this.picAvatar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ProfilePanel";
            this.Size = new System.Drawing.Size(347, 498);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ltxtGold;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel2;
    }
}