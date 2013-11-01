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

namespace zeus_mud.dialog
{
    public partial class ProfilePanel : UserControl
    {
        public ProfilePanel()
        {
            InitializeComponent();
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

            //加载个人资料
            lblNickname.Text = PlayerProfile.nickname == "" ? "-" : PlayerProfile.nickname;
            tlblEmail.Text = PlayerProfile.email == null ? "<None>" : "<" + PlayerProfile.email + ">";
        }

        private void ProfilePanel_Paint(object sender, PaintEventArgs e)
        {
            lblNickname.BackColor = this.BackColor;
            tlblEmail.BackColor = this.BackColor;
            ltxtLastLogin.BackColor = this.BackColor;
        }
    }
}
