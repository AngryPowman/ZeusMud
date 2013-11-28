//===================================================================
// File    : MessageHandler.cs
// Purpose : 
// Author  : AngryPowman
// Created : 2013/11/13 11:27:49
//===================================================================
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            MessageHandler handlerInfo = sender as MessageHandler;

            //get types
            Type proxy_type = handlerInfo.proxy_object.GetType();

            //get method refl
            MethodInfo method = proxy_type.GetMethod("Invoke", new Type[] {typeof(Delegate), typeof(object[])});
            
            //define parameters
            object[] parameters = new object[] 
            { 
                new NetworkMessageEventHandler(OnNetworkMessage),
                new object[] {sender, e}
            };

            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
            Control control = handlerInfo.proxy_object as Control;

            while (!control.IsHandleCreated)
            {
                ;
            } 

            if (control.IsHandleCreated)
            {
                object returnValue = method.Invoke(handlerInfo.proxy_object, flag, Type.DefaultBinder, parameters, null);
            }
            else 
            {
                Debug.Print("Object handle not created!");
            }
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
