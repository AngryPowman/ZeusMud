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


namespace zeus_mud_wpf_client.dialog
{
    public partial class RoomListPanel : UserControl
    {
        public RoomListPanel()
        {
            InitializeComponent();
            //注册请求消息回调
            OpcodesProxy.registerHandler<RoomListPanel>(Opcodes.S2CGetRoomListRsp, this.getRoomListCallBack, this);
        }

        private void RoomListPanel_Load(object sender, EventArgs e)
        {
            Protocol.C2SGetRoomListReq request = new Protocol.C2SGetRoomListReq();
            NetworkEvent.sendPacket<Protocol.C2SGetRoomListReq>(request);
        }
        public void getRoomRequest()
        {

        }
        public void getRoomListCallBack(object sender, NetworkMessageEventArgs e)
        {
            Protocol.S2CGetRoomListRsp response = NetworkEvent.parseMessage<Protocol.S2CGetRoomListRsp>(e.message);
            List<Protocol.S2CGetRoomListRsp.RoomInfo> roomList = response.room_list;
            foreach (Protocol.S2CGetRoomListRsp.RoomInfo room in roomList)
            {
                ListViewItem lvi = listView1.Items.Add(new ListViewItem(room.id.ToString()));
                lvi.SubItems.Add(room.room_name);
                lvi.SubItems.Add(room.player_count.ToString());
            }
        }
    }
}
