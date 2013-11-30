#ifndef ROOM_MANAGER_H_
#define ROOM_MANAGER_H_

#include <common.h>
#include <manager.h>
#include "room.h"
#include "room_pool.h"

class RoomManager
    : public Venus::Singleton<RoomManager>
{
    static const int MAX_ROOM = 1000;
    static const int MAX_ROOM_PLAYERS = 4;
    static const uint32 ADD_ROOM_FAILED = 0;

public:
    RoomManager();
    ~RoomManager();
public:
    bool init();
    void destroy();

    //////////////////////////////////////////////////////////////////////////
    // ����:���һ��room ������Ȼ��˳������ѡ��δʹ��id
    // ����:ʧ�� return ADD_ROOM_FAILED; �ɹ� return id;
    //////////////////////////////////////////////////////////////////////////
    uint32 addRoom(const std::string& roomName, const std::string& password, uint64 ownerGuid);
    void removeRoom(uint32 id);
    void getRooms(adap_map<uint32, Room*>& rooms);
    Room* getRoom(uint32 id);
    bool enterRoom(uint32 room_id, uint64 player_id);
    bool leaveRoom(uint32 room_id, uint64 player_id);

    void broadcast_room_add(uint32 id, const std::string& roomName, bool isPublic);
    void broadcast_room_info_change(uint32 room_id, const std::string& roomName, uint32 playersCount, bool isPublic);


private:
    adap_map<uint32, Room*> _rooms;
    std::vector<uint32> _freeIds;
    RoomPool _roomPool;
};

#endif