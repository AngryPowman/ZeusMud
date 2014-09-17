#include "tcp_connection_manager.h"


bool TcpConnectionManager::init()
{
	return true;
}

void TcpConnectionManager::destory()
{
	for( auto i = _connections.begin(); i != _connections.end(); ++i)
	{
		_connectionPool.release(*i);
	}

	_connections.clear();	
}

TcpConnection*  TcpConnectionManager::createConnection(IOService& io_service)
{
	_mutex.lock();
	TcpConnection* connection = _connectionPool.acquire<IOService&>(io_service);
	_connections.push_back( connection );
	_mutex.unlock();

	return connection;
	
}

void TcpConnectionManager::destoryConnection(TcpConnection* connection)
{
	_mutex.lock();
	_connections.erase( remove( _connections.begin(),_connections.end(),connection ), _connections.end() );
	_connectionPool.release(connection);	
	_mutex.unlock();
}

