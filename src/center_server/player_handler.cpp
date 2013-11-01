#include "game_session.h"

void GameSession::get_player_profile_handler(const NetworkMessage& message)
{
    Protocol::C2SGetPlayerProfileReq request;
    PARSE_NETWORK_MESSAGE(message, request);

    Protocol::S2CGetPlayerProfileRsp response;

}