using Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using zeus_mud.game.data;
using zeus_mud.network;
using Wpf.ZuesMud;
using Wpf.network;
using System.IO;
using zeus_mud_wpf_client.network;

namespace zeus_mud_wpf_client.dialog
{
    public partial class ProfilePanel : UserControl
    {
        public ProfilePanel()
        {
            InitializeComponent();

            //登录消息注册
            OpcodesProxy.registerHandler<ProfilePanel>(Opcodes.S2CGetPlayerProfileRsp, this.getPlayerProfileCallback, this);
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            loadProfile();

            //开始心跳线程
            NetworkEvent.startHeartbeat(10000);
        }

        public void sendHeartbeatProxy()
        {
            Protocol.C2SHeartbeat heartbeat = new Protocol.C2SHeartbeat();
            NetworkEvent.sendPacket<Protocol.C2SHeartbeat>(heartbeat);
        }

        void picAvatar_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblLoadingTip.Text = e.ProgressPercentage + "%";
        }

        void picAvatar_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lblLoadingTip.Visible = false;
        }

        void loadProfile()
        {
            //加载avatar
            lblLoadingTip.Visible = true;
            lblLoadingTip.Text = "0%";

            picAvatar.LoadCompleted += picAvatar_LoadCompleted;
            picAvatar.LoadProgressChanged += picAvatar_LoadProgressChanged;
            picAvatar.LoadAsync(GlobalObject.Email2PhotoUrl(LoginData.email).ToLower());
            
            //向服务器请求个人资料
            getPlayerProfileRequest();
        }

        private void ProfilePanel_Paint(object sender, PaintEventArgs e)
        {
            lblNickname.BackColor = this.BackColor;
            tlblEmail.BackColor = this.BackColor;
            ltxtLastLogin.BackColor = this.BackColor;
        }

        /// <summary>
        /// 向服务器获取个人资料
        /// </summary>
        void getPlayerProfileRequest()
        {
            Protocol.C2SGetPlayerProfileReq request = new Protocol.C2SGetPlayerProfileReq();
            NetworkEvent.sendPacket<Protocol.C2SGetPlayerProfileReq>(request);
        }

        /// <summary>
        /// 服务器返回个人资料
        /// </summary>
        /// <param name="stream"></param>
        public void getPlayerProfileCallback(object sender, NetworkMessageEventArgs e)
        {
            Protocol.S2CGetPlayerProfileRsp response = NetworkEvent.parseMessage<Protocol.S2CGetPlayerProfileRsp>(e.message);
            PlayerProfile.guid = response.guid;
            PlayerProfile.nickname = Encoding.UTF8.GetString(response.nickname);
            PlayerProfile.gender = response.gender;
            PlayerProfile.last_login = response.last_login;
            PlayerProfile.gold = response.gold;

            lblNickname.Text = PlayerProfile.nickname == null ? "-" : PlayerProfile.nickname;
            tlblEmail.Text = PlayerProfile.email == null ? "<无>" : "<" + PlayerProfile.email + ">";
            
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddSeconds(PlayerProfile.last_login);
            ltxtLastLogin.Text = dt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");

            ltxtGold.Text = PlayerProfile.gold.ToString();
        }
    }
}
