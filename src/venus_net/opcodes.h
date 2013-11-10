#ifndef __OPCODES_H__
#define __OPCODES_H__

namespace Opcodes
{
    //�����˼�Ȩ
    const int C2SLoginReq               = 10000;
    const int S2CLoginRsp               = 10001;
    const int C2SRegisterReq            = 10002;            //ע������
    const int S2CRegisterRsp            = 10003;            //ע���Ӧ
    const int C2SGetPlayerProfileReq    = 15000;
    const int S2CGetPlayerProfileRsp    = 15001;
    const int C2SChatMessageReq         = 20000;
    const int S2CChatMessageNotify      = 20001;
    const int S2CError                  = 99990;            //ע���Ӧ
    const int S2CErrorEx                = 99991;            //ע���Ӧ
    const int C2SRoomCreateReq          = 21001;            
    const int S2CRoomCreateRsp          = 21002;
}

#endif