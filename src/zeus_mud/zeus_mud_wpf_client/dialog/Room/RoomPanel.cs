using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wpf.network;

namespace zeus_mud_wpf_client.dialog
{
    public partial class RoomPanel : UserControl
    {
        public RoomPanel()
        {
            InitializeComponent();
        }

        uint _roomId = 0;
        public uint RoomID
        {
            get
            {
                return _roomId;
            }
            set
            {
                _roomId = value;
            }
        }


        private void textBoxRoomName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
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

        private void RoomPanel_Load(object sender, EventArgs e)
        {

        }

        private void buttonChangeRoomInfo_Click(object sender, EventArgs e)
        {
            if (textBoxRoomName.TextLength == 0)
            {
                MessageBox.Show("房间名不可为空。");
                return;
            }

            roomInfoChangeRequest(textBoxRoomName.Text, textBoxPassword.Text);
        }

        void roomInfoChangeRequest(String roomName, String password)
        {
            Protocol.C2SSRoomInfoChangeReq request = new Protocol.C2SSRoomInfoChangeReq();
            request.password = password;
            request.room_name = roomName;
            request.room_id = _roomId;

            NetworkEven.sendPacket<Protocol.C2SSRoomInfoChangeReq>(request);
        }

        private void buttonKickPlayer_Click(object sender, EventArgs e)
        {

        }

        private void buttonLeaveRoom_Click(object sender, EventArgs e)
        {

        }
    }
}
