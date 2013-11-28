#ifndef __GAME_SESSION_H__
#define __GAME_SESSION_H__

#include "network_session.h"
#include <Poco/Util/Timer.h>

class Player;
class Poco::Util::Timer;
class GameSession
    : public NetworkSession
{
	struct SessionHeartbeat
	{
		// ����������
		// ��������������ʱ����40��һ�����ڣ�������ǰ�����3�룬Ҳ����˵��37~43��֮�䱨���ǺϷ��ġ�
		// ������ڷ�Χ�ڱ����������Ϊһ���쳣������ָ���������ߵ����ӡ�

		static const int32 HEARTBEAT_TIME  = 10000;    //������ʱʱ�䣨���룩
		static const int32 DEVIATION_VALUE = 3000;     //�������ֵ�����룩
        static const int32 CHECK_PERIOD    = 12000;    //������ڣ����룩��������ڻ������������
        static const int32 FAILED_COUNT    = 3;        //�����ʧ�ܴ������ߵ�����

		static const int32 DOWN_DEVIATION_VALUE = HEARTBEAT_TIME - DEVIATION_VALUE;
		static const int32 UP_DEVIATION_VALUE = HEARTBEAT_TIME + DEVIATION_VALUE;

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
	//����
	void heartbeat_handler(const NetworkMessage& message);

    //��¼ģ��
    void user_login_handler(const NetworkMessage& message);
    void user_register_handler(const NetworkMessage& message);

    //�������ģ��
    void get_player_profile_handler(const NetworkMessage& message);

    //����ģ��
    void chat_message_handler(const NetworkMessage& message);

    //����ģ��
    void room_create_handler(const NetworkMessage& message);
    void get_room_list_handler(const NetworkMessage& message);
    void broadcast_room_add(uint32 id, const std::string& roomName, bool isPublic);
    void enter_room_handler(const NetworkMessage& message);
    void broadcast_room_info_change(uint32 room_id, const std::string& roomName, uint32 playersCount, bool isPublic);
    void room_info_change_handler(const NetworkMessage& message);

private:
    void startHeartbeatCheck(long interval = SessionHeartbeat::CHECK_PERIOD);
    void stopHeartbeatCheck();
    void onHeartbeatCheck(Poco::Util::TimerTask& task);
	void heartbeatFailed();

private:
    Player* _player;
	SessionHeartbeat _heartbeat;
    Poco::Util::Timer* _heartbeat_checker;
};

#endif