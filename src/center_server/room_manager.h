#include <common.h>
#include <manager.h>
#include "room.h"
class RoomManager
    : Venus::Singleton<RoomManager>
{
    static const int MAX_ROOM = 1000;
public:
    bool init();
    void destory();

    bool addRoom();
    void removeRoom();
    bool getRooms(adap_map<uint64, Room*>& rooms);

private:
    adap_map<uint64, Room*> _rooms;
};
