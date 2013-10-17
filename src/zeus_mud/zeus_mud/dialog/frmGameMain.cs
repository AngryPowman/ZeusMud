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
    public partial class frmGameMain : Form
    {
        public frmGameMain()
        {
            InitializeComponent();
            
            txtEmail.Text = "478286460@qq.com";
            txtLevel.Text = "100000";
            txtName.Text = "猫仔";
            txtAEmail.Text = "不对外显示";
            txtALevel.Text = "-10";
            txtAName.Text = "阿超";
            lvRooms.Items.Add("万俊康");
            lvRooms.Items[0].StateImageIndex = 0;
            lvRooms.Items[0].SubItems.Add("1/2");
            lvRooms.Items[0].SubItems.Add("10");
            lvRooms.Items[0].SubItems.Add("1000000");
            lvRooms.Items.Add("李狗蛋");
            lvRooms.Items[0].StateImageIndex = 0;
            lvRooms.Items[0].SubItems.Add("1/2");
            lvRooms.Items[0].SubItems.Add("50");
            lvRooms.Items[0].SubItems.Add("10");
            for (int i = 1; i <= 10; i++)
            {
                lvRooms.Items.Add("李老板" + i.ToString());
                lvRooms.Items[i].StateImageIndex = 0;
                lvRooms.Items[i].SubItems.Add(i.ToString() + "/" + (i+1).ToString());
                lvRooms.Items[i].SubItems.Add("250");
                lvRooms.Items[i].SubItems.Add(i.ToString());
            }
        }

        private void lvRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmGameMain_Load(object sender, EventArgs e)
        {

        }
    }
}
