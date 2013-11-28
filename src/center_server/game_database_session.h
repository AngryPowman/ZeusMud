#ifndef __GAME_DATABASE_SESSION_H__
#define __GAME_DATABASE_SESSION_H__

#include <common.h>
#include <Poco/Data/Common.h>
#include <Poco/Data/SQLite/Connector.h>
#include <Poco/Data/RecordSet.h>
#include <Poco/Data/SessionFactory.h>

class PlayerDB;

class GameDatabaseSession
    : public Venus::Singleton<GameDatabaseSession>
{
public:
    GameDatabaseSession();
    ~GameDatabaseSession();

public:
    //====================================================================
    // ��¼ϵͳ
    //====================================================================

    //������ݿ���һ���û��Ƿ����
    bool checkUserExists(const std::string& email);

    //������ݿ����ǳ��Ƿ����
    bool checkNicknameExists(const std::string& nickname);

    //��֤�ʺź������Ƿ�ƥ��
    bool userAuth(const std::string& email, const std::string& pass_hash);

    //�����µ��û���¼
    void insertNewUserRecord(
        uint64 guid, 
        const std::string& email,
        const std::string& password,
        int32 gender,
        const std::string& nickname,
        const std::string& register_ip,
        uint64 register_timestamp
    );

    //====================================================================
    // ��ɫ���
    //====================================================================
    bool loadPlayerInfo(uint64 guid, PlayerDB* playerDB);
    bool savePlayerInfo(uint64 guid, PlayerDB* playerDB);


private:
    Poco::Data::Session _db_session;
    Poco::Data::Statement _db_stmt;
};

#endif