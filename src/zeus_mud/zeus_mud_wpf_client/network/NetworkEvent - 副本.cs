using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using System.Windows.Forms;
using System.Diagnostics;
using Wpf.ZuesMud;
using System.Reflection;

namespace Wpf.network
{
    class NetworkEvent
    {
        private static OpcodesHandler _opcodeHandler = new OpcodesHandler();
        private static Dictionary<string, UInt32> _opcodesTable = new Dictionary<string, UInt32>();
        private static int MAX_RECV_LEN = (1024 * 4);

        public static void init()
        {
            foreach (Opcodes opcode in Enum.GetValues(typeof(Opcodes)))
            {
                string strKey = Enum.GetName(typeof(Opcodes), opcode);
                UInt32 strValue = (UInt32)opcode;
                _opcodesTable.Add(strKey, strValue);
            }
        }

        const int HEADER_LENGTH = 8;
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] _recvBuffer = new byte[MAX_RECV_LEN];
        public static bool connectToServer(string ip, UInt16 port)
        {
            addLog("正在连接到服务器 " + ip + ":" + port.ToString() + "...");

            //连接到服务器
            disconnectRobotServer();

            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                _clientSocket.Connect(IPAddress.Parse(ip), port);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            _clientSocket.BeginReceive(_recvBuffer, 0, _recvBuffer.Length, SocketFlags.None, new AsyncCallback(onReceived), _clientSocket);

            return true;
        }

        public static void disconnectRobotServer()
        {
            //连接到服务器
            if (_clientSocket != null && _clientSocket.Connected)
            {
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Disconnect(true);
                _clientSocket.Close();
            }
        }

        public static bool isConnected()
        {
            return _clientSocket.Connected;
        }


        /*******************************************************************************************
        /* 网络事件
        /*******************************************************************************************/
        private static void onSendCompleted(IAsyncResult result)
        {
            try
            {
                // Retrieve the socket from the state object.     
                Socket socket = (Socket)result.AsyncState;

                // Complete sending the data to the remote device.     
                int bytesSent = socket.EndSend(result);

                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //储存所有完整的包
        private static List<Packet> _packets;     

        //储存一个完整（或未接受完）的包
        private static MemoryStream _packetBuffer = new MemoryStream();

        private static void onReceived(IAsyncResult result)
        {
            try
            {
                Socket socket = (Socket)result.AsyncState;
                int bytesReceived = socket.EndReceive(result);
                socket.BeginReceive(_recvBuffer, 0, _recvBuffer.Length, SocketFlags.None, new AsyncCallback(onReceived), _clientSocket);
                if (bytesReceived == 0)
                {
                    onDisconnected();
                    return;
                }
                Console.WriteLine("received {0} bytes.", bytesReceived);

                _packetBuffer.Write(_recvBuffer, (int)_packetBuffer.Length + 1, bytesReceived);

                //MemoryStream streamPacket = new MemoryStream(_recvBuffer);

                while (_packetBuffer.Length >= 8)
                {
                    BinaryReader reader = new BinaryReader(_packetBuffer);
                    UInt32 len = reader.ReadUInt32();
                    UInt32 opcode = reader.ReadUInt32();

                    if (len >= MAX_RECV_LEN || 
                        _packetBuffer.Length >= MAX_RECV_LEN || 
                        bytesReceived >= MAX_RECV_LEN)
                    {
                        onDisconnected();
                        return;
                    }

                    if (_packetBuffer.Length < len)
                    {
                        return;
                    }
                    else if (_packetBuffer.Length >= len)
                    {
                        UInt32 messageLen = len - HEADER_LENGTH;
                        byte[] message = new byte[messageLen];
                        reader.Read(message, 0, message.Length);

                        Handler handlerInfo = _opcodeHandler.getHandler((Opcodes)opcode);
                        if (handlerInfo != null && handlerInfo.callback != null)
                        {
                            MethodInfo invoke_method = handlerInfo.proxy_object_type.GetMethod("Invoke");
                            //invoke_method.Invoke(handlerInfo.proxy_object, new object { });
                            //handlerInfo.proxy_object.Invoke(handlerInfo.callback, new MemoryStream(message));
                            //GlobalObject.LoginForm.Invoke(handlerInfo.callback, new MemoryStream(message));

                            invoke_method.Invoke(
                                handlerInfo.proxy_object, 
                                new object [] {
                                    handlerInfo.callback, 
                                    new MemoryStream(message)
                                }
                           );
                        }
                        
                        
                    }
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static void onDisconnected()
        { 
        
        }

        /*******************************************************************************************
        /* 其它函数
        /*******************************************************************************************/
        private static void addLog(string log)
        {
            //GlobalObject.MainForm.addLog(log);
        }

        public static void sendPacket<T>(T message)
        { 
            // Serialize body data first
            MemoryStream streamBody = new MemoryStream();
            Serializer.Serialize(streamBody, message);
            UInt32 bodyLen = (uint)streamBody.Length;

            // Find opcode value with proto typename
            UInt32 opcode = _opcodesTable[message.GetType().Name];

            // Serialize header data and body
            MemoryStream streamPacket = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(streamPacket);
            writer.Write(HEADER_LENGTH + bodyLen);
            writer.Write(opcode);
            writer.Write(streamBody.ToArray());

            int packetLen = (int)streamPacket.Length;

            _clientSocket.BeginSend(streamPacket.ToArray(), 0, packetLen, 0, new AsyncCallback(onSendCompleted), _clientSocket);
        }

        public static T parseMessage<T>(MemoryStream stream)
        {
            return Serializer.Deserialize<T>(stream);
        }
    }
}
