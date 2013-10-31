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
            this.lblEmailNickname = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.ErrorImage = null;
            this.picAvatar.InitialImage = null;
            this.picAvatar.Location = new System.Drawing.Point(29, 12);
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
            this.lblLoadingTip.Location = new System.Drawing.Point(40, 42);
            this.lblLoadingTip.Name = "lblLoadingTip";
            this.lblLoadingTip.Size = new System.Drawing.Size(17, 12);
            this.lblLoadingTip.TabIndex = 13;
            this.lblLoadingTip.Text = "0%";
            // 
            // lblEmailNickname
            // 
            this.lblEmailNickname.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.lblEmailNickname.Location = new System.Drawing.Point(3, 90);
            this.lblEmailNickname.Name = "lblEmailNickname";
            this.lblEmailNickname.Size = new System.Drawing.Size(61, 26);
            this.lblEmailNickname.TabIndex = 14;
            this.lblEmailNickname.Values.Text = "<None>";
            // 
            // ProfilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEmailNickname);
            this.Controls.Add(this.lblLoadingTip);
            this.Controls.Add(this.picAvatar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ProfilePanel";
            this.Size = new System.Drawing.Size(343, 262);
            this.Load += new System.EventHandler(this.frmProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoadingTip;
        public System.Windows.Forms.PictureBox picAvatar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblEmailNickname;
    }
}