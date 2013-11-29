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
using Wpf;
using Wpf.network;
using Wpf.ZuesMud;
using zeus_mud_wpf_client.network;


namespace zeus_mud_wpf_client.dialog
{
    public partial class frmRoomCreate : Form
    {
        public frmRoomCreate()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textBoxGameName.TextLength == 0)
            {
                MessageBox.Show("房间名不可为空。");
                return;
            }

            roomCreateRequest(textBoxGameName.Text, textBoxGamePassword.Text);
        }
        /// <summary>
        /// 创建游戏房间请求
        /// </summary>
        /// <param name="gameName"></param>
        /// <param name="password"></param>
        public void roomCreateRequest(string gameName, string password)
        {
            Protocol.C2SRoomCreateReq request = new Protocol.C2SRoomCreateReq();
            request.room_name = gameName;
            request.password = password;

            NetworkEvent.sendPacket<Protocol.C2SRoomCreateReq>(request);

            btnCreate.Enabled = false;
            btnCancle.Enabled = false;
        }
        /// <summary>
        /// 创建房间请求回调
        /// </summary>
        /// <param name="stream"></param>
        public void roomCreateCallBack(object sender, NetworkMessageEventArgs e)
        {
            Protocol.S2CRoomCreateRsp response = NetworkEvent.parseMessage<Protocol.S2CRoomCreateRsp>(e.message);
            if (response.room_create_result == true)
            {
                GlobalObject.MainWindowInstance.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(this, Encoding.Default.GetString(response.failed_reason), "创建房间失败。", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreate.Enabled = true;
                btnCancle.Enabled = true;
            }
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
            //注册请求消息回调
            OpcodesProxy.registerHandler<frmRoomCreate>(Opcodes.S2CRoomCreateRsp, this.roomCreateCallBack, this);
        }
    }
}
