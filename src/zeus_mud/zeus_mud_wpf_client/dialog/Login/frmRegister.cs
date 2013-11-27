﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wpf;
using Wpf.network;
using Wpf.ZuesMud;
using zeus_mud;
using zeus_mud_wpf_client.network;

namespace zeus_mud_wpf_client.dialog
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();

            //注册消息
            OpcodesProxy.registerHandler<frmRegister>(Opcodes.S2CRegisterRsp, this.userRegisterCallback, this);

            rdMale.Checked = true;
            rdFemale_CheckedChanged(rdMale, null);
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            pnlBWH.Visible = rdFemale.Checked;
            groupBox1.Height = (pnlBWH.Visible == true ? pnlBWH.Top + pnlBWH.Height : pnlBWH.Top) + 2;
            btnOk.Top = groupBox1.Top + groupBox1.Height + 4;
            btnCancel.Top = groupBox1.Top + groupBox1.Height + 4;
            this.Height = btnOk.Top + btnOk.Height + 46;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();
            txtNickname.Text = txtNickname.Text.Trim();
            
            //========================
            // ● 验证结果 缓存
            //========================
            ValidateResult valResult;
          
            //============================================
            // ● 分别验证邮箱密码昵称
            //============================================
            valResult = GameUtil.checkEmail(txtEmail.Text);
            if (valResult.Result == false)
            {
                MessageBox.Show(this, valResult .FailedReason, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            valResult = GameUtil.checkPassword(txtPassword.Text);
            if (valResult.Result == false)
            {
                MessageBox.Show(this, valResult .FailedReason, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            valResult = GameUtil.checkNickname(txtNickname.Text);
            if (valResult.Result == false)
            {
                MessageBox.Show(this, valResult .FailedReason, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //===================================
            // ● 发送注册请求
            //===================================
            if (NetworkEvent.isConnected() == false)
            {
                if (NetworkEvent.connectToServer(GlobalObject.DefaultServer, GlobalObject.DefaultPort) == false)
                {
                    MessageBox.Show(this, "连接注册服务器失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            userRegisterRequest(txtEmail.Text, txtPassword.Text, txtNickname.Text, rdFemale.Checked == true ? 1 : 2);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabel1.Text); 
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //========================================用户注册========================================
        void userRegisterRequest(string email, string password_plainText, string nickname, Int32 gender)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] passwordHash = md5.ComputeHash(Encoding.Default.GetBytes(password_plainText));

            Protocol.C2SRegisterReq request = new Protocol.C2SRegisterReq();
            request.email = email;
            request.password = GameUtil.toMD5(password_plainText);
            request.nickname = Encoding.UTF8.GetBytes(nickname);
            request.gender = gender;

            NetworkEvent.sendPacket<Protocol.C2SRegisterReq>(request);
        }

        public void userRegisterCallback(object sender, NetworkMessageEventArgs e)
        {
            Protocol.S2CRegisterRsp response = NetworkEvent.parseMessage<Protocol.S2CRegisterRsp>(e.message);
            if (response.register_result == false)
            {
                MessageBox.Show(this, Encoding.Default.GetString(response.failed_reason), "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(this, "注册成功，现在你可以体验精彩的游戏了。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalObject.LoginForm.txtUsername.Text = txtEmail.Text;
                GlobalObject.LoginForm.txtPassword.Text = txtPassword.Text;
                this.Close();
            }
        }

        //=======================================================================================
    }
}
