#ifndef __ROOM_H__
#define __ROOM_H__

#include <common.h>
class Room
{
public:
    Room(uint32 id, const std::string& roomName, const std::string& password) 
    {
        _id = id;
        _roomName = roomName;
        _password = password;
    }
    int getId() { return _id; }
    std::string getRoomName() { return _roomName; }
    std::string getPassword() { return _password; }
protected:
private:
    std::string _roomName;
    std::string _password;
    uint32 _id;
};
#endif