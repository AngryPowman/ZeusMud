using Wpf;
using Wpf.network;
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
using zeus_mud_wpf_client.dialog;
using System.Security.Cryptography;
using zeus_mud.game.data;
using System.Xml;
using Wpf.ZuesMud;
using zeus_mud_wpf_client;
using zeus_mud_wpf_client.network;

namespace zeus_mud
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            //登录消息注册
            OpcodesProxy.registerHandler<frmLogin>(Opcodes.S2CLoginRsp, this.userLoginCallback, this);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (GlobalObject.RegisterWindowInstance == null) GlobalObject.RegisterWindowInstance = new frmRegister();
            GlobalObject.RegisterWindowInstance.ShowDialog();
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
        private bool isHash = false;
        private string passwordHash;
        public void userLoginRequest(string email, string password)
        {
            Protocol.C2SLoginReq request = new Protocol.C2SLoginReq();
            if (isHash)
            {
                request.password = passwordHash;
            }
            else
            { 
                request.password = GameUtil.toMD5(password);
            }
            request.email = email;

            NetworkEvent.sendPacket<Protocol.C2SLoginReq>(request);
        }

        /// <summary>
        /// 登录返回
        /// </summary>
        /// <param name="stream"></param>
        public void userLoginCallback(object sender, NetworkMessageEventArgs e)
        {
            Protocol.S2CLoginRsp response = NetworkEvent.parseMessage<Protocol.S2CLoginRsp>(e.message);
            if (response.login_result == true)
            {
                saveXml();
                LoginData.email = PlayerProfile.email = txtUsername.Text;
                GlobalObject.MainWindowInstance = new GameMainWindow();
                GlobalObject.MainWindowInstance.Show();
                this.Hide();//XXX: 若要关闭当前窗口，需要注意下头closed逻辑
            }
            else
            {
                MessageBox.Show(this, Encoding.Default.GetString(response.failed_reason), "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveXml()
        {
            XmlDocument x = new XmlDocument();

            if (File.Exists(GlobalObject.ConfigPath))
            {
                x.Load(GlobalObject.ConfigPath);
            }
            else
            {
                x.LoadXml("<Root></Root>");
            }
            XmlNode Root = x.SelectSingleNode("Root");
            XmlNodeList nl = Root.ChildNodes;
            XmlElement el = null;
            foreach (XmlNode n in nl)
            {
                if (n.Name == "帐号")
                {
                    el = (XmlElement)n;
                    break;
                }
            }
            if (el == null)
            {
                el = x.CreateElement("帐号");
                Root.AppendChild(el);
            }
            el.SetAttribute("邮箱", txtUsername.Text);
            if (isHash == false)
            {
                el.SetAttribute("密码", chkSavePwd.Checked ?
                    GameUtil.toMD5(txtPassword.Text) : string.Empty);
            }
            el.SetAttribute("自动登录", chkAutoLogin.Checked?"true":"false");
            x.Save(GlobalObject.ConfigPath);
        }

        private void loadXml()
        {
            XmlDocument x = new XmlDocument();
            if (File.Exists(GlobalObject.ConfigPath))
            {
                x.Load(GlobalObject.ConfigPath);
            }
            else{ return; }

            foreach (XmlNode n in x.ChildNodes)
            {
                if (n.Name == "Root")
                    foreach (XmlNode n2 in n.ChildNodes)
                    {
                        if (n2.Name == "帐号")
                        {
                            XmlElement e2 = (XmlElement)n2;
                            txtUsername.Text = e2.GetAttribute("邮箱");
                            passwordHash = e2.GetAttribute("密码");
                            if (passwordHash.Length != 0)
                            {
                                txtPassword.Text = "password";
                                isHash = true;
                            }
                            if (e2.GetAttribute("自动登录")=="true")
                            {
                                chkAutoLogin.Checked = true;
                                btnLogin_Click(this, null);
                            }
                            return;
                        }
                    }
            }
        }

        //========================================================================================

        private void frmLogin_Load(object sender, EventArgs e)
        {            
            NetworkEvent.init();
            loadXml();
            if (File.Exists(GlobalObject.EmailToPhoto.UrlLocalCachePath))
            {
                using (var stream = new FileStream(GlobalObject.EmailToPhoto.UrlLocalCachePath, FileMode.Open))
                {
                    Image img = Image.FromStream(stream);
                    picAvatar.InitialImage = img;
                    GlobalObject.EmailToPhoto.Avatar = img;
                    //这里不能用fromfile：fromfile在读取之后不会关闭句柄，这将导致下头的save失败
                    //这里的img不能省略，不应当操作GlobalObject.EmailToPhoto.Avatar 
                }
            }
            picAvatar.LoadAsync(GlobalObject.EmailToPhoto.Url(txtUsername.Text).ToLower());
            gifBox.initGif(60);
            btnLogin.Select();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gifBox.fpsGif = (11 - trackBar1.Value) * 10;
        }

        private void chkAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            chkSavePwd.Checked = true;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (isHash)
            {
                txtPassword.SelectAll();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (isHash)
            {
                isHash = false;
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (isHash)
            {
                txtPassword.SelectAll();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown(); //退出本程序。这是个wpf程序，因此Application.Exit()无效。
            // XXX: 上头是hide，而不是关闭本窗口，修改该逻辑需要修改本处代码
        }

        private void picAvatar_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (picAvatar.ImageLocation.ToLower().StartsWith("http://"))
            {
                picAvatar.Image.Save(GlobalObject.EmailToPhoto.UrlLocalCachePath);
                GlobalObject.EmailToPhoto.Avatar = picAvatar.Image;//这里和上面的缓存是唯一设置Avatar的。
                //注意在frmlogin中不会读取 GlobalObject.EmailToPhoto.Avatar ，而其他地方不会写 GlobalObject.EmailToPhoto.Avatar，从而不会产生线程问题
            }
        }

    }
}
