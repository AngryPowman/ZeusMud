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
using System.IO;
using zeus_mud_wpf_client.network;
using Wpf.ZuesMud;


namespace zeus_mud_wpf_client.dialog
{
    public partial class RoomListPanel : UserControl
    {
        public const uint MAX_MEMBER = 4;
        private String m_password;

        public String Password
        {
            get { return m_password; }
            set { m_password = value; }
        }

        public RoomListPanel()
        {
            InitializeComponent();
            //注册请求消息回调
            OpcodesProxy.registerHandler<RoomListPanel>(Opcodes.S2CGetRoomListRsp, this.getRoomListCallBack, this);
            OpcodesProxy.registerHandler<RoomListPanel>(Opcodes.S2CNewRoomAddNotify, this.newRoomAddCallBack, this);
            OpcodesProxy.registerHandler<RoomListPanel>(Opcodes.S2CEnterRoomRsp, this.enterRoomRsp, this);
        }

        private void RoomListPanel_Load(object sender, EventArgs e)
        {
            Protocol.C2SGetRoomListReq request = new Protocol.C2SGetRoomListReq();
            NetworkEvent.sendPacket<Protocol.C2SGetRoomListReq>(request);
            GlobalObject.RoomListPanelForm = this;
        }

        public void getRoomRequest()
        {

        }

        public void enterRoomRsp(object sender, NetworkMessageEventArgs e)
        {
            Protocol.S2CEnterRoomRsp response = NetworkEvent.parseMessage<Protocol.S2CEnterRoomRsp>(e.message);
            if (response.result == false)
            {
                MessageBox.Show("房间已满。");
            }

        }

        public void newRoomAddCallBack(object sender, NetworkMessageEventArgs e)
        {
            Protocol.S2CNewRoomAddNotify response = NetworkEvent.parseMessage<Protocol.S2CNewRoomAddNotify>(e.message);
            ListViewItem lvi = listView1.Items.Insert((int)response.room_id - 1, response.room_id.ToString());
            lvi.SubItems.Add(response.room_name);
            lvi.SubItems.Add("1");
            if (response.@public)
            {
                lvi.SubItems.Add("公开");
            } 
            else
            {
                lvi.SubItems.Add("不公开");
            }
            
        }

        public void getRoomListCallBack(object sender, NetworkMessageEventArgs e)
        {
            Protocol.S2CGetRoomListRsp response = NetworkEvent.parseMessage<Protocol.S2CGetRoomListRsp>(e.message);
            List<Protocol.S2CGetRoomListRsp.RoomInfo> roomList = response.room_list;
            foreach (Protocol.S2CGetRoomListRsp.RoomInfo room in roomList)
            {
                ListViewItem lvi = listView1.Items.Add(new ListViewItem(room.room_id.ToString()));
                lvi.SubItems.Add(room.room_name);
                lvi.SubItems.Add(room.player_count.ToString());
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }

            // 双击进入房间
            m_password = "";
            ListViewItem selItem = listView1.SelectedItems[0];

            //房间是否已满
            if (MAX_MEMBER > uint.Parse(selItem.SubItems[2].Text))
            {
                MessageBox.Show("房间已满。");
                return;
            }

            //不公开则显示输入
            if (selItem.SubItems[3].Text == "不公开")
            {
                frmEnterPassword passwordDlg = new frmEnterPassword();
                passwordDlg.ShowDialog();
                //密码为空，取消进入房间。
                if (m_password == "")
                {
                    return;
                }
            }
            
            //发送请求
            Protocol.C2SEnterRoomReq request = new Protocol.C2SEnterRoomReq();
            request.room_id = uint.Parse(selItem.Text);
            request.password = m_password;
            NetworkEvent.sendPacket<Protocol.C2SEnterRoomReq>(request);
        }
    }
}
