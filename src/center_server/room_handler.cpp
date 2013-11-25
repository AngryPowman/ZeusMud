#include <common.h>
#include <network_common.h>
#include <protobuf.h>
#include <packet.h>
#include "game_session_manager.h"
#include "game_session.h"
#include "room_manager.h"
#include "player.h"

const static uint32 MAX_ROOM_NAME_SIZE = 24;
const static uint32 MAX_ROOM_PASSWORD_SIZE = 6;

void GameSession::room_create_handler(const NetworkMessage& message)
{
    Protocol::C2SRoomCreateReq request;
    PARSE_NETWORK_MESSAGE(message, request);

    debug_log("[Room Create] -> (RoomName='%s', Password='%s')", request.room_name().c_str(), request.password().c_str());

    Protocol::S2CRoomCreateRsp response;
    //验证房间名长度
    if ( request.room_name().length() < MAX_ROOM_NAME_SIZE)
    {   
        if ( request.room_name().length() > 0 )
        {           
            //验证密码长度
            if ( request.password().length() <= MAX_ROOM_PASSWORD_SIZE )
            {
                uint32 id = RoomManager::getInstance().addRoom(request.room_name(), request.password(), _player->guid());
                response.set_room_id(id);
                if (id != 0)
                {
                    response.set_room_create_result(true);
                    broadcast_room_add(id, request.room_name(), request.password().empty());
                }
                else
                {
                    response.set_room_create_result(false);
                    response.set_failed_reason("房间数量已满。");
                }
            }
            else
            {
                warning_log("Room password has reached the limits length.");
                response.set_room_create_result(false);
                response.set_failed_reason("房间密码过长。");
            }
        }
        else
        {
            warning_log("Room name can't be empty");
            response.set_room_create_result(false);
            response.set_failed_reason("房间名不可为空。");
        }
        
    }
    else
    {
        warning_log("Room name has reached the limits length.");
        response.set_room_create_result(false);
        response.set_failed_reason("房间名过长。");
    }
    send_message<Protocol::S2CRoomCreateRsp>(Opcodes::S2CRoomCreateRsp, response);
}

void GameSession::broadcast_room_add(uint32 id, const std::string& roomName, bool isPublic)
{
    Protocol::S2CNewRoomAddNotify response;
    response.set_room_id(id);
    response.set_room_name(roomName);
    response.set_public_(isPublic);
    GameSessionManager::getInstance().broadcast<Protocol::S2CNewRoomAddNotify>(Opcodes::S2CNewRoomAddNotify, response);
}

void GameSession::get_room_list_handler(const NetworkMessage& message)
{
    Protocol::S2CGetRoomListRsp response;
    adap_map<uint32, Room*> rooms;
    RoomManager::getInstance().getRooms(rooms);

    for (auto it = rooms.begin(); it != rooms.end(); ++it)
    {
        Protocol::S2CGetRoomListRsp::RoomInfo* roomInfo = response.add_room_list();
        roomInfo->set_room_id(it->second->getId());
        roomInfo->set_room_name(it->second->getRoomName());
        roomInfo->set_player_count(it->second->getPlayersCount());
    }
    debug_log("Send room list to client.");
    send_message<Protocol::S2CGetRoomListRsp>(Opcodes::S2CGetRoomListRsp ,response);
}

void GameSession::enter_room_handler(const NetworkMessage& message)
{
    Protocol::C2SEnterRoomReq request;
    PARSE_NETWORK_MESSAGE(message, request);
    debug_log("[Enter Room]: room_id = '%d'", request.room_id());

    Protocol::S2CEnterRoomRsp response;

    Room* room = RoomManager::getInstance().getRoom(request.room_id());
    if(room != NULL)
    {
        room->addMember(_player->guid());
        response.set_result(true);
        broadcast_room_info_change(room->getId(), room->getRoomName(), room->getPlayersCount(), room->getPassword().empty());
    }
    else
    {
        warning_log("Can't find room");
        response.set_result(false);
    }
    send_message<Protocol::S2CEnterRoomRsp>(Opcodes::S2CEnterRoomRsp, response);
}

void GameSession::broadcast_room_info_change(uint32 room_id, const std::string& roomName, uint32 playersCount, bool isPublic)
{
    Protocol::S2CSRoomInfoChangeNotify response;
    response.set_room_id(room_id);
    response.set_room_name(roomName);
    response.set_players_count(playersCount);
    response.set_public_(isPublic);
    GameSessionManager::getInstance().broadcast<Protocol::S2CSRoomInfoChangeNotify>(Opcodes::S2CSRoomInfoChangeNotify, response);
}

void GameSession::room_info_change_handler(const NetworkMessage& message)
{
    Protocol::C2SSRoomInfoChangeReq request;
    PARSE_NETWORK_MESSAGE(message, request);
    debug_log("[Change RoomInfo]: room_id = '%d' room_name = '%s' room_password = '%s'", request.room_id(), request.room_name(), request.password());
    Room* room = RoomManager::getInstance().getRoom(request.room_id());
    if (room == NULL)
    {
        error_log("RoomInfoChange: Can't find the specified room.");
        return;
    }
    if (request.password().empty() && request.room_name().empty())
    {
        error_log("RoomInfoChange: Password and RoomName can't be empty at the same time.");
        return;
    }
    if (request.password().compare(room->getPassword()) == 0
        && request.room_name().compare(room->getRoomName()) == 0)
    {
        error_log("RoomInfoChange: Password and RoomName aren't modified.");
        return;
    }
    Protocol::S2CSRoomInfoChangeNotify response;
    if (!request.password().empty() && request.password().size() < MAX_ROOM_PASSWORD_SIZE)
    {
        room->changePassword(request.password());
    }
    
    // 只有修改了房间名称才需要通知
    response.set_room_id(request.room_id());
    if (!request.room_name().empty() && request.room_name().size() < MAX_ROOM_NAME_SIZE)
    {
        room->modifyRoomName(request.room_name());
        response.set_room_name(request.room_name());
        broadcast_room_info_change(request.room_id(), request.room_name(), room->getPlayersCount(), room->getPassword().empty());
    }
}