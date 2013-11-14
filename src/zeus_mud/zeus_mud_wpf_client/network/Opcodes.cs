using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wpf.network
{
    public enum Opcodes
    {
        C2SLoginReq     = 10000,            //登录请求
        S2CLoginRsp     = 10001,            //登录回应
        C2SRegisterReq  = 10002,            //注册请求
        S2CRegisterRsp  = 10003,            //注册回应
        C2SGetPlayerProfileReq = 15000,
        S2CGetPlayerProfileRsp = 15001,
        C2SChatMessageReq = 20000,
        S2CChatMessageNotify = 20001,
        C2SRoomCreateReq = 21001,
        S2CRoomCreateRsp = 21002,
        C2SGetRoomListReq = 21003,
        S2CGetRoomListRsp = 21004,
        C2SRoomCancleReq = 21005,
        S2CRoomCancleRsp = 21006,
        C2SSRoomInfoChangeReq = 21007,
        S2CSRoomInfoChangeRsp = 21008,
        C2SEnterRoomReq = 21009,
        S2CPlayerEnterRoomRsp = 21010,
        C2SLeaveRoomReq = 21011,
        S2CPlayerLeaveRoomRsp = 21012,
        C2SKickPlayerReq = 21013,
        S2CRoomKickedRsp = 21014,
        S2CNewRoomAddRsp = 21015
    }
}
