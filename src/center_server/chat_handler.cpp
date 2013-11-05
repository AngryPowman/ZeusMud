#include "game_session.h"
#include "game_session_manager.h"
#include "player.h"

enum MessageChannel
{
    ChannelSystem = 0,
    ChannelWorld = 1,
    ChannelPrivate = 2,
    ChannelGuild = 3,
};

void GameSession::chat_message_handler(const NetworkMessage& message)
{
    Protocol::C2SChatMessageReq request;
    PARSE_NETWORK_MESSAGE(message, request);

    if (request.chat_type() == ChannelSystem)
    {
        debug_log("Could not request system chat message.");
        return;
    }

    debug_log("Chat message [channel = %d, content = %s]", request.chat_type(), request.chat_content().c_str());

    Protocol::S2CChatMessageNotify chatMessageNotify;
    chatMessageNotify.set_chat_type(request.chat_type());
    chatMessageNotify.set_chat_content(request.chat_content());
    chatMessageNotify.set_source_player(_player->nickname());

    switch (request.chat_type())
    {
        case ChannelGuild:
        case ChannelWorld:
        {
            GameSessionManager::getInstance().broadcast
                <Protocol::S2CChatMessageNotify>(Opcodes::S2CChatMessageNotify, chatMessageNotify);
            break;
        }
        case ChannelPrivate:
        {
            GameSession* session = GameSessionManager::getInstance().getSession(request.private_chat_target());
            if (session != nullptr)
            {
                session->send_message(Opcodes::S2CChatMessageNotify, chatMessageNotify);
            }
            break;
        }
    }
}