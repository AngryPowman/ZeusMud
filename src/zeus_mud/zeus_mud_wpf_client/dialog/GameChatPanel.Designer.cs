namespace zeus_mud.dialog
{
    partial class GameChatPanel
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
            this.txtSendContent = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.wbWorldChat = new System.Windows.Forms.WebBrowser();
            this.btnDebugRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSendContent
            // 
            this.txtSendContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendContent.Location = new System.Drawing.Point(3, 74);
            this.txtSendContent.Name = "txtSendContent";
            this.txtSendContent.Size = new System.Drawing.Size(161, 21);
            this.txtSendContent.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(170, 74);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(46, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // wbWorldChat
            // 
            this.wbWorldChat.AllowWebBrowserDrop = false;
            this.wbWorldChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbWorldChat.IsWebBrowserContextMenuEnabled = false;
            this.wbWorldChat.Location = new System.Drawing.Point(3, 4);
            this.wbWorldChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbWorldChat.Name = "wbWorldChat";
            this.wbWorldChat.Size = new System.Drawing.Size(268, 64);
            this.wbWorldChat.TabIndex = 3;
            this.wbWorldChat.WebBrowserShortcutsEnabled = false;
            // 
            // btnDebugRefresh
            // 
            this.btnDebugRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebugRefresh.Location = new System.Drawing.Point(223, 74);
            this.btnDebugRefresh.Name = "btnDebugRefresh";
            this.btnDebugRefresh.Size = new System.Drawing.Size(48, 23);
            this.btnDebugRefresh.TabIndex = 4;
            this.btnDebugRefresh.Text = "刷新";
            this.btnDebugRefresh.UseVisualStyleBackColor = true;
            this.btnDebugRefresh.Click += new System.EventHandler(this.btnDebugRefresh_Click);
            // 
            // GameChatPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDebugRefresh);
            this.Controls.Add(this.wbWorldChat);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendContent);
            this.Name = "GameChatPanel";
            this.Size = new System.Drawing.Size(327, 129);
            this.Load += new System.EventHandler(this.GameChatPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSendContent;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.WebBrowser wbWorldChat;
        private System.Windows.Forms.Button btnDebugRefresh;

    }
}
