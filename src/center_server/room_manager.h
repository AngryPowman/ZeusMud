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
    static const uint32 ADD_ROOM_FAILED = 0;

public:
    RoomManager();
    ~RoomManager();
public:
    bool init();
    void destory();

    //////////////////////////////////////////////////////////////////////////
    // ����:���һ��room ������Ȼ��˳������ѡ��δʹ��id
    // ����:ʧ�� return ADD_ROOM_FAILED; �ɹ� return id;
    //////////////////////////////////////////////////////////////////////////
    uint32 addRoom(const std::string& roomName, const std::string& password);
    void removeRoom(uint32 id);
    void getRooms(adap_map<uint32, Room*>& rooms);

private:
    adap_map<uint32, Room*> _rooms;
    std::vector<uint32> _freeIds;
    RoomPool _roomPool;
};

#endif