namespace zeus_mud
{
    partial class frmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.chkSavePwd = new System.Windows.Forms.CheckBox();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.gifBox = new TimerPictureLib.TimerPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("宋体", 11F);
            this.txtPassword.Location = new System.Drawing.Point(114, 140);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(179, 24);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("宋体", 11F);
            this.txtUsername.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtUsername.Location = new System.Drawing.Point(114, 110);
            this.txtUsername.MaxLength = 32;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(179, 24);
            this.txtUsername.TabIndex = 1;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Location = new System.Drawing.Point(304, 110);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(63, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // chkSavePwd
            // 
            this.chkSavePwd.AutoSize = true;
            this.chkSavePwd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkSavePwd.Location = new System.Drawing.Point(112, 171);
            this.chkSavePwd.Name = "chkSavePwd";
            this.chkSavePwd.Size = new System.Drawing.Size(72, 16);
            this.chkSavePwd.TabIndex = 3;
            this.chkSavePwd.Text = "记住密码";
            this.chkSavePwd.UseVisualStyleBackColor = false;
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkAutoLogin.Location = new System.Drawing.Point(190, 171);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.chkAutoLogin.TabIndex = 4;
            this.chkAutoLogin.Text = "自动登录";
            this.chkAutoLogin.UseVisualStyleBackColor = false;
            this.chkAutoLogin.CheckedChanged += new System.EventHandler(this.chkAutoLogin_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(304, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "找回密码";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.ErrorImage = null;
            this.picAvatar.InitialImage = null;
            this.picAvatar.Location = new System.Drawing.Point(29, 110);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(72, 72);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAvatar.TabIndex = 17;
            this.picAvatar.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.trackBar1.Location = new System.Drawing.Point(275, 170);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 42);
            this.trackBar1.TabIndex = 20;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.shapeContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 60);
            this.panel1.TabIndex = 21;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogin.Location = new System.Drawing.Point(116, 9);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(155, 39);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登     录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(387, 60);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.rectangleShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.rectangleShape1.FillColor = System.Drawing.Color.Silver;
            this.rectangleShape1.FillGradientColor = System.Drawing.Color.WhiteSmoke;
            this.rectangleShape1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Vertical;
            this.rectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape1.Location = new System.Drawing.Point(-4, 1);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(389, 60);
            // 
            // gifBox
            // 
            this.gifBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gifBox.fpsGif = 100;
            this.gifBox.Image = ((System.Drawing.Image)(resources.GetObject("gifBox.Image")));
            this.gifBox.Location = new System.Drawing.Point(0, 0);
            this.gifBox.Name = "gifBox";
            this.gifBox.Size = new System.Drawing.Size(387, 209);
            this.gifBox.TabIndex = 22;
            this.gifBox.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 266);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkAutoLogin);
            this.Controls.Add(this.chkSavePwd);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.gifBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中国好游戏MUD-玩家登录";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gifBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox chkSavePwd;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnLogin;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private TimerPictureLib.TimerPictureBox gifBox;

    }
}

