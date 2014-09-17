#ifndef TCP_CONNECTION_MANAGER_H_
#define TCP_CONNECTION_MANAGER_H_

#include "common.h"
#include "singleton.h"
#include "object_pool.hpp"
#include "tcp_connection.h"

class  TcpConnectionManager
	:public Venus::Singleton<TcpConnectionManager>
{
public:
	bool init();
	void destory();

public:
	TcpConnection*  createConnection(IOService& io_service);
	void  destoryConnection(TcpConnection* connection);

private:
	std::mutex   _mutex;
	std::vector<TcpConnection*>  _connections;
	Venus::ObjectPool<TcpConnection> _connectionPool;
};

#endif