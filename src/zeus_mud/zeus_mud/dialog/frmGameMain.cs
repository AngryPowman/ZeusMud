using Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace zeus_mud.dialog
{
    public partial class frmGameMain : Form
    {
        
        public frmGameMain()
        {
            InitializeComponent();
        }

        private void frmGameMain_Load(object sender, EventArgs e)
        {
            //GlobalObject.ProfileForm.Show(dockPanel1, DockState.DockLeft);
        }

        private void 个人资料PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你有个毛资料");
        }
    }
}
