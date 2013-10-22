using RobotWatchman;
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
    public partial class frmGameMain_ : Form
    {
        public frmGameMain_()
        {
            InitializeComponent();

            txtEmail.Text = "478286460@qq.com";
            txtLevel.Text = "100000";
            txtName.Text = "猫仔";
            lvRooms.Items.Add("群主这个sb");
            lvRooms.Items[0].StateImageIndex = 1;
            lvRooms.Items[0].SubItems.Add("1/2");
            lvRooms.Items[0].SubItems.Add("-10");
            /*lvRooms.Items.Add("李狗蛋");
            lvRooms.Items[1].StateImageIndex = 0;
            lvRooms.Items[1].SubItems.Add("1/2");
            lvRooms.Items[1].SubItems.Add("10");
            for (int i = 1; i <= 10; i++)
            {
                lvRooms.Items.Add("李老板" + i.ToString());
                lvRooms.Items[i+1].StateImageIndex = 0;
                lvRooms.Items[i+1].SubItems.Add(i.ToString() + "/" + (i+1).ToString());
                lvRooms.Items[i+1].SubItems.Add(i.ToString());
            }*/
        }

        private void lvRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRooms.SelectedItems.Count == 0)
                return;

            int a = lvRooms.SelectedItems[0].Index;
            picEnemy.Image = imgsLarge.Images[1];
            txtAName.Text = lvRooms.SelectedItems[0].Text;
            txtAEmail.Text = "未知";
            txtALevel.Text = lvRooms.SelectedItems[0].SubItems[2].Text;
        }

        private void frmGameMain_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnFight_Click(object sender, EventArgs e)
        {
            GlobalObject.BattleForm = new frmBattle();
            GlobalObject.BattleForm.Show();
            this.Hide();
        }

        private void frmGameMain__Activated(object sender, EventArgs e)
        {
            btnFight_Click(frmGameMain_.ActiveForm, null);
        }
    }
}
