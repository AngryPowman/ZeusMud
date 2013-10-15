#ifndef __GAME_SERVICE_H__
#define __GAME_SERVICE_H__

#include <service.h>
#include <singleton.h>

class GameService
    : public Venus::Service, public Venus::Singleton<GameService>
{
public:
    GameService();
    ~GameService();

public:
    bool initialize();
    void destroy();
    
private:
    bool registerDatabase();
    void unregisterDatabase();
};

#endif