#ifndef __PLAYER_POOL_H__
#define __PLAYER_POOL_H__

#include <singleton.h>
#include <object_pool.hpp>
#include "player.h"

class PlayerPool
    : public Venus::ObjectPool<Player>, public Venus::Singleton<PlayerPool>
{
public:
    Player* acquire(uint64 guid)
    {
        return ObjectPool::acquire(guid);
    }
};

#endif