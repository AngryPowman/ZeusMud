using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RobotWatchman
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    [Serializable]
    class Packet
    {
        public UInt32 len { get; set; }
        public UInt32 opcode { get; set; }
        public byte[] message { get; set; }

        public UInt32 MessageLength
        {
            get
            {
                const uint base_len = 8;
                uint length = base_len;
                if (this.message != null)
                {
                    byte[] messageData = this.message as byte[];
                    if (messageData != null)
                    {
                        length = base_len + (uint)messageData.Length;
                    }
                }

                return (uint)length;
            }
        }

        public byte[] toBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                return ms.GetBuffer();
            }
        }
    }
}
