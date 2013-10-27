#ifndef __PLAYER_H__
#define __PLAYER_H__

#include <common.h>

class GameSession;
struct PlayerDB;
class Player
{
public:
    Player();
    Player(uint64 guid);
    Player(uint64 guid, GameSession* session);
    virtual ~Player();

public:
    bool loadFromDB();
    bool loadFromMemCached();

public:
    void attackSession(GameSession* session);
    GameSession* session();

private:
    PlayerDB* _playerDB;
};

#endif