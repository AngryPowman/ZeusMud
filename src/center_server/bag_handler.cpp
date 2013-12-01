#include "game_session.h"
#include "json/reader.h"

void GameSession::get_bag_items_handler(const NetworkMessage& message)
{
    Protocol::C2SGetPlayerProfileReq request;
    PARSE_NETWORK_MESSAGE(message, request);
}