#include "player.h"
#include "game_session.h"

Player::Player()
{
}

Player::Player(uint64 guid)
{

}

Player::Player(uint64 guid, GameSession* session)
{

}

Player::~Player()
{

}

bool Player::loadFromDB()
{
    return true;
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