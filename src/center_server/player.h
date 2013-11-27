#ifndef __PLAYER_H__
#define __PLAYER_H__

#include <common.h>
#include "game_object.h"

class GameSession;
class PlayerDB;

enum PlayerGender
{
    GENDER_NONE = 0,
    GENDER_FEMALE = 1,
    GENDER_MALE = 2
};

class Player : public GameObject
{
public:
    Player(uint64 guid, GameSession* session);
    virtual ~Player();

public:
    bool loadFromDB();
    bool saveToDB();
    bool loadFromMemCached();
	void onLeaveGame();

public:
	template <typename T> void send_message(uint32 opcode, const T& message)
	{
		if (_session != nullptr)
			_session->send_message<T>(opcode, message);
	}

public:
    //properties
    uint64 guid() const;

    void gender(int32 gender);
    int32 gender() const;

    void nickname(const std::string& nickname);
    const std::string& nickname() const;

    void lastLogin(int64 last_login);
    int64 lastLogin() const;

    void guildId(uint64 guild_id);
    uint64 guildId() const;
    void guildName(const std::string& guild_name);
    const std::string& guildName() const;

    void gold(uint32 gold);
    uint32 gold() const;

public:
    PlayerDB* DB();
    GameSession* session();

private:
    uint64 _guid;
    PlayerDB* _playerDB;
    GameSession* _session;
};

#endif