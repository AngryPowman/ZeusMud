#ifndef __PLAYER_H__
#define __PLAYER_H__

#include <common.h>
#include "game_object.h"

class GameSession;
struct PlayerDB;
class Player : public GameObject
{
public:
    Player();
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