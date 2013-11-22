#include "network_proxy.h"
#include "tcp_server.h"
#include "game_io_dispatcher.h"

NetworkProxy::NetworkProxy()
    : _service(nullptr), 
    _event_handler(nullptr)
{
}

NetworkProxy::~NetworkProxy()
{
    SAFE_DELETE(_server);
}

bool NetworkProxy::init(IOService& service, GameIODataEventHandler* event_handler, uint16 listen_port, uint32 io_thread_numbers)
{
    _service = &service;
    _event_handler = event_handler;

    // initialize network
    // create tcp server instance
    _server = new TcpServer(InetAddress(listen_port), *_service, io_thread_numbers);

    // register io data event handler
	_server->registerNewConnectionEvent(
		BIND_EVENT_HANDLER(&NetworkProxy::__internalNewConnectionEvent, this));

    _server->registerDataWriteFinishedEvent(
        BIND_EVENT_HANDLER(&NetworkProxy::__internalDataWriteFinishedEvent, this));

    _server->registerDataReadEvent(
        BIND_EVENT_HANDLER(&NetworkProxy::__internalDataReadEvent, this));

    _server->registerConnectionClosedEvent(
        BIND_EVENT_HANDLER(&NetworkProxy::__internalConnectionClosedEvent, this));

    // start server
    _server->start();

    return true;
}

void NetworkProxy::destroy()
{
    _server->stop();
}

void NetworkProxy::close_connection(const TcpConnectionPtr& connection)
{
    auto iter = _connections.find(connection->handle());
    if (iter != _connections.end())
    {
        _connections.erase(iter);
    }

    connection->shutdown();
    connection->close();
}

void NetworkProxy::__internalNewConnectionEvent(const TcpConnectionPtr& connection, const NewConnectionEventArgs& args)
{
    debug_log("Enter NetworkProxy::__internalNewConnectionEvent --");

    auto iter = _connections.find(connection->handle());
    if (iter != _connections.end())
    {
        error_log("connection exists. handle = %d", connection->handle());
        return;
    }

    _connections.insert(std::make_pair(connection->handle(), &connection));

    //create game session
    GameSession* session = GameSessionManager::getInstance().createSession();
    session->init();
    session->set_connection_ptr(connection);

    debug_log(
        "New Session [NativeHandle = %d, SessionId = %ull, Peer = %s", 
        connection->handle(), 
        session->session_id(), 
        args.peer_address.toIpHost().c_str());

    auto callback = _dispatcher.getNewConnectionEvent();
    if (callback) callback(connection, args);
}

void NetworkProxy::__internalConnectionClosedEvent(const TcpConnectionPtr& connection, const EventArgs& args)
{
    debug_log("Enter NetworkProxy::__internalConnectionClosedEvent --");

    auto iter = _connections.find(connection->handle());
    if (iter != _connections.end())
    {
        _connections.erase(iter);
    }

    //call closed event
    auto callback = _dispatcher.getConnectionClosedEvent();
    if (callback) callback(connection, args);
}