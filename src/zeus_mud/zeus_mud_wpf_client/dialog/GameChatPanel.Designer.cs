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
            this.wbWorldChat = new System.Windows.Forms.WebBrowser();
            this.btnDebugRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wbWorldChat
            // 
            this.wbWorldChat.AllowNavigation = false;
            this.wbWorldChat.AllowWebBrowserDrop = false;
            this.wbWorldChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbWorldChat.IsWebBrowserContextMenuEnabled = false;
            this.wbWorldChat.Location = new System.Drawing.Point(0, 0);
            this.wbWorldChat.Margin = new System.Windows.Forms.Padding(0);
            this.wbWorldChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbWorldChat.Name = "wbWorldChat";
            this.wbWorldChat.ScriptErrorsSuppressed = true;
            this.wbWorldChat.ScrollBarsEnabled = false;
            this.wbWorldChat.Size = new System.Drawing.Size(171, 85);
            this.wbWorldChat.TabIndex = 3;
            this.wbWorldChat.WebBrowserShortcutsEnabled = false;
            // 
            // btnDebugRefresh
            // 
            this.btnDebugRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebugRefresh.Location = new System.Drawing.Point(96, 3);
            this.btnDebugRefresh.Name = "btnDebugRefresh";
            this.btnDebugRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnDebugRefresh.TabIndex = 4;
            this.btnDebugRefresh.Text = "刷新";
            this.btnDebugRefresh.UseVisualStyleBackColor = true;
            this.btnDebugRefresh.Click += new System.EventHandler(this.btnDebugRefresh_Click);
            // 
            // GameChatPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnDebugRefresh);
            this.Controls.Add(this.wbWorldChat);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GameChatPanel";
            this.Size = new System.Drawing.Size(200, 100);
            this.Load += new System.EventHandler(this.GameChatPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbWorldChat;
        private System.Windows.Forms.Button btnDebugRefresh;

    }
}
