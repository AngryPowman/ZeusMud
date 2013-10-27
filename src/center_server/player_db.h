#ifndef __DB_PLAYER_H__
#define __DB_PLAYER_H__

#include <common.h>

class PlayerDB
{
public:
    void loadFromDB();
    void loadFromMemCached();

public:
    struct UserInfo
    {
        uint64 guid;
        std::string email;
        uint8 gender;
        std::string nickname;
        std::string register_ip;
        int64 register_time;
        int64 last_login_time;
    };

    struct GameInfo
    {

    };
};

#endif