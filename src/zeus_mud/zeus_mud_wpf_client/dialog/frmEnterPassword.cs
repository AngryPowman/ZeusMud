using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zeus_mud_wpf_client.dialog
{
    public partial class frmEnterPassword : Form
    {
        public frmEnterPassword()
        {
            InitializeComponent();
        }

        private String m_password;
        private bool m_isCancled = false;

        public bool IsCancled
        {
            get { return IsCancled; }
        }
        public String Password
        {
            get { return m_password; }
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
            m_password = textBox1.Text;
            m_isCancled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_isCancled = true;
        }

    }
}
