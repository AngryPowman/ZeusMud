using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zeus_mud_wpf_client.UIComponent
{
    public partial class WinformUIPlayerProfile : UserControl
    {
        public WinformUIPlayerProfile()
        {
            InitializeComponent();
        }

        private void WinformUI_Load(object sender, EventArgs e)
        {
            
        }

        private void WinformUIPlayerProfile_SizeChanged(object sender, EventArgs e)
        {
            picAvatar.Left = this.Width / 2 - picAvatar.Width / 2;
            lblEmailNickname.Left = this.Width / 2 - lblEmailNickname.Width / 2;
        }
    }
}
