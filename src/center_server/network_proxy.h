#ifndef __NETWORK_MANAGER_H__
#define __NETWORK_MANAGER_H__

#include <network_common.h>
#include <singleton.h>
#include <io_service.h>
#include "game_session.h"

typedef std::function<void (const GameSession* session)> OnSessionCreated;
typedef std::function<void (const GameSession* session, NetworkMessage* message)> OnSessionMessage;
typedef std::function<void (const GameSession* session)> OnSessionClosing;

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
	OnSessionCreated onSessionCreated;
	OnSessionMessage onSessionMessage;
	OnSessionClosing onSessionClosing;
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
    // 初始化数据
    bool init(IOService& service, GameIODataEventHandler* event_handler, uint16 listen_port, uint32 io_thread_numbers);

    // 释放数据
    void destroy();

    // 主动关闭一个上层连接
    // 注：通过主动调用该接口关闭连接时，会触发到上层的ConnectionClosed事件，释放游戏资源即可
    void close_connection(const TcpConnectionPtr& connection);

private:
	// IO事件注册
	void registerSessionCreatedEvent(const NewConnectionEvent& event);
	void registerDataWriteFinishedEvent(const DataWriteFinishedEvent& event);
	void registerDataReadEvent(const DataReadEvent& event);
	void registerConnectionClosedEvent(const ConnectionClosedEvent& event);

    // 内部事件
    // 收到数据之前先由NetworkProxy接管，处理一些连接的管理以及回收工作再回调到上层
    void __internalNewConnectionEvent(const TcpConnectionPtr& connection, const NewConnectionEventArgs& args);
    void __internalDataWriteFinishedEvent(const TcpConnectionPtr& connection, const DataWriteFinishedEventArgs& args);
	void __internalDataReadEvent(const TcpConnectionPtr& connection, const DataReadEventArgs& args);
	void __internalConnectionClosedEvent(const TcpConnectionPtr& connection, const EventArgs& args);

private:
    IODataDispatcher _dispatcher;
    GameIODataEventHandler* _event_handler;
    IOService* _service;
    TcpServer* _server;

    // 管理所有连接
    // - first  : session id
    // - second : TcpConnection
	adap_map<uint32, const TcpConnectionPtr*> _connections;
};

#endif