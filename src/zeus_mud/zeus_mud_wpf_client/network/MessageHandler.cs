//===================================================================
// File    : MessageHandler.cs
// Purpose : 
// Author  : AngryPowman
// Created : 2013/11/13 11:27:49
//===================================================================
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.network;

namespace zeus_mud_wpf_client.network
{
    public delegate void NetworkMessageEventHandler(object sender, NetworkMessageEventArgs e);

    class MessageHandler
    {
        public event NetworkMessageEventHandler OnNetworkMessage;
        public Object proxy_object { get; set; }

        public void OnNetworkMessageEvent(object sender, NetworkMessageEventArgs e)
        {
            OnNetworkMessage(sender, e);
        }
    }

    class OpcodesProxy
    {
        private static Dictionary<Opcodes, MessageHandler> _handlers = new Dictionary<Opcodes, MessageHandler>();
        public OpcodesProxy()
        {
        }

        public MessageHandler getHandler(Opcodes opcode)
        {
            return _handlers[opcode];
        }

        public static void registerHandler<T>(Opcodes opcode, NetworkMessageEventHandler cb, T proxy_object)
        {
            MessageHandler handler = new MessageHandler();
            handler.proxy_object = proxy_object;
            handler.OnNetworkMessage += new NetworkMessageEventHandler(cb);
            _handlers[opcode] = handler;
        }

    }
}
