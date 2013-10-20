#ifndef SESSION_MANAGER_H_
#define SESSION_MANAGER_H_

#include <common.h>
#include <object_pool.hpp>
#include "game_session.h"

class SessionPool
    : public Venus::Singleton<SessionPool>
{
public:
    ~SessionPool()
    {
    }

    GameSession* acquire(const uint64& session_id)
    {
        return _sessionPool.acquire(session_id);
    }

    void release(GameSession* session)
    {
        _sessionPool.release(session);
    }

private:
    ObjectPool<GameSession> _sessionPool;
};

class GameSessionManager
    : public Venus::Singleton<GameSessionManager>
{
    typedef std::hash_map<uint64, GameSession*> SessionTable;

public:
    bool init()
    {
    }

    void fini()
    {
    
    }

public:
    void add_session(GameSession* session)
    {
        if (get(session->session_id()) == nullptr)
        {
            _mutex.lock();
            _sessionList.insert(std::make_pair(session->session_id(), session));
            _mutex.unlock();
        }
    }

    void remove_session(uint64 session_id)
    {
        SessionTable::const_iterator iter = _sessionList.find(session_id);
        if (iter != _sessionList.end())
        {
            _mutex.lock();
            _sessionList.erase(iter);
            _mutex.unlock();
        }
    }

    void remove_session(GameSession* session)
    {
        remove_session(session->session_id());
    }

    GameSession* get(uint64 session_id)
    {
        SessionTable::const_iterator iter = _sessionList.find(session_id);
        if (iter != _sessionList.end())
        {
            return iter->second;
        }

        return nullptr;
    }

private:
    SessionTable _sessionList;
    std::mutex _mutex;
};

#endif