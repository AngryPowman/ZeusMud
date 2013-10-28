#ifndef __PLAYER_H__
#define __PLAYER_H__

#include <common.h>
#include "game_object.h"

class GameSession;
class PlayerDB;
class Player : public GameObject
{
public:
    Player(uint64 guid);
    virtual ~Player();

public:
    bool loadFromDB();
    bool loadFromMemCached();

public:
    void attackSession(GameSession* session);
    GameSession* session();

private:
    uint64 _guid;
    PlayerDB* _playerDB;
};

#endif