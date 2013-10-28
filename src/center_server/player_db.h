#ifndef __DB_PLAYER_H__
#define __DB_PLAYER_H__

#include <common.h>
#include "game_database_session.h"

class PlayerDB
{
public:
    bool loadFromDB(uint64 guid)
    {
        return GameDatabaseSession::getInstance().loadPlayerInfo(guid, this);
    }

    void loadFromMemCached();

public:
    struct _UserInfo
    {
        std::string email;
        uint8 gender;
        std::string nickname;
        std::string register_ip;
        int64 register_time;
        int64 last_login_time;
    } UserInfo;

    struct _GameInfo
    {

    } GameInfo;
};

#endif