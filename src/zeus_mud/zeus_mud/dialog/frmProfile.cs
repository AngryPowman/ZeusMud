using RobotWatchman;
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
using WeifenLuo.WinFormsUI.Docking;
using zeus_mud.game.data;
using zeus_mud.network;

namespace zeus_mud.dialog
{
    public partial class frmProfile : UserControl
    {
        public frmProfile()
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
            lblEmailNickname.Text = PlayerProfile.nickname + "<" + LoginData.email + ">";
        }
    }
}
