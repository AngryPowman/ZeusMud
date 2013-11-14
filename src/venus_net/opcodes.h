#ifndef __OPCODES_H__
#define __OPCODES_H__

namespace Opcodes
{
    //机器人鉴权
    const int C2SLoginReq               = 10000;
    const int S2CLoginRsp               = 10001;
    const int C2SRegisterReq            = 10002;            //注册请求
    const int S2CRegisterRsp            = 10003;            //注册回应
    const int C2SGetPlayerProfileReq    = 15000;
    const int S2CGetPlayerProfileRsp    = 15001;
    const int C2SChatMessageReq         = 20000;
    const int S2CChatMessageNotify      = 20001;
    const int S2CError                  = 99990;            //注册回应
    const int S2CErrorEx                = 99991;            //注册回应
    const int C2SRoomCreateReq          = 21001;            
    const int S2CRoomCreateRsp          = 21002;
    const int C2SGetRoomListReq         = 21003;
    const int S2CGetRoomListRsp         = 21004;
    const int C2SRoomCancleReq          = 21005;
    const int S2CRoomCancleRsp          = 21006;
    const int C2SSRoomInfoChangeReq     = 21007;
    const int S2CSRoomInfoChangeRsp     = 21008;
    const int C2SEnterRoomReq           = 21009;
    const int S2CEnterRoomRsp           = 21010;
    const int C2SLeaveRoomReq           = 21011;
    const int S2CPlayerLeaveRoomNotify  = 21012;
    const int C2SKickPlayerReq          = 21013;
    const int S2CRoomKickedRsp          = 21014;
    const int S2CNewRoomAddRsp          = 21015;
}

#endif