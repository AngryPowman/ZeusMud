#include "player.h"
#include "game_session.h"
#include "game_database_session.h"
#include "player_db.h"

Player::Player(uint64 guid)
    : _guid(guid), _playerDB(nullptr)
{
}

Player::~Player()
{
    SAFE_DELETE(_playerDB);
}

bool Player::loadFromDB()
{
    if (_playerDB == nullptr)
    {
        _playerDB = new PlayerDB();
        memset(_playerDB, 0, sizeof(_playerDB));
    }

    return _playerDB->loadFromDB(_guid);
}

bool Player::loadFromMemCached()
{
    return true;
}

void attackSession(GameSession* session)
{

}

GameSession* Player::session()
{
    return nullptr;
}