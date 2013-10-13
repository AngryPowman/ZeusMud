using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zeus_mud.dialog
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            rdMale.Checked = true;
            rdFemale_CheckedChanged(rdMale, null);
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            pnlBWH.Visible = rdFemale.Checked;
            if (rdFemale.Checked == true)
            {
                groupBox1.Height = 295;
                btnOk.Top = 339;
                btnCancel.Top = 339;
                this.Height = 408;
            }
            else
            {
                groupBox1.Height = 169;
                btnOk.Top = 213;
                btnCancel.Top = 213;
                this.Height = 276;
            }
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label9.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label10.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label11.Text = trackBar3.Value.ToString();
        }
    }
}
