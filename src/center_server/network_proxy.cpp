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
	this->registerNewConnectionEvent(
		BIND_EVENT_HANDLER(&GameIODataEventHandler::newConnectionEvent, _event_handler));

    this->registerDataWriteFinishedEvent(
        BIND_EVENT_HANDLER(&GameIODataEventHandler::dataWriteFinishedEvent, _event_handler));

    this->registerDataReadEvent(
        BIND_EVENT_HANDLER(&GameIODataEventHandler::dataReadEvent, _event_handler));

    this->registerConnectionClosedEvent(
        BIND_EVENT_HANDLER(&GameIODataEventHandler::connectionClosedEvent, _event_handler));

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

void NetworkProxy::registerNewConnectionEvent(const NewConnectionEvent& event)
{
    _dispatcher.registerNewConnectionEvent(event);
    _server->registerNewConnectionEvent(BIND_EVENT_HANDLER(&NetworkProxy::__internalNewConnectionEvent, this));
}

void NetworkProxy::registerDataWriteFinishedEvent(const DataWriteFinishedEvent& event)
{
    _dispatcher.registerDataWriteFinishedEvent(event);
    _server->registerDataWriteFinishedEvent(event);
}

void NetworkProxy::registerDataReadEvent(const DataReadEvent& event)
{
    _dispatcher.registerDataReadEvent(event);
    _server->registerDataReadEvent(event);
}

void NetworkProxy::registerConnectionClosedEvent( const ConnectionClosedEvent& event )
{
	_dispatcher.registerConnectionClosedEvent(event);
	_server->registerConnectionClosedEvent(BIND_EVENT_HANDLER(&NetworkProxy::__internalConnectionClosedEvent, this));
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