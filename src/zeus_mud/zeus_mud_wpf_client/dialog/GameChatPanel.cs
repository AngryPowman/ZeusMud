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
using zeus_mud.game.data;

namespace zeus_mud_wpf_client.dialog
{
    public partial class GameChatPanel : UserControl
    {
        private ChatControl chat;

        public GameChatPanel()
        {
            InitializeComponent();
        }

        private void GameChatPanel_Load(object sender, EventArgs e)
        {
            string page_path = (Environment.CurrentDirectory).Replace("\\", "/") + "/data/chat/chat.html";
            if (File.Exists(page_path) == false)
            {
                MessageBox.Show(this, "聊天模块加载错误，请检查客户端是否完整", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            chat = new ChatControl(ref wbWorldChat, "file://" + page_path);
            // wbWorldChat.IsWebBrowserContextMenuEnabled = true;
        }
    }
}
