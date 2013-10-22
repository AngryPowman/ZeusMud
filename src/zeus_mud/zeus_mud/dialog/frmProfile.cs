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
    public partial class frmProfile : DockContent
    {
        public frmProfile()
        {
            InitializeComponent();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            lblLoadingTip.Visible = true;
            lblLoadingTip.Text = "0%";
            string avartarIdent = GameUtil.toMD5(LoginData.email);
            string url = "http://www.gravatar.com/avatar/" + avartarIdent;

            picAvatar.LoadCompleted += picAvatar_LoadCompleted;
            picAvatar.LoadProgressChanged += picAvatar_LoadProgressChanged;
            picAvatar.LoadAsync(url.ToLower());
        }

        void picAvatar_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblLoadingTip.Text = e.ProgressPercentage + "%";
        }

        void picAvatar_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lblLoadingTip.Visible = false;
        }

    }
}
