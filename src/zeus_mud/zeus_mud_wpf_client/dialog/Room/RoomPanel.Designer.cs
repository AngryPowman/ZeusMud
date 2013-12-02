namespace zeus_mud_wpf_client.dialog
{
    partial class RoomPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonChangeRoomInfo = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRoomName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxRoomMessage = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonLeaveRoom = new System.Windows.Forms.Button();
            this.buttonKickPlayer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(598, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 564);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "玩家列表";
            this.columnHeader1.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonChangeRoomInfo);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxRoomName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "房间信息";
            // 
            // buttonChangeRoomInfo
            // 
            this.buttonChangeRoomInfo.Location = new System.Drawing.Point(252, 23);
            this.buttonChangeRoomInfo.Name = "buttonChangeRoomInfo";
            this.buttonChangeRoomInfo.Size = new System.Drawing.Size(84, 53);
            this.buttonChangeRoomInfo.TabIndex = 4;
            this.buttonChangeRoomInfo.Text = "修改";
            this.buttonChangeRoomInfo.UseVisualStyleBackColor = true;
            this.buttonChangeRoomInfo.Click += new System.EventHandler(this.buttonChangeRoomInfo_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(92, 56);
            this.textBoxPassword.MaxLength = 6;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(130, 21);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "房间密码：";
            // 
            // textBoxRoomName
            // 
            this.textBoxRoomName.Location = new System.Drawing.Point(92, 20);
            this.textBoxRoomName.MaxLength = 24;
            this.textBoxRoomName.Name = "textBoxRoomName";
            this.textBoxRoomName.Size = new System.Drawing.Size(130, 21);
            this.textBoxRoomName.TabIndex = 1;
            this.textBoxRoomName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRoomName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "房间名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxRoomMessage);
            this.groupBox2.Location = new System.Drawing.Point(3, 423);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 141);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "房间消息：";
            // 
            // textBoxRoomMessage
            // 
            this.textBoxRoomMessage.Location = new System.Drawing.Point(6, 20);
            this.textBoxRoomMessage.Multiline = true;
            this.textBoxRoomMessage.Name = "textBoxRoomMessage";
            this.textBoxRoomMessage.Size = new System.Drawing.Size(577, 115);
            this.textBoxRoomMessage.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonLeaveRoom);
            this.groupBox3.Controls.Add(this.buttonKickPlayer);
            this.groupBox3.Location = new System.Drawing.Point(362, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 87);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "房间操作";
            // 
            // buttonLeaveRoom
            // 
            this.buttonLeaveRoom.Location = new System.Drawing.Point(7, 54);
            this.buttonLeaveRoom.Name = "buttonLeaveRoom";
            this.buttonLeaveRoom.Size = new System.Drawing.Size(75, 23);
            this.buttonLeaveRoom.TabIndex = 1;
            this.buttonLeaveRoom.Text = "退出房间";
            this.buttonLeaveRoom.UseVisualStyleBackColor = true;
            this.buttonLeaveRoom.Click += new System.EventHandler(this.buttonLeaveRoom_Click);
            // 
            // buttonKickPlayer
            // 
            this.buttonKickPlayer.Location = new System.Drawing.Point(7, 21);
            this.buttonKickPlayer.Name = "buttonKickPlayer";
            this.buttonKickPlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonKickPlayer.TabIndex = 0;
            this.buttonKickPlayer.Text = "踢出玩家";
            this.buttonKickPlayer.UseVisualStyleBackColor = true;
            this.buttonKickPlayer.Click += new System.EventHandler(this.buttonKickPlayer_Click);
            // 
            // RoomPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.Name = "RoomPanel";
            this.Size = new System.Drawing.Size(722, 567);
            this.Load += new System.EventHandler(this.RoomPanel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonChangeRoomInfo;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRoomName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxRoomMessage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonLeaveRoom;
        private System.Windows.Forms.Button buttonKickPlayer;
    }
}
