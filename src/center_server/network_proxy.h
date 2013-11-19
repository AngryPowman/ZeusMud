#ifndef __NETWORK_MANAGER_H__
#define __NETWORK_MANAGER_H__

#include <network_common.h>
#include <singleton.h>
#include <io_service.h>

class IODataEventHandler
{
public:
    virtual ~IODataEventHandler() {}

    virtual void newConnectionEvent(const TcpConnectionPtr& connection, const NewConnectionEventArgs& args) = 0;
    virtual void dataWriteFinishedEvent(const TcpConnectionPtr& connection, const DataWriteFinishedEventArgs& args) = 0;
    virtual void dataReadEvent(const TcpConnectionPtr& connection, const DataReadEventArgs& args) = 0;
    virtual void connectionClosedEvent(const TcpConnectionPtr& connection, const EventArgs& args) = 0;
};

class IODataDispatcher
{
public:
    //register
    void registerNewConnectionEvent(const NewConnectionEvent& event) { _newConnectionEvent = event; }
    void registerDataWriteFinishedEvent(const DataWriteFinishedEvent& event) { _dataWriteFinishedEvent = event; }
    void registerDataReadEvent(const DataReadEvent& event) { _dataReadEvent = event; }
	void registerConnectionClosedEvent(const ConnectionClosedEvent& event) { _connectionClosedEvent = event; }

    //getter
	inline NewConnectionEvent& getNewConnectionEvent() { return _newConnectionEvent; }
    inline DataWriteFinishedEvent& getDataWriteFinishedEvent() { return _dataWriteFinishedEvent; }
    inline DataReadEvent& getDataReadEvent() { return _dataReadEvent; }
    inline ConnectionClosedEvent& getConnectionClosedEvent() { return _connectionClosedEvent; }

private:
    NewConnectionEvent _newConnectionEvent;
    DataWriteFinishedEvent _dataWriteFinishedEvent;
    DataReadEvent _dataReadEvent;
	ConnectionClosedEvent _connectionClosedEvent;
};

class TcpServer;
class GameIODataEventHandler;
class NetworkProxy
    : public Venus::Singleton<NetworkProxy>
{
public:
    NetworkProxy();
    virtual ~NetworkProxy();

public:
    bool init(IOService& service, GameIODataEventHandler* event_handler, uint16 listen_port, uint32 io_thread_numbers);
    void destroy();
    void close_connection(const TcpConnectionPtr& connection);
    void registerNewConnectionEvent(const NewConnectionEvent& event);
    void registerDataWriteFinishedEvent(const DataWriteFinishedEvent& event);
    void registerDataReadEvent(const DataReadEvent& event);
	void registerConnectionClosedEvent(const ConnectionClosedEvent& event);

private:
    // 内部事件
    void __internalNewConnectionEvent(const TcpConnectionPtr& connection, const NewConnectionEventArgs& args);
    void __internalConnectionClosedEvent(const TcpConnectionPtr& connection, const EventArgs& args);

private:
    IODataDispatcher _dispatcher;
    GameIODataEventHandler* _event_handler;
    IOService* _service;
    TcpServer* _server;
	adap_map<uint32, const TcpConnectionPtr*> _connections;
};

#endif