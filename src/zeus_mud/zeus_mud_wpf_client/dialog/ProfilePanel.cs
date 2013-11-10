﻿using Wpf;
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

namespace zeus_mud_wpf_client.dialog
{
    public partial class ProfilePanel : UserControl
    {
        public ProfilePanel()
        {
            InitializeComponent();

            //登录消息注册
            OpcodesHandler.registerHandler(Opcodes.S2CGetPlayerProfileRsp, this.getPlayerProfileCallback);
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            loadProfile();
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
        public void getPlayerProfileCallback(MemoryStream stream)
        {
            Protocol.S2CGetPlayerProfileRsp response = NetworkEvent.parseMessage<Protocol.S2CGetPlayerProfileRsp>(stream);
            PlayerProfile.guid = response.guid;
            PlayerProfile.nickname = Encoding.UTF8.GetString(response.nickname);
            PlayerProfile.gender = response.gender;
            PlayerProfile.last_login = response.last_login;

            lblNickname.Text = PlayerProfile.nickname == null ? "-" : PlayerProfile.nickname;
            tlblEmail.Text = PlayerProfile.email == null ? "<无>" : "<" + PlayerProfile.email + ">";

            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddSeconds(PlayerProfile.last_login);
            ltxtLastLogin.Text = dt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
