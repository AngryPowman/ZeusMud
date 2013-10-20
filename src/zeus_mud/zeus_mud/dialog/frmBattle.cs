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
    public partial class frmBattle : Form
    {
        int theFourth = -1;
        int[] ACard = { -1, -1, -1, -1 };
        int[] ACardset = { 0, 1, 2, 3 };
        int tipsIndex = 0;
        int btnIndex = 0;
        int cardFight = -1;
        int mPoint = 0;
        int APoint = 0;
        public frmBattle()
        {
            InitializeComponent();
        }

        private void frmBattle_Load(object sender, EventArgs e)
        {
            picEnemy.Image = GlobalObject.GameMainForm.imgsLarge.Images[1];
            picCard1.Image = GlobalObject.GameMainForm.imgsCard.Images[0];
            picCard2.Image = GlobalObject.GameMainForm.imgsCard.Images[1];
            picCard3.Image = GlobalObject.GameMainForm.imgsCard.Images[2];
            picCard4.Image = GlobalObject.GameMainForm.imgsCard.Images[3];

            picECard1.Image = GlobalObject.GameMainForm.imgsCard.Images[0];
            picECard2.Image = GlobalObject.GameMainForm.imgsCard.Images[1];
            picECard3.Image = GlobalObject.GameMainForm.imgsCard.Images[2];
            picECard4.Image = GlobalObject.GameMainForm.imgsCard.Images[3];
        }
        private void tipsChange()
        {
            tipsIndex++;
            if (tipsIndex > 1)
                tipsIndex = 0;
            switch (tipsIndex)
            {
                case 0:
                    txtDockbot.Text = "点击“确认”之后，互相确认对方的第四张牌。";
                    break;
                case 1:
                    txtDockbot.Text = "点击“确认”之前，对方不会知道你选择了什么牌。";
                    break;
            }
        }

        private void picCard4_Click(object sender, EventArgs e)
        {
            switch (btnIndex)
            {
                case 0:
                    if (txtTips1.Visible == true)
                    {
                        button1.Enabled = true;
                        tipsChange();
                        txtTips1.Visible = false;
                        txtTips2.Visible = false;
                    }
                    theFourth++;
                    if (theFourth > 2)
                        theFourth = 0;
                    picCard4.Image = GlobalObject.GameMainForm.imgsCard.Images[theFourth];
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                    cardFight = 3;
                    flatPic();
                    picCard4.BorderStyle = BorderStyle.Fixed3D;
                    button1.Enabled = true;
                    break;
            }
        }

        private void txtDockbot_Click(object sender, EventArgs e)
        {
            tipsChange();
        }

        private void setCards()
        {
            Random ran = new Random();
            int[] ACardhave = {0,1,2,3};
            ACardhave[3] = ran.Next(0, 2);

            for (int i = 0; i <= 3; i++)
            {
                ACard[i] = ran.Next(0, 2);
            redo:
                for (int j = 0; j <= 3; j++)
                {
                    if (ACard[i] == ACardhave[j])
                    {
                        ACardhave[j] = -1;
                        goto done;
                    }
                }
                ACard[i]++;
                if (ACard[i] > 2) ACard[i] = 0;
                goto redo;
            done:
                continue;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (btnIndex)
            {
                case 0:
                    Random ran = new Random();
                    ACardset[3] = ran.Next(0, 2);
                    picECard4.Image = GlobalObject.GameMainForm.imgsCard.Images[ACardset[3]];
                    picCard4.Cursor = Cursors.Default;
                    button1.Text = "开始";                    
                    btnIndex++;
                    break;
                case 1:
                    setCards();
                    picECard1.Image = GlobalObject.GameMainForm.imgsCard.Images[3];
                    picECard2.Image = GlobalObject.GameMainForm.imgsCard.Images[3];
                    picECard3.Image = GlobalObject.GameMainForm.imgsCard.Images[3];
                    picECard4.Image = GlobalObject.GameMainForm.imgsCard.Images[3];

                    picCard1.Cursor = Cursors.Hand;
                    picCard2.Cursor = Cursors.Hand;
                    picCard3.Cursor = Cursors.Hand;
                    picCard4.Cursor = Cursors.Hand;

                    button1.Text = "确认";
                    btnIndex++;
                    button1.Enabled = false;
                    break;
                case 2:
                    fight();
                    picECard1.Image = GlobalObject.GameMainForm.imgsCard.Images[ACard[0]];
                    btnIndex++;
                    break;
                case 3:
                    fight();
                    picECard2.Image = GlobalObject.GameMainForm.imgsCard.Images[ACard[1]];
                    btnIndex++;
                    break;
                case 4:
                    fight();
                    picECard3.Image = GlobalObject.GameMainForm.imgsCard.Images[ACard[2]];
                    btnIndex++;
                    break;
                case 5:
                    fight();
                    picECard4.Image = GlobalObject.GameMainForm.imgsCard.Images[ACard[3]];
                    if (mPoint > APoint)
                        button1.Text = "胜利了！";
                    else if (mPoint == APoint)
                        button1.Text = "平局！";
                    else 
                        button1.Text = "输了。";
                    btnIndex++;
                    button1.Enabled = true;;
                    break;
            }
        }
        private void fight()
        {
            switch (cardFight)
            {
                case 0:
                    picCard1.Visible = false;
                    break;
                case 1:
                    picCard2.Visible = false;
                    break;
                case 2:
                    picCard3.Visible = false;
                    break;
                case 3:
                    picCard4.Visible = false;
                    cardFight = theFourth;
                    break;
            }
            int ac = ACard[btnIndex-2];
            if (cardFight == ac)
                txtDockbot.Text = "平手";
            else 
            {
                switch (cardFight)
                { 
                    case 0:
                        if (ac == 1)
                        {
                            txtDockbot.Text = "胜手";
                            mPoint++;
                            txtmPoint.Text = mPoint.ToString();
                        }
                        else if (ac == 2)
                        {
                            txtDockbot.Text = "败手";
                            APoint++;
                            txtAPoint.Text = APoint.ToString();
                        }
                        break;
                    case 1:
                        if (ac == 2)
                        {
                            txtDockbot.Text = "胜手";
                            mPoint++;
                            txtmPoint.Text = mPoint.ToString();
                        }
                        else if (ac == 0)
                        {
                            txtDockbot.Text = "败手";
                            APoint++;
                            txtAPoint.Text = APoint.ToString();
                        }
                        break;
                    case 2:
                        if (ac == 0)
                        {
                            txtDockbot.Text = "胜手";
                            mPoint++;
                            txtmPoint.Text = mPoint.ToString();
                        }
                        else if (ac == 2)
                        {
                            txtDockbot.Text = "败手";
                            APoint++;
                            txtAPoint.Text = APoint.ToString();
                        }
                        break;
                }

            }
            button1.Enabled = false;
        }
        private void flatPic()
        {
            picCard1.BorderStyle = BorderStyle.None;
            picCard2.BorderStyle = BorderStyle.None;
            picCard3.BorderStyle = BorderStyle.None;
            picCard4.BorderStyle = BorderStyle.None;
        }
        private void picCard3_Click(object sender, EventArgs e)
        {
            switch (btnIndex)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                    cardFight = 2;
                    flatPic();
                    picCard3.BorderStyle = BorderStyle.Fixed3D;
                    button1.Enabled = true;
                    break;
            }
        }

        private void picCard2_Click(object sender, EventArgs e)
        {
            switch (btnIndex)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                    cardFight = 1;
                    flatPic();
                    picCard2.BorderStyle = BorderStyle.Fixed3D;
                    button1.Enabled = true;
                    break;
            }
        }

        private void picCard1_Click(object sender, EventArgs e)
        {
            switch (btnIndex)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                    cardFight = 0;
                    flatPic();
                    picCard1.BorderStyle = BorderStyle.Fixed3D;
                    button1.Enabled = true;
                    break;
            }
        }
    }
}
