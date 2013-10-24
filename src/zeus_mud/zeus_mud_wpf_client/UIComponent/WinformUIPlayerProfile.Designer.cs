namespace zeus_mud_wpf_client.UIComponent
{
    partial class WinformUIPlayerProfile
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblEmailNickname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.ErrorImage = null;
            this.picAvatar.InitialImage = null;
            this.picAvatar.Location = new System.Drawing.Point(60, 7);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(76, 76);
            this.picAvatar.TabIndex = 14;
            this.picAvatar.TabStop = false;
            // 
            // lblEmailNickname
            // 
            this.lblEmailNickname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEmailNickname.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailNickname.Location = new System.Drawing.Point(1, 94);
            this.lblEmailNickname.Name = "lblEmailNickname";
            this.lblEmailNickname.Size = new System.Drawing.Size(197, 12);
            this.lblEmailNickname.TabIndex = 15;
            this.lblEmailNickname.Text = "<None>";
            this.lblEmailNickname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WinformUIPlayerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEmailNickname);
            this.Controls.Add(this.picAvatar);
            this.Name = "WinformUIPlayerProfile";
            this.Size = new System.Drawing.Size(198, 457);
            this.Load += new System.EventHandler(this.WinformUI_Load);
            this.SizeChanged += new System.EventHandler(this.WinformUIPlayerProfile_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEmailNickname;
        private System.Windows.Forms.PictureBox picAvatar;
    }
}
