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

namespace zeus_mud
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            register.ShowDialog();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.TextLength == 0 || txtPassword.TextLength == 0)
            {
                return;
            }

            if (NetworkEvent.connectToServer("127.0.0.1", 36911) == true)
            {
                NetworkEvent.sendLoginRequest(txtUsername.Text, txtPassword.Text);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            NetworkEvent.init();
        }

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
                MessageBox.Show(this, Encoding.Default.GetString( response.failed_reason), "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
