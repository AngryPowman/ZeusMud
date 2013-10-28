#ifndef SESSION_MANAGER_H_
#define SESSION_MANAGER_H_

#include <common.h>
#include <network_common.h>
#include <object_pool.hpp>
#include "game_session.h"

class GameSessionManager
    : public Venus::Singleton<GameSessionManager>
{
    static const int MAX_SESSIONS = 3000;

public:
    bool init();
    void destroy();

public:
    GameSession* createSession(const uint64& session_id);
    void destroySession(GameSession* session);
    GameSession* getSession(const uint64& id);
    int32 sessionCount() const;

    template <typename T> void broadcast(uint32 opcode, const T& message);

private:
    bool add(GameSession* session);
    void remove(const uint64& id);

private:
    std::mutex _mutex;
    adap_map<uint64, GameSession*> _sessions;
    Venus::ObjectPool<GameSession> _sessionPool;
};

#endif