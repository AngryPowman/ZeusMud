#include "network_session.h"

NetworkSession::NetworkSession(const uint64& session_id)
    : _sessionId(session_id),
    _connection(nullptr)
{
}

NetworkSession::~NetworkSession()
{
}

void NetworkSession::set_connection_ptr(const TcpConnectionPtr& connection)
{
    _connection = connection;
}

uint64 NetworkSession::session_id() const
{
    return _sessionId;
}

void NetworkSession::user_login_handler(const NetworkMessage& message)
{
    Protocol::C2SLoginReq request;
    message.parse(request);

    printf("[User Login] -> (Username='%s', Password='%s')", request.email().c_str(), request.password().c_str());

    Protocol::S2CLoginRsp login_response;
    bool exists = GameDatabaseSession::getInstance().checkUserExists(request.email());
    login_response.set_login_result(exists);
    login_response.set_failed_reason(exists == true ? "" : "用户不存在。");

    send_message<Protocol::S2CLoginRsp>(Opcodes::S2CLoginRsp, login_response);
}

void NetworkSession::user_register_handler(const NetworkMessage& message)
{
    Protocol::C2SRegisterReq request;
    message.parse(request);

    printf("[User Register] -> (Username='%s', Nickname='%s')", request.email().c_str(), request.nickname().c_str());

    Protocol::S2CRegisterRsp register_response;
    bool exists = GameDatabaseSession::getInstance().checkUserExists(request.email());
    if (exists == true)
    {
        register_response.set_register_result(false);
        register_response.set_failed_reason("注册失败，该用户已存在，请换个拉风点的邮箱帐号。");
    }
    else
    {
        GameDatabaseSession::getInstance().insertNewUserRecord(
            GameUtil::getInstance().toUniqueId(request.email()),
            request.email(),
            request.password(),
            (uint8)request.gender(),
            request.nickname(),
            _connection->getPeerAddress().host(),
            Poco::Timestamp().epochTime());

        register_response.set_register_result(true);
        register_response.set_failed_reason("");
    }

    send_message<Protocol::S2CRegisterRsp>(Opcodes::S2CRegisterRsp, register_response);
}