#include <common.h>
#include <network_common.h>
#include <protobuf.h>
#include <packet.h>
#include "game_session.h"
#include "room_manager.h"

void GameSession::room_create_handler(const NetworkMessage& message)
{
    Protocol::C2SGameCreateReq request;
    PARSE_NETWORK_MESSAGE(message, request);

    debug_log("[Room Create] -> (RoomName='%s', Password='%s')", request.game_name().c_str(), request.password().c_str());

    Protocol::S2CGameCreateRsp response;
    //验证房间名长度
    if ( request.game_name().length() < 24)
    {   
        if ( request.game_name().length() > 0 )
        {           
            //验证密码长度
            if ( request.password().length() <= 6 )
            {
                uint32 id = RoomManager::getInstance().addRoom(request.game_name(), request.password());
                response.set_room_id(id);
                if (id != 0)
                {
                    response.set_game_create_result(true);
                }
                else
                {
                    response.set_game_create_result(false);
                }
            }
            else
            {
                warning_log("Room password has reached the limits length.");
                response.set_game_create_result(false);
            }
        }
        else
        {
            warning_log("Room name can't be empty");
            response.set_game_create_result(false);
        }
        
    }
    else
    {
        warning_log("Room name has reached the limits length.");
        response.set_game_create_result(false);
    }

}