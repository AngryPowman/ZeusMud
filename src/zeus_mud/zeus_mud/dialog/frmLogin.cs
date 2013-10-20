using RobotWatchman;
using RobotWatchman.network;
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
using zeus_mud.dialog;
using System.Security.Cryptography;

namespace zeus_mud
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            //登录消息注册
            OpcodesHandler.registerHandler(Opcodes.S2CLoginRsp, this.userLoginCallback);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (GlobalObject.RegisterForm == null) GlobalObject.RegisterForm = new frmRegister();
            GlobalObject.RegisterForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.TextLength == 0 || txtPassword.TextLength == 0)
            {
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

            userLoginRequest(txtUsername.Text, txtPassword.Text);
        }

        //========================================用户登录========================================

        /// <summary>
        /// 登录请求
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void userLoginRequest(string email, string password)
        {
            Protocol.C2SLoginReq request = new Protocol.C2SLoginReq();
            request.email = email;
            request.password = GameUtil.toMD5(password);

            NetworkEvent.sendPacket<Protocol.C2SLoginReq>(request);
        }

        /// <summary>
        /// 登录返回
        /// </summary>
        /// <param name="stream"></param>
        public void userLoginCallback(MemoryStream stream)
        {
            Protocol.S2CLoginRsp response = NetworkEvent.parseMessage<Protocol.S2CLoginRsp>(stream);
            if (response.login_result == true)
            {
                GlobalObject.GameMainForm = new frmGameMain();
                GlobalObject.GameMainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(this, Encoding.Default.GetString(response.failed_reason), "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //========================================================================================

        private void frmLogin_Load(object sender, EventArgs e)
        {
            NetworkEvent.init();
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {

        }
    }
}
