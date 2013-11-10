#include <common.h>
#include <network_common.h>
#include <protobuf.h>
#include <packet.h>
#include "game_session.h"
#include "room_manager.h"

void GameSession::room_create_handler(const NetworkMessage& message)
{
    Protocol::C2SRoomCreateReq request;
    PARSE_NETWORK_MESSAGE(message, request);

    debug_log("[Room Create] -> (RoomName='%s', Password='%s')", request.room_name().c_str(), request.password().c_str());

    Protocol::S2CRoomCreateRsp response;
    //��֤����������
    if ( request.room_name().length() < 24)
    {   
        if ( request.room_name().length() > 0 )
        {           
            //��֤���볤��
            if ( request.password().length() <= 6 )
            {
                uint32 id = RoomManager::getInstance().addRoom(request.room_name(), request.password());
                response.set_room_id(id);
                if (id != 0)
                {
                    response.set_room_create_result(true);
                }
                else
                {
                    response.set_room_create_result(false);
                    response.set_failed_reason("��������������");
                }
            }
            else
            {
                warning_log("Room password has reached the limits length.");
                response.set_room_create_result(false);
                response.set_failed_reason("�������������");
            }
        }
        else
        {
            warning_log("Room name can't be empty");
            response.set_room_create_result(false);
            response.set_failed_reason("����������Ϊ�ա�");
        }
        
    }
    else
    {
        warning_log("Room name has reached the limits length.");
        response.set_room_create_result(false);
        response.set_failed_reason("������������");
    }
    send_message<Protocol::S2CRoomCreateRsp>(Opcodes::S2CRoomCreateRsp, response);
}