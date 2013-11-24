#ifndef __NETWORK_MANAGER_H__
#define __NETWORK_MANAGER_H__

#include <network_common.h>
#include <singleton.h>
#include <io_service.h>
#include "session_io.h"

struct SessionPair
{

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
    // ��ʼ������
    bool init(IOService& service, GameIODataEventHandler* event_handler, uint16 listen_port, uint32 io_thread_numbers);

    // �ͷ�����
    void destroy();

    // �����ر�һ���ϲ�����
    // ע��ͨ���������øýӿڹر�����ʱ���ᴥ�����ϲ��ConnectionClosed�¼����ͷ���Ϸ��Դ����
    void close_connection(const TcpConnectionPtr& connection);

public:
    // IO�¼�ע��
    void registerSessionCreatedHandler(const SessionCreated& event);
    void registerSessionMessageHandler(const SessionMessage& event);
    void registerConnectionClosingHandler(const SessionClosing& event);

private:
    // �ڲ��¼�
    // �յ�����֮ǰ����NetworkProxy�ӹܣ�����һЩ���ӵĹ����Լ����չ����ٻص����ϲ�
    void __internalNewConnectionEvent(const TcpConnectionPtr& connection, const NewConnectionEventArgs& args);
    void __internalDataWriteFinishedEvent(const TcpConnectionPtr& connection, const DataWriteFinishedEventArgs& args);
	void __internalDataReadEvent(const TcpConnectionPtr& connection, const DataReadEventArgs& args);
	void __internalConnectionClosedEvent(const TcpConnectionPtr& connection, const EventArgs& args);

private:
    IODataDispatcher _dispatcher;
    GameIODataEventHandler* _event_handler;
    IOService* _service;
    TcpServer* _server;

    // ������������
    // - first  : handle
    // - second : std::pair<TcpConnectionPtr*, GameSession*>
	adap_map<uint32, std::pair<const TcpConnectionPtr*, GameSession*>> _connections;
};

#endif