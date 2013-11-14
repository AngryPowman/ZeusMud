//===================================================================
// File    : ErrorHandler.cs
// Purpose : 
// Author  : AngryPowman
// Created : 2013/11/13 11:49:29
//===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeus_mud_wpf_client.network
{
    public delegate void GameErrorCallback(ErrorCode error, string error_reason = "");
    public class ErrorHandler
    {
        public event GameErrorCallback onGameError;
        public Object proxy_object { get; set; }
        public GameErrorCallback callback { get; set; }
    }

    public class ErrorProxy
    {
        private static Dictionary<ErrorCode, ErrorHandler> _error_handlers = new Dictionary<ErrorCode, ErrorHandler>();
        public ErrorProxy()
        {
        }

        public ErrorHandler getErrorHandler(ErrorCode error_code)
        {
            return _error_handlers[error_code];
        }

        public static void registerErrorHandler<T>(ErrorCode error, GameErrorCallback cb, T proxy_object)
        {
            ErrorHandler handler = new ErrorHandler();
            handler.callback = cb;
            handler.proxy_object = proxy_object;

            _error_handlers[error] = handler;
        }

    }
}
