using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobotWatchman;
using RobotWatchman.network;
namespace zeus_mud.dialog
{
    public partial class frmGameCreate : Form
    {
        public frmGameCreate()
        {
            InitializeComponent();

            //注册请求消息回调
            OpcodesHandler.registerHandler(Opcodes.S2CGameCreateRsp, this.gameCreateCallBack);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textBoxGameName.TextLength == 0)
            {
                MessageBox.Show("房间名不可为空。");
                return;
            }

            if (NetworkEvent.isConnected() == false)
            {
                if (NetworkEvent.connectToServer(GlobalObject.DefaultServer, GlobalObject.DefaultPort) == false)
                {
                    MessageBox.Show(this, "连接服务器失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            gameCreateRequest(textBoxGameName.Text, textBoxGamePassword.Text);
        }
        /// <summary>
        /// 创建游戏房间请求
        /// </summary>
        /// <param name="gameName"></param>
        /// <param name="password"></param>
        public void gameCreateRequest(string gameName, string password)
        {
            Protocol.C2SGameCreateReq request = new Protocol.C2SGameCreateReq();
            request.game_name = gameName;
            request.password = password;

            NetworkEvent.sendPacket<Protocol.C2SGameCreateReq>(request);

            btnCreate.Enabled = false;
            btnCancle.Enabled = false;
        }
        /// <summary>
        /// 创建房间请求回调
        /// </summary>
        /// <param name="stream"></param>
        public void gameCreateCallBack(MemoryStream stream)
        {
            Protocol.S2CGameCreateRsp response = NetworkEvent.parseMessage<Protocol.S2CGameCreateRsp>(stream);
            if (response.game_create_result == true)
            {
                GlobalObject.GameMainForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(this, Encoding.Default.GetString(response.failed_reason), "创建房间失败。", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnCreate.Enabled = true;
            btnCancle.Enabled = true;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxGamePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool ret = true;
            if (e.KeyChar == '\b' || e.KeyChar == '_') //退格键 下划线
            {
                ret = false;
            } 
            else if (e.KeyChar >= 'a' && e.KeyChar <= 'z' )
            {
                ret = false;
            }
            else if (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
            {
                ret = false;
            }
            else if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                ret = false;
            }
            e.Handled = ret;
        }

        private void frmGameCreate_Load(object sender, EventArgs e)
        {

        }
    }
}
