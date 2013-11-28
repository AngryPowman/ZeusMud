using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wpf.ZuesMud;

namespace zeus_mud_wpf_client.dialog
{
    public partial class frmEnterPassword : Form
    {
        public frmEnterPassword()
        {
            InitializeComponent();
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool ret = true;
            if (e.KeyChar == '\b' || e.KeyChar == '_') //退格键 下划线
            {
                ret = false;
            }
            else if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                ret = false;
            }
            else if (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
            {
                ret = false;
            }
            else if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                ret = false;
            }
            e.Handled = ret;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalObject.RoomListPanelInstance.Password = textBox1.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
