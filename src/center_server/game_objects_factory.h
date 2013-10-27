#ifndef __GAME_OBJECTES_FACTORY_H__
#define __GAME_OBJECTES_FACTORY_H__

#include <common.h>
#include <singleton.h>

enum ObjectType
{
    OBJ_TYPE_NONE,
    OBJ_TYPE_PLAYER
};

class GameObjectsFactory
    : public Venus::Singleton<GameObjectsFactory>
{
public:
    void init();

private:

};

#endif