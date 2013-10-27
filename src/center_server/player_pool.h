#ifndef __PLAYER_POOL_H__
#define __PLAYER_POOL_H__

#include <singleton.h>
#include <object_pool.hpp>
#include "player.h"

template <typename T>
class GameObjectPool
    : public Venus::Singleton<GameObjectPool<T>>
{
public:
    T* acquire()
    {
        return _pool.acquire();
    }

private:
    Venus::ObjectPool<T> _pool;
};

class PlayerPool
    : public GameObjectPool<Player>
{
};

#endif