﻿#include "acceptor.h"
#include "tcp_connection.h"
#include "network_common.h"
#include "io_service.h"

Acceptor::Acceptor(const InetAddress& listenAddress, IOService& service, uint32_t threadNums)
    : _io_service(service),
    _acceptor(service.service()),
    _strand(service.service()),
    _listenAddr(listenAddress),
    _listenning(false),
    _threadNums(threadNums)
{
    debug_log("Acceptor starting ...");
    debug_log("  >> Listen Address = %s", _listenAddr.toIpHost().c_str());
    debug_log("  >> I/O-Thread Numbers = %d", threadNums);

    //绑定地址
    boost::asio::ip::address address;
    address.from_string(_listenAddr.host());
    tcp::endpoint endpoint(address, _listenAddr.port());
    _acceptor.open(tcp::v4());
    _acceptor.bind(endpoint);

    debug_log("Acceptor started.");
}

Acceptor::~Acceptor()
{
}

std::string Acceptor::host() const
{
    return _listenAddr.host();
}

uint16_t Acceptor::port() const
{
    return _listenAddr.port();
}

void Acceptor::listen(int32_t backlog/* = socket_base::max_connections*/)
{
    _acceptor.listen(backlog);
    _listenning = true;

    debug_log("Listenning ... ");
}

void Acceptor::startAccept()
{
    assert(_threadNums != 0);

    //投递一个接受事件
    accept();

    //为IO队列创建线程
    std::vector<ThreadPtr> threads;
    for (std::size_t i = 0; i < _threadNums; ++i)
    {
        ThreadPtr t(
            new std::thread(
                boost::bind(&boost::asio::io_service::run, &_io_service.service())
            )
       );
        threads.push_back(t);
    }

    for(std::size_t i = 0; i < threads.size(); ++i)
    {
        threads[i]->join();
    }
}

void Acceptor::stopAccept()
{
    _io_service.service().stop();
    _acceptor.close();
    debug_log("Acceptor stopped.");
}

bool Acceptor::listenning() const { return _listenning; }

void Acceptor::registerAcceptedEvent(const AcceptedEvent& event)
{
    _acceptedEvent = event;
}

void Acceptor::accept()
{
   //采用连接池，并定制智能指针的删除器
	TcpConnectionPtr  new_connection( 
		TcpConnectionManager::getInstance().createConnection( _io_service ),
		std::bind( 
		&TcpConnectionManager::destoryConnection, 
		TcpConnectionManager::getInstancePtr(), 
		std::placeholders::_1
		)
	 );

    //投递一个accept请求到io队列，并回调到acceptHandler
    _acceptor.async_accept(
        new_connection->rawSocket().socket(),
        _strand.wrap(
            std::bind(&Acceptor::acceptHandler, this, new_connection)
        )
   );
}

void Acceptor::acceptHandler(const TcpConnectionPtr& connection)
{
    accept();
    _acceptedEvent(connection, NO_EVENT_ARGS());

    //投递一个读请求
    connection->readAsync();
}