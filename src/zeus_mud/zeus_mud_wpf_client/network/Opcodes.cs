using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.network
{
    public enum Opcodes
    {
        C2SLoginReq     = 10000,            //登录请求
        S2CLoginRsp     = 10001,            //登录回应
        C2SRegisterReq  = 10002,            //注册请求
        S2CRegisterRsp  = 10003,            //注册回应
        C2SGetPlayerProfileReq = 15000,
        S2CGetPlayerProfileRsp = 15001,
        C2SChatMessageReq = 20000,
        S2CChatMessageNotify = 20001
    }

    public enum ErrorCode
    {
    
    }

    public delegate void NetworkMessageCallback(MemoryStream stream);
    public delegate void GameErrorCallback(ErrorCode error, string error_reason = "");
    class Handler
    {
        public Delegate callback { get; set; }
    }

    class OpcodesHandler
    {
        private static Dictionary<Opcodes, Handler> _handlers = new Dictionary<Opcodes, Handler>();
        private static Dictionary<ErrorCode, Handler> _error_handlers = new Dictionary<ErrorCode, Handler>();
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

        public static void registerErrorHandler(ErrorCode error, GameErrorCallback cb)
        {
            Handler handler = new Handler();
            handler.callback = cb;

            _error_handlers[error] = handler;
        }

    }
}
