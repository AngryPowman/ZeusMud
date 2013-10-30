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
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            wbWorldChat.Document.InvokeScript("addChatMessage", new Object [] { "xxx"});
            wbWorldChat.Document.Window.ScrollTo(0, 999999);
        }
    }
}
