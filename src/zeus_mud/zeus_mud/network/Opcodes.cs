using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWatchman.network
{
    enum Opcodes
    {
        C2SLoginReq     = 10000,            //登录请求
        S2CLoginRsp     = 10001,            //登录回应
        C2SRegisterReq  = 10002,            //注册请求
        S2CRegisterRsp  = 10003,            //注册回应
    }

    public delegate void NetworkMessageCallback(MemoryStream stream);
    class Handler
    {
        public Delegate callback { get; set; }
    }

    class OpcodesHandler
    {
        private static  Dictionary<Opcodes, Handler> _handlers = new Dictionary<Opcodes, Handler>();
        public OpcodesHandler()
        {
        }

        public Handler getHandler(Opcodes opcode)
        {
            return _handlers[opcode];
        }

        public static void registerHandler(Opcodes opcode, NetworkMessageCallback cb)
        {
            Handler handler = new Handler();
            handler.callback = cb;

            _handlers[opcode] = handler;
        }
    }
}
