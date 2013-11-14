#include "game_session.h"
#include "game_session_manager.h"
#include "player.h"

GameSession::GameSession(const uint64& session_id)
    : NetworkSession(session_id)
{

}

GameSession::~GameSession()
{
}


bool GameSession::init()
{
    return true;
}

void GameSession::destroy()
{
    stopHeartbeatCheck();
}

void GameSession::heartbeat_handler(const NetworkMessage& message)
{
	std::time_t now = Poco::Timestamp().epochTime();
	_heartbeat.last_heartbeat_time = now;
}

Player* GameSession::getPlayer()
{
    return _player;
}

void GameSession::attackPlayerPtr(Player* player)
{
    _player = player;
}

void GameSession::onHeartbeatCheck(Poco::Timer& timer)
{
    info_log("[%ull] - > Check Heartbeat", _player->guid());

    // 心跳检查规则：
    // 假设正常报心跳时间是40秒一个周期，将允许前后误差2秒，也就是说在58~62秒之间报都是合法的。
    // 如果不在范围内报心跳，则记为一次异常，超过指定次数后踢掉连接。

    std::time_t now = Poco::Timestamp().epochTime();
    int64 interval = now - _heartbeat.last_heartbeat_time;
    int32 up_deviation_value = SessionHeartbeat::HEARTBEAT_TIME + SessionHeartbeat::HEARTBEAT_DEVIATION_VALUE;
    int32 down_deviation_value = SessionHeartbeat::HEARTBEAT_TIME - SessionHeartbeat::HEARTBEAT_DEVIATION_VALUE;

    if (interval > up_deviation_value || interval < down_deviation_value)
    {
        ++_heartbeat.failed_count;
        warning_log("Player %ull unormal heartbeat happened, failed_count = %d", _player->guid(), _heartbeat.failed_count);

        //如果连续三次心跳时间异常，则判定为网络不稳定，踢掉
        if (_heartbeat.failed_count >= 3)
        {
            debug_log("Player %ull failed heartbeat at the limit, close session.", _player->guid());
            GameSessionManager::getInstance().destroySession(this);
        }
    }
    else
    {
        _heartbeat.failed_count = 0;
    }
}

void GameSession::startHeartbeatCheck(long interval/* = 10000*/)
{
    //初始化心跳时间
    _heartbeat.last_heartbeat_time = Poco::Timestamp().epochTime();

    //开始心跳检查
    _heartbeat_checker.setStartInterval(interval);
    _heartbeat_checker.setPeriodicInterval(interval);

    Poco::TimerCallback<GameSession> heartbeat_check_callback(*this, &GameSession::onHeartbeatCheck);  
    _heartbeat_checker.start(heartbeat_check_callback);
}

void GameSession::stopHeartbeatCheck()
{
    _heartbeat_checker.stop();
}
