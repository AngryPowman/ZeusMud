#include "byte_buffer.h"
#include "tcp_connection.h"
#include "network_common.h"
#include "inet_address.h"
#include "packet.h"
#include "protobuf.h"

TcpConnection::TcpConnection(IOService& io_service)
    : _inetAddress(0)
{
    _socket = new Socket(io_service);

    // register socket callbacks
    _socket->set_send_callback(std::bind(&TcpConnection::on_write, this, std::placeholders::_1));
    _socket->set_receive_callback(std::bind(&TcpConnection::on_read, this, std::placeholders::_1, std::placeholders::_2));
    _socket->set_close_callback(std::bind(&TcpConnection::on_close, this));
}

TcpConnection::~TcpConnection()
{
    SAFE_DELETE(_socket);

    _buffer.clear();
    debug_log("connection destroyed.");
}

InetAddress TcpConnection::getPeerAddress()
{
    return _socket->getPeerAddress();
}

void TcpConnection::shutdown()
{
    _socket->shutdown();
}

void TcpConnection::close()
{
    _socket->close();
}

void TcpConnection::writeAsync(const byte* data, size_t size)
{
    _socket->start_send(data, size);
}

void TcpConnection::writeAsync(const uint32& opcode, const byte* message_data, size_t message_size)
{
    if (message_data == nullptr || message_size == 0)
    {
        error_log("empty data.");
        return;
    }

    ByteBuffer buffer;
    buffer << ServerPacket::HEADER_LENGTH + message_size;
    buffer << opcode;
    buffer.append(message_data, message_size);

    writeAsync(buffer.buffer(), buffer.size());
}

void TcpConnection::readAsync()
{
    _socket->start_receive();
}

Socket& TcpConnection::rawSocket()
{
    return *_socket;
}

bool TcpConnection::is_open()
{
    return _socket->is_open();
}

void TcpConnection::registerDataWriteFinishedEvent(const DataWriteFinishedEvent& event)
{
    _dataWriteFinishedEvent = event;
}

void TcpConnection::registerDataReadEvent(const DataReadEvent& event)
{
    _dataReadEvent = event;
}

void TcpConnection::registerConnectionClosedEvent(const ConnectionClosedEvent& event)
{
    _connectionClosedEvent = event;
}

void TcpConnection::on_write(
    std::size_t bytes_transferred           // Number of bytes sent.
)
{
    debug_log("bytes_transferred = %d", bytes_transferred);
    if (_dataWriteFinishedEvent)
    {
        _dataWriteFinishedEvent(shared_from_this(), DataWriteFinishedEventArgs(bytes_transferred));
    }
    else
    {
        debug_log("write complected.");
    }
}

void TcpConnection::on_read(const byte* data, size_t bytes_transferred)
{
    readAsync();

    size_t bodyLen = 0;

    ByteBuffer read_buffer(_socket->get_recv_buffer(), bytes_transferred);
    _buffer.append(read_buffer);

    std::vector<ServerPacketPtr> packetList;

    _buffer.set_rpos(0);

    //���ٴ��ڵ���header���ȣ�����bodyΪ�գ�
    while (_buffer.size() >= sizeof(ServerPacket::HEADER_LENGTH))
    {
        size_t packet_len = 0;
        uint32 opcode = 0;

        _buffer >> packet_len;
        _buffer >> opcode;

        //���ݰ����ȴ��������ճ�����Ϊ�Ƿ����ɵ�
        if (packet_len >= MAX_RECV_LEN || read_buffer.size() >= MAX_RECV_LEN || bytes_transferred != packet_len)
        {
            warning_log("Warning: Read packet header length %d bytes (which is too large) on peer socket. (Invalid Packet?)", packet_len);
            shutdown();
            return;
        }

        if (_buffer.size() < packet_len)
        {
            return;
        }
        else if (_buffer.size() >= packet_len)
        {
            ServerPacketPtr packet(new ServerPacket());
            packet->len = packet_len;
            packet->opcode = opcode;

            //ȡ��body����
            bodyLen = packet_len - ServerPacket::HEADER_LENGTH;

            packet->message = bodyLen == 0 ? nullptr : new byte[bodyLen];

            if (bodyLen != 0)
                _buffer.read(packet->message, bodyLen);

            packetList.push_back(packet);
            _buffer.erase(0, packet_len);
            _buffer.set_rpos(0);
            _buffer.set_wpos(0);
        }
    }

    for (size_t i = 0; i < packetList.size(); ++i)
    {
        const ServerPacketPtr& packet = packetList[i];

        if (_dataReadEvent)
        {
            _dataReadEvent(shared_from_this(), DataReadEventArgs(packet->opcode, packet->message, packet->len));
        }
        else
        {
            warning_log("Warnning : not set read callback instance.");
        }
    }

    packetList.clear();

}

void TcpConnection::on_close()
{
    if (_connectionClosedEvent)
    {
        _connectionClosedEvent(shared_from_this(), NO_EVENT_ARGS());
    }
}