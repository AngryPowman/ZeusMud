#ifndef __GAME_SESSION_H__
#define __GAME_SESSION_H__

#include "network_session.h"
#include <Poco/Timer.h>

class Player;
class GameSession
    : public NetworkSession
{
	struct SessionHeartbeat
	{
		static const int32 HEARTBEAT_TIME = 40;           //心跳报时时间（40秒）
		static const int32 HEARTBEAT_DEVIATION_VALUE = 2; //允许误差值（2秒）

		SessionHeartbeat() 
		{
			cleanup();
		}

		void cleanup()
		{
			last_heartbeat_time = 0;
			failed_count = 0;
		}

		int64 last_heartbeat_time;
		int32 failed_count;
	};

public:
    GameSession(const uint64& session_id);
    virtual ~GameSession();

    bool init();
    void destroy();

public:
    Player* getPlayer();

private:
    void attackPlayerPtr(Player* player);

public:
	//心跳
	void heartbeat_handler(const NetworkMessage& message);

    //登录模块
    void user_login_handler(const NetworkMessage& message);
    void user_register_handler(const NetworkMessage& message);

    //玩家资料模块
    void get_player_profile_handler(const NetworkMessage& message);

    //聊天模块
    void chat_message_handler(const NetworkMessage& message);

    //房间模块
    void room_create_handler(const NetworkMessage& message);
    void get_room_list_handler(const NetworkMessage& message);
    void broadcast_room_add(uint32 id, const std::string& roomName, bool isPublic);
    void enter_room_handler(const NetworkMessage& message);
    void broadcast_room_info_change(uint32 room_id, const std::string& roomName, uint32 playersCount);
    void room_info_change_handler(const NetworkMessage& message);

private:
    void startHeartbeatCheck(long interval = 10000);
    void stopHeartbeatCheck();
    void onHeartbeatCheck(Poco::Timer& timer);

private:
    Player* _player;
	SessionHeartbeat _heartbeat;
    Poco::Timer _heartbeat_checker;
};

#endif