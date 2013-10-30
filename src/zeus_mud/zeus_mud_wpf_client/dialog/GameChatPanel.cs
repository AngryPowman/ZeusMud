using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace zeus_mud.dialog
{
    public partial class GameChatPanel : UserControl
    {
        public GameChatPanel()
        {
            InitializeComponent();
        }

        private void GameChatPanel_Load(object sender, EventArgs e)
        {
            string page_path = (Environment.CurrentDirectory + "/data/chat/chat.html").Replace("\\", "/");
            string urlPath = @"file://" + page_path;
            if (File.Exists(page_path) == false)
            {
                MessageBox.Show(this, "聊天模块加载错误，请检查客户端是否完整", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            wbWorldChat.Navigate(urlPath);
            wbWorldChat.AllowNavigation = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            wbWorldChat.Document.InvokeScript("addChatMessage", new Object [] { 1, "不射脸还是好朋友", txtSendContent.Text});
            wbWorldChat.Document.Window.ScrollTo(0, 999999);
        }
    }
}
