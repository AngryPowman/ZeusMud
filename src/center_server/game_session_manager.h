#ifndef SESSION_MANAGER_H_
#define SESSION_MANAGER_H_

#include <common.h>
#include <network_common.h>
#include <object_pool.hpp>
#include "game_session.h"

#define MAX_SESSIONS 3000

#if defined(WIN32)
typedef std::unordered_map<uint64, GameSession*> GameSessionMap;
#else
typedef std::map<uint64, GameSession*> GameSessionMap;
#endif

class GameSessionManager
    : public Venus::Singleton<GameSessionManager>
{
public:
    bool init();
    void destroy();

public:
    GameSession* createSession(const uint64& session_id);
    void destroySession(GameSession* session);
    GameSession* getSession(const uint64& id);

    template <typename T> void broadcast(uint32 opcode, const T& message);

private:
    bool add(GameSession* session);
    void remove(const uint64& id);

private:
    std::mutex _mutex;
    GameSessionMap _sessions;
    Venus::ObjectPool<GameSession> _sessionPool;
};

#endif