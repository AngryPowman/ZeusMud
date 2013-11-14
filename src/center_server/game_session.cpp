#include "game_session.h"
#include "game_session_manager.h"

GameSession::GameSession(const uint64& session_id)
    : NetworkSession(session_id)
{

}

GameSession::~GameSession()
{

}

void GameSession::heartbeat_handler( const NetworkMessage& message )
{
	std::time_t now = Poco::Timestamp().epochTime();
	if (now - _heartbeat.last_heartbeat_time > 
		(SessionHeartbeat::HEARTBEAT_TIME - SessionHeartbeat::HEARTBEAT_DEVIATION_VALUE))
	{
		_heartbeat.failed_count++;
		if (_heartbeat.failed_count >= 5)
		{
			closeSession();
			GameSessionManager::getInstance().destroySession(this);
		}
	}
	else
	{
		_heartbeat.failed_count = 0;
		_heartbeat.last_heartbeat_time = now;
	}
}

Player* GameSession::getPlayer()
{
    return _player;
}

void GameSession::attackPlayerPtr(Player* player)
{
    _player = player;
}