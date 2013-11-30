#include "room_manager.h"
#include <protobuf.h>
#include "game_session_manager.h"

RoomManager::RoomManager()
{

}
bool RoomManager::init()
{
    return true;
}

void RoomManager::destroy()
{
    for (auto i = _rooms.begin(); i != _rooms.end(); ++i)
    {
        _roomPool.release(i->second);
    }
    _rooms.clear();
}

uint32 RoomManager::addRoom(const std::string& roomName, const std::string& password,  uint64 ownerGuid)
{
    if (_rooms.size() >= MAX_ROOM)
    {
        warning_log("Room count has reached the limit.");
        return ADD_ROOM_FAILED;
    }

    uint32 roomId = 0;
    if (_freeIds.empty())
    {
        roomId = _rooms.size() + 1;
    }
    else
    {
        roomId = _freeIds.back();
        _freeIds.pop_back();
    }
    _rooms[roomId] = _roomPool.acquire(roomId, roomName, password, ownerGuid);
    return roomId;
}

void RoomManager::removeRoom(uint32 id)
{
    auto it = _rooms.find(id);
    if (it != _rooms.end())
    {
        _roomPool.release(it->second);
        _rooms.erase(it);
        _freeIds.push_back(id);
    }
    else
    {
        warning_log("Can't find the deleting room.");
    }
}

void RoomManager::getRooms(adap_map<uint32, Room*>& rooms)
{
    rooms = _rooms;
}

RoomManager::~RoomManager()
{

}

Room* RoomManager::getRoom( uint32 id )
{
    if (_rooms.find(id) != _rooms.end())
    {
        return _rooms[id];
    }
    return NULL;
}

bool RoomManager::enterRoom( uint32 room_id, uint64 player_id )
{
    auto it = _rooms.find(room_id);
    if (it == _rooms.end())
    {
        error_log("EnterRoomError: Can't find the specified room.");
        return false;
    }
    if (it->second->getPlayersCount() >= MAX_ROOM_PLAYERS)
    {
        error_log("EnterRoomError: The specified room has been full.");
        return false;
    }
    it->second->addMember(player_id);
    return true;
}

bool RoomManager::leaveRoom( uint32 room_id, uint64 player_id )
{
    auto it = _rooms.find(room_id);
    if (it == _rooms.end())
    {
        error_log("LeaveRoomError: Can't find the specified room.");
        return false;
    }
    it->second->removeMember(player_id);
    return true;
}

void RoomManager::broadcast_room_add(uint32 id, const std::string& roomName, bool isPublic)
{
    Protocol::S2CNewRoomAddNotify response;
    response.set_room_id(id);
    response.set_room_name(roomName);
    response.set_public_(isPublic);
    GameSessionManager::getInstance().broadcast<Protocol::S2CNewRoomAddNotify>(Opcodes::S2CNewRoomAddNotify, response);
}

void RoomManager::broadcast_room_info_change(uint32 room_id, const std::string& roomName, uint32 playersCount, bool isPublic)
{
    Protocol::S2CSRoomInfoChangeNotify response;
    response.set_room_id(room_id);
    response.set_room_name(roomName);
    response.set_players_count(playersCount);
    response.set_public_(isPublic);
    GameSessionManager::getInstance().broadcast<Protocol::S2CSRoomInfoChangeNotify>(Opcodes::S2CSRoomInfoChangeNotify, response);
}