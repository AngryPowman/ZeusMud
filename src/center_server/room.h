#include <common.h>
class Room
{
public:
    int getId() { return _id; }
    std::string getRoomName() { return _roomName; }
    std::string getPassword() { return _password; }
protected:
private:
    std::string _roomName;
    std::string _password;
    int _id;
};
