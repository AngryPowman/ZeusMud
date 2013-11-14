//===================================================================
// File    : NetworkMessageEventArgs.cs
// Purpose : 
// Author  : AngryPowman
// Created : 2013/11/13 14:40:09
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
    public class NetworkMessageEventArgs : EventArgs
    {
        public Opcodes opcode { get; set; }
        public MemoryStream message { get; set; }
    }
}
