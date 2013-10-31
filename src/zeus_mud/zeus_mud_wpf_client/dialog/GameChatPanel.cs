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
    [System.Runtime.InteropServices.ComVisible(true)]
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

            wbWorldChat.ObjectForScripting = this;
            wbWorldChat.Navigate(urlPath + "?current_user=射脸也是好朋友");
            wbWorldChat.AllowNavigation = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            wbWorldChat.Document.InvokeScript("addChatMessage", new Object [] { 1, 10000, "飞翔的企鹅", 0, txtSendContent.Text});
            wbWorldChat.Document.Window.ScrollTo(0, 999999);
        }

        private void btnDebugRefresh_Click(object sender, EventArgs e)
        {
            wbWorldChat.Refresh(WebBrowserRefreshOption.Completely);
        }

        public void sendMessage(String content){
            MessageBox.Show(content);
        }

        public void userNameClicked(int id)
        {
            MessageBox.Show("点击了用户："+id);
        }
    }
}
