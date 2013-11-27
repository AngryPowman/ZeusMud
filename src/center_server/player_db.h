#ifndef __DB_PLAYER_H__
#define __DB_PLAYER_H__

#include <common.h>
#include "game_database_session.h"

class PlayerDB
{
public:
    bool loadFromDB(uint64 guid);
    bool saveToDB(uint64 guid);
    void loadFromMemCached();
    void cleanup();

public:
    std::string email;          //���������ʺ�
    int32 gender;               //�Ա�
    std::string nickname;       //�ǳ�
    std::string register_ip;    //ע��IP
    int64 register_time;        //ע��ʱ��
    int64 last_login;           //�ϴε�¼ʱ��
    uint64 guild_id;            //��������ID
    std::string guild_name;     //������������
};

#endif